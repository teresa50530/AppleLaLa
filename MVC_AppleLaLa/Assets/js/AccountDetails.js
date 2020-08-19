document.writeln("<div id=\"leftDiv1\" ><a href='../ShippingProcess/choose_location' target=_blank><img src='https://neverneverlandinbali.com/wp-content/uploads/2018/09/%E6%88%91%E8%A6%81%E9%A0%90%E7%B4%84.png' border=0 class='go_gif' title='預約'></a><div class='divclose1'><span onclick=\"$('#leftDiv1').remove()\">關閉X</span></div></div>");
let _label = document.querySelectorAll('.input_label');
_label.forEach(item => {
    let _span = document.createElement('span');
    _span.textContent = '*';
    _span.className = 'req';
    item.appendChild(_span)
});

let edit_btn = document.querySelector('._fa-edit');

let all = document.querySelectorAll('input');

let btn = document.querySelectorAll('.btn_submit');
edit_btn.addEventListener('click', () => {

    all.forEach(item => {
        if (item.hasAttribute('disabled')) {
            item.removeAttribute('disabled');
        } else {
            item.setAttribute('disabled', 'true')
        }
    })
    btn.forEach(item => {
        if (item.hasAttribute('disabled')) {
            item.removeAttribute('disabled');
            item.setAttribute('style', 'background-image:linear-gradient(to right, #fc6076, #ff9a44, #ef9d43, #e75516);box-shadow:0 4px 15px 0 rgba(252, 104, 110, 0.75)');

        } else {
            item.setAttribute('disabled', 'true')
            item.setAttribute('style', 'background-image:linear-gradient(to right, #BEBEBE, #E0E0E0,  #BEBEBE, #E0E0E0);box-shadow:0 0px 0px 0 rgba(252, 104, 110, 0.75)');
        }
    })
});
btn[0].addEventListener('click', () => {
    window.location.reload();
});


//var all_input = document.querySelectorAll('input');
//all_input.forEach(function (item) {
//    item.setAttribute("onpaste") = "return false";
//    item.setAttribute("ondragenter") = "return false";
//    item.setAttribute("onkeyup") = "this.value=check(this.value)";
//})
function check(str) {
    var temp = ""
    for (var i = 0; i < str.length; i++)
        if (str.charCodeAt(i) > 0 && str.charCodeAt(i) < 255)
            temp += str.charAt(i)
    return temp
}
