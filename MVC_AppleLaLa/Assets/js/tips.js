var password = document.getElementsByClassName("password")[0];
var password_tip = document.getElementsByClassName("password_tip")[0];
password.onclick = function (e) {                  //點擊出现
    password_tip.style.display = "block";
    e.stopPropagation();         //關閉
}
// 點擊空白消失
document.onclick = function (e) {
    password_tip.style.display = "none";
}