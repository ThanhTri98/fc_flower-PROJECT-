$(document).keypress(function (event) {
    // Bắt sự kiện nhấn enter
    var keycode = (event.keyCode ? event.keyCode : event.which);
    if (keycode == '13') {
        sendDataLogin();
    }
});

$(document).ready(function () {
    $('#login-submit').on('click', function () {
        sendDataLogin();
    });
    $('#regis-submit').on('click', function () {
        sendDataRegister();
    });
});
function sendDataLogin() {
    var username = $('#login-username').val();
    var password = $('#login-password').val();
    var warning = $('#login-warning');
    var hiddden = $('#login-hidden');
    if (username == '' || password == '') {
        hiddden.css('display', 'block');
        warning.html('Vui lòng nhập đầy đủ Tài khoản và Mật khẩu!');
        return;
    }
    // Khởi tại dữ liệu để gửi về controller xử lý
    var formData = new FormData();
    formData.append('username', username);
    formData.append('password', password);
    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Account/Login', true);
    xhr.onreadystatechange = function () {
        // 1 request gửi đi thì server xử lý qua 4 bước
        // -- 1: Gửi Request
        // -- 2: Server nhận request
        // -- 3: Server xử lý
        // -- 4: Server trả về kết quả
        if (xhr.readyState == 4 && xhr.status == 200) { // Chỉ bắt sự kiện tại giai đoạn 4 và kết quả trả về có status là 200
            var content = xhr.responseText;
            var json_data = JSON.parse(content);
            if (json_data.Data.status == 'OK') {
                if (json_data.Data.link_cart != null) {
                    window.location = json_data.Data.link_cart;
                } else {
                    window.location = 'trang-chu';
                }

            } else {
                hiddden.css('display', 'block');
                warning.html('Tài khoản hoặc Mật khẩu không chính xác!');
            }
        }
    };
    xhr.send(formData);
}
function sendDataRegister() {
    const regex_email = /^[A-Za-z0-9]+[_\.\-]?[A-Za-z0-9]*@[A-Za-z0-9]+[-\.\_]{1}[A-Za-z0-9]+[\.]?[A-Za-z]*[\.]?[A-Za-z]*$/;
    const regex_phone = /^[0]{1}[1-9]{1}[0-9]{8,9}$/;
    var warning = $('#regis-warning');
    var hiddden = $('#regis-hidden');

    var username = $('#regis-username').val();
    var password = $('#regis-password').val();
    var email = $('#regis-email').val();
    var address = $('#regis-address').val();
    var gender = $('#regis-gender').val();
    var fullname = $('#regis-fullname').val();
    var phone = $('#regis-phone').val();

    if (username == '' || email == '' || fullname == '' || phone == '') {
        hiddden.css('display', 'block');
        warning.html('Vui lòng nhập đầy đủ các trường bắt buộc (*)!');
        return;
    } else {
        hiddden.css('display', 'none');
    }
    var err = false;
    if (password.length < 6) {
        $('#password-warning').html(' Mật khẩu phải từ 6 ký tự trở lên!');
        err = true;
    } else {
        $('#password-warning').html(''); err = false;
    }
    if (!(regex_email.test(email))) {

        $('#email-warning').html(' Email sai định dạng!');
        err = true;
    } else {
        $('#email-warning').html(''); err = false;
    }
    if (!(regex_phone.test(phone))) {
        $('#phone-warning').html(' Số điện thoại sai định dạng!');
        err = true;
    } else {
        $('#phone-warning').html(''); err = false;
    }
    if (err) return;
    // Khởi tạo dữ liệu để gửi về controller xử lý
    var formData = new FormData();
    formData.append('username', username);
    formData.append('password', password);
    formData.append('email', email);
    formData.append('address', address);
    formData.append('gender', gender);
    formData.append('fullname', fullname);
    formData.append('phone', phone);
    var xhr = new XMLHttpRequest();
    xhr.open('POST', '/Account/Register', true);
    xhr.onreadystatechange = function () {
        // 1 request gửi đi thì server xử lý qua 4 bước
        // -- 1: Gửi Request
        // -- 2: Server nhận request
        // -- 3: Server xử lý
        // -- 4: Server trả về kết quả
        if (xhr.readyState == 4 && xhr.status == 200) { // Chỉ bắt sự kiện tại giai đoạn 4 và kết quả trả về có status là 200
            var content = xhr.responseText;
            var json_data = JSON.parse(content);
            if (json_data.Data.status == 'OK') {
                hiddden.css('display', 'block');
                warning.css('color', '#1abc9c');
                warning.html(json_data.Data.message);
                // Gán sẵn tài khoản và mật khẩu vào form đăng nhập
                $('#login-username').val(username);
                $('#login-password').val(password)
                $('#login-warning').html('');
                // xóa sạch dữ liệu trong form đăng ký
                $('#regis-username').val('');
                $('#regis-password').val('');
                $('#regis-email').val('');
                $('#regis-address').val('');
                $('#regis-gender').val('');
                $('#regis-fullname').val('');
                $('#regis-phone').val('');
                $('#email-warning').html('');
                $('#phone-warning').html('');
                $('#password-warning').html('');
            } else {
                hiddden.css('display', 'block');
                warning.html(json_data.Data.message);
            }
        }
    };
    xhr.send(formData);
}