﻿using Newtonsoft.Json;
using MVC_AppleLaLa.Models.PayModels;
using MVC_AppleLaLa.Models.PayModels.Record;
using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Configuration;
using MVC_AppleLaLa.Servicies;
using MVC_AppleLaLa.Models;

namespace Spgateway.Controllers
{
    [Authorize]
    public class BankController : Controller
    {
        private static string Data = null;


        static string BankId = ConfigurationSettings.AppSettings["BankId"].ToString();
        static string BankSecret = ConfigurationSettings.AppSettings["BankSecret"].ToString();
        static string BankIv = ConfigurationSettings.AppSettings["BankIv"].ToString();
        /// <summary>
        /// 金流基本資料(可再移到Web.config或資料庫設定)
        /// </summary>
        private BankInfoModel _bankInfoModel = new BankInfoModel
        {
            MerchantID = BankId,
            HashKey = BankSecret,
            HashIV = BankIv,
            //付款完後頁面 /*https://localhost:44365/Bank/SpgatewayReturn*/
            ReturnURL = "http://applelala.azurewebsites.net/Bank/SpgatewayReturn",
            NotifyURL = "",
            CustomerURL = "http://yourWebsitUrl/Bank/SpgatewayCustomer",
            AuthUrl = "https://ccore.spgateway.com/MPG/mpg_gateway",
            CloseUrl = "https://core.newebpay.com/API/CreditCard/Close"
        };

        /// <summary>
        /// 付款頁面
        /// </summary>
        /// <returns></returns>
        public ActionResult PayBill()
        {
            return View();
        }

        /// <summary>
        /// [智付通支付]金流介接
        /// </summary>
        /// <param name="ordernumber">訂單單號</param>
        /// <param name="amount">訂單金額</param>
        /// <param name="payType">請款類型</param>
        /// <returns></returns>

        [HttpPost]
        public ActionResult SpgatewayPayBill(int amount, string payType)
        {
            string version = "1.5";

            // 目前時間轉換 +08:00, 防止傳入時間或Server時間時區不同造成錯誤
            DateTimeOffset taipeiStandardTimeOffset = DateTimeOffset.Now.ToOffset(new TimeSpan(8, 0, 0));

            TradeInfo tradeInfo = new TradeInfo()
            {
                // * 商店代號
                MerchantID = _bankInfoModel.MerchantID,
                // * 回傳格式
                RespondType = "String",
                // * TimeStamp
                TimeStamp = taipeiStandardTimeOffset.ToUnixTimeSeconds().ToString(),
                // * 串接程式版本
                Version = version,
                // * 商店訂單編號
                //MerchantOrderNo = $"T{DateTime.Now.ToString("yyyyMMddHHmm")}",
                MerchantOrderNo = taipeiStandardTimeOffset.ToUnixTimeSeconds().ToString(),
                // * 訂單金額
                Amt = amount,
                // * 商品資訊
                ItemDesc = "美甲美睫服務",
                // 繳費有效期限(適用於非即時交易)
                ExpireDate = null,
                // 支付完成 返回商店網址
                ReturnURL = _bankInfoModel.ReturnURL,
                // 支付通知網址
                NotifyURL = _bankInfoModel.NotifyURL,
                // 商店取號網址
                CustomerURL = _bankInfoModel.CustomerURL,
                // 支付取消 返回商店網址
                ClientBackURL = null,
                // * 付款人電子信箱
                Email = string.Empty,
                // 付款人電子信箱 是否開放修改(1=可修改 0=不可修改)
                EmailModify = 0,
                // 商店備註
                OrderComment = null,
                // 信用卡 一次付清啟用(1=啟用、0或者未有此參數=不啟用)
                CREDIT = null,
                // WEBATM啟用(1=啟用、0或者未有此參數，即代表不開啟)
                WEBATM = null,
                ANDROIDPAY = null,
                SAMSUNGPAY = null,
                // ATM 轉帳啟用(1=啟用、0或者未有此參數，即代表不開啟)
                VACC = null,
                // 超商代碼繳費啟用(1=啟用、0或者未有此參數，即代表不開啟)(當該筆訂單金額小於 30 元或超過 2 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。)
                CVS = null,
                // 超商條碼繳費啟用(1=啟用、0或者未有此參數，即代表不開啟)(當該筆訂單金額小於 20 元或超過 4 萬元時，即使此參數設定為啟用，MPG 付款頁面仍不會顯示此支付方式選項。)
                BARCODE = null
            };

            if (string.Equals(payType, "CREDIT"))
            {
                tradeInfo.CREDIT = 1;
            }
            else if (string.Equals(payType, "WEBATM"))
            {
                tradeInfo.WEBATM = 1;
            }
            else if (string.Equals(payType, "ANDROIDPAY"))
            {
                tradeInfo.ANDROIDPAY = 1;
            }
            else if (string.Equals(payType, "SAMSUNGPAY"))
            {
                tradeInfo.SAMSUNGPAY = 1;
            }
            else if (string.Equals(payType, "VACC"))
            {
                // 設定繳費截止日期
                tradeInfo.ExpireDate = taipeiStandardTimeOffset.AddDays(1).ToString("yyyyMMdd");
                tradeInfo.VACC = 1;
            }
            else if (string.Equals(payType, "CVS"))
            {
                // 設定繳費截止日期
                tradeInfo.ExpireDate = taipeiStandardTimeOffset.AddDays(1).ToString("yyyyMMdd");
                tradeInfo.CVS = 1;
            }
            else if (string.Equals(payType, "BARCODE"))
            {
                // 設定繳費截止日期
                tradeInfo.ExpireDate = taipeiStandardTimeOffset.AddDays(1).ToString("yyyyMMdd");
                tradeInfo.BARCODE = 1;
            }

            Atom<string> result = new Atom<string>()
            {
                IsSuccess = true
            };

            var inputModel = new SpgatewayInputModel
            {
                MerchantID = _bankInfoModel.MerchantID,
                Version = version
            };

            // 將model 轉換為List<KeyValuePair<string, string>>, null值不轉
            List<KeyValuePair<string, string>> tradeData = LambdaUtil.ModelToKeyValuePairList<TradeInfo>(tradeInfo);
            // 將List<KeyValuePair<string, string>> 轉換為 key1=Value1&key2=Value2&key3=Value3...
            var tradeQueryPara = string.Join("&", tradeData.Select(x => $"{x.Key}={x.Value}"));
            // AES 加密
            inputModel.TradeInfo = CryptoUtil.EncryptAESHex(tradeQueryPara, _bankInfoModel.HashKey, _bankInfoModel.HashIV);
            // SHA256 加密
            inputModel.TradeSha = CryptoUtil.EncryptSHA256($"HashKey={_bankInfoModel.HashKey}&{inputModel.TradeInfo}&HashIV={_bankInfoModel.HashIV}");

            // 將model 轉換為List<KeyValuePair<string, string>>, null值不轉
            List<KeyValuePair<string, string>> postData = LambdaUtil.ModelToKeyValuePairList<SpgatewayInputModel>(inputModel);

            Response.Clear();

            StringBuilder s = new StringBuilder();
            s.Append("<html>");
            s.AppendFormat("<body onload='document.forms[\"form\"].submit()'>");
            s.AppendFormat("<form name='form' action='{0}' method='post'>", _bankInfoModel.AuthUrl);
            foreach (KeyValuePair<string, string> item in postData)
            {
                s.AppendFormat("<input type='hidden' name='{0}' value='{1}' />", item.Key, item.Value);
            }

            s.Append("</form></body></html>");
            Response.Write(s.ToString());
            Response.End();

            return Content(string.Empty);

        }

        public void GetCart(string jdata)
        {
            Data = jdata;
            //var _jdata = Newtonsoft.Json.JsonConvert.DeserializeObject<List<CartDetail>>(jdata);
            //intoDB DB = new intoDB();
            //DB._intoDB(_jdata);

        }

        /// <summary>
        /// [智付通]金流介接(結果: 支付完成 返回商店網址)
        /// </summary>
        [HttpPost]
        public ActionResult SpgatewayReturn()
        {
            Request.LogFormData("SpgatewayReturn(支付完成)");

            // Status 回傳狀態 
            // MerchantID 回傳訊息
            // TradeInfo 交易資料AES 加密
            // TradeSha 交易資料SHA256 加密
            // Version 串接程式版本
            NameValueCollection collection = Request.Form;

            if (collection["MerchantID"] != null && string.Equals(collection["MerchantID"], _bankInfoModel.MerchantID) &&
                collection["TradeInfo"] != null && string.Equals(collection["TradeSha"], CryptoUtil.EncryptSHA256($"HashKey={_bankInfoModel.HashKey}&{collection["TradeInfo"]}&HashIV={_bankInfoModel.HashIV}")))
            {
                var decryptTradeInfo = CryptoUtil.DecryptAESHex(collection["TradeInfo"], _bankInfoModel.HashKey, _bankInfoModel.HashIV);

                // 取得回傳參數(ex:key1=value1&key2=value2),儲存為NameValueCollection
                NameValueCollection decryptTradeCollection = HttpUtility.ParseQueryString(decryptTradeInfo);
                SpgatewayOutputDataModel convertModel = LambdaUtil.DictionaryToObject<SpgatewayOutputDataModel>(decryptTradeCollection.AllKeys.ToDictionary(k => k, k => decryptTradeCollection[k]));

                LogUtil.WriteLog(JsonConvert.SerializeObject(convertModel));

                // TODO 將回傳訊息寫入資料庫
                intoDB DB = new intoDB();
                var Status = convertModel.Status;
                var OrderNo = convertModel.MerchantOrderNo;
                var PayWay = convertModel.PaymentType;
                var PayWay_id = 0;

                switch (PayWay)
                {
                    case "CREDIT":
                        PayWay_id = 1;
                        break;
                    case "SAMSUNGPAY":
                        PayWay_id = 2;
                        break;
                    case "ANDROIDPAY":
                        PayWay_id = 3;
                        break;
                    case "WEBATM":
                        PayWay_id = 4;
                        break;
                    case "VACC":
                        PayWay_id = 5;
                        break;
                    default:
                        PayWay_id = 6;
                        break;
                }

                if (Status== "SUCCESS")
                {
                    var data = Data;
                    AccountDetailService Account = new AccountDetailService();
                    var user_name = HttpContext.User.Identity.Name;
                    var viewmodel = Account.get_account_detail(user_name);
                    DB._intoDB(data, Status, OrderNo, PayWay_id, viewmodel.Cust_id);
                }

            }
            else
            {
                LogUtil.WriteLog("MerchantID/TradeSha驗證錯誤");
            }

            return View();
        }

        /// <summary>
        /// [智付通]金流介接(結果: 支付通知網址)
        /// </summary>
        [HttpPost]
        public ActionResult SpgatewayNotify()
        {
            // 取法同SpgatewayResult

            Request.LogFormData("SpgatewayNotify(支付通知)");
            return Content(string.Empty);
        }

        /// <summary>
        /// [智付通]金流介接(結果: 資料回傳)
        /// </summary>
        [HttpPost]
        public ActionResult SpgatewayCustomer()
        {
            Request.LogFormData("SpgatewayCustomer(資料回傳)");

            // Status 回傳狀態 
            // MerchantID 回傳訊息
            // TradeInfo 交易資料AES 加密
            // TradeSha 交易資料SHA256 加密
            // Version 串接程式版本
            NameValueCollection collection = Request.Form;

            if (collection["MerchantID"] != null && string.Equals(collection["MerchantID"], _bankInfoModel.MerchantID))
            {
                var decryptTradeInfo = CryptoUtil.DecryptAESHex(collection["TradeInfo"], _bankInfoModel.HashKey, _bankInfoModel.HashIV);

                // 取得回傳參數(ex:key1=value1&key2=value2),儲存為NameValueCollection
                NameValueCollection decryptTradeCollection = HttpUtility.ParseQueryString(decryptTradeInfo);
                SpgatewayTakeNumberDataModel convertModel = LambdaUtil.DictionaryToObject<SpgatewayTakeNumberDataModel>(decryptTradeCollection.AllKeys.ToDictionary(k => k, k => decryptTradeCollection[k]));

                LogUtil.WriteLog(JsonConvert.SerializeObject(convertModel));

                // TODO 將回傳訊息寫入資料庫

                return Content(JsonConvert.SerializeObject(convertModel));
            }
            else
            {
                LogUtil.WriteLog("MerchantID錯誤");
            }

            return Content(string.Empty);
        }
    }
}