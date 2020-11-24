
$(document).ready(function () {
    $('#update-info').on('click', function () {
        updateInfor();
    });
    $('#change-password').on('click', function () {
        changePassword();
    });
    function updateInfor() {
        const regex_email = /^[A-Za-z0-9]+[_\.\-]?[A-Za-z0-9]*@[A-Za-z0-9]+[-\.\_]{1}[A-Za-z0-9]+[\.]?[A-Za-z]*[\.]?[A-Za-z]*$/;
        const regex_phone = /^[0]{1}[1-9]{1}[0-9]{8,9}$/;
        var warning = $('#update-warning');
        var hiddden = $('#update-hidden');
        var email = $('#prof-email').val();
        var address = $('#prof-address').val();
        var gender = $('#prof-gender').val();
        var fullname = $('#prof-fullname').val();
        var phone = $('#prof-phone').val();

        if (email == '' || fullname == '' || phone == '') {
            hiddden.css('display', 'block');
            warning.html('Vui lòng nhập đầy đủ các trường bắt buộc (*)!');
            return;
        } else {
            hiddden.css('display', 'none');

        }
        var err = false;
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
        formData.append('email', email);
        formData.append('address', address);
        formData.append('gender', gender);
        formData.append('fullname', fullname);
        formData.append('phone', phone);
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Account/UpdateInfor', true);
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
                    warning.css('color', '#1abc9c');
                    $('#account').html('').html(fullname);
                } else {
                    warning.css('color', 'red');
                }
                hiddden.css('display', 'block');
                warning.html('');
                warning.html(json_data.Data.message);
            }
        };
        xhr.send(formData);
    }
    function changePassword() {
        var warning = $('#change-pass-hidden');
        var hiddden = $('#change-pass-hidden');
        var password = $('#cur-pass').val();
        var newPassword = $('#new-pass').val();
        var retypePassword = $('#retype-pass').val();
        if (password == '' || newPassword == '' || retypePassword == '') {
            hiddden.css('display', 'block');
            warning.html('Vui lòng nhập đầy đủ các trường bắt buộc (*)!');
            return;
        } else {
            hiddden.css('display', 'none');
        }
        var err1 = false, err2 = false;
        if (retypePassword != newPassword) {
            $('#retype-pass-warning').html(' Mật khẩu nhập lại không khớp!');
            err1 = true;
        } else {
            $('#retype-pass-warning').html(''); err1 = false;
        }
        if (newPassword.length < 6) {
            $('#new-pass-warning').html(' Mật khẩu phải từ 6 ký tự trở lên!');
            err2 = true;
        } else {
            $('#new-pass-warning').html(''); err2 = false;
        }
        
        if (err1 || err2) {
            $('#cur-pass-warning').html('');
            return;
        }
        // Khởi tạo dữ liệu để gửi về controller xử lý
        var formData = new FormData();
        formData.append('curPassword', password);
        formData.append('newPassword', newPassword);
        var xhr = new XMLHttpRequest();
        xhr.open('POST', '/Account/ChangePassword', true);
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
                    warning.css('color', '#1abc9c');
                    warning.html('Đổi mật khẩu thành công.');
                    hiddden.css('display', 'block');
                    // Xóa dữ liệu của form đổi mật khẩu
                    $('#cur-pass').val('');
                    $('#new-pass').val('');
                    $('#retype-pass').val('');
                    $('#new-pass-warning').html('');
                    $('#retype-pass-warning').html('');
                    $('#cur-pass-warning').html('');
                } else {
                    $('#cur-pass-warning').html('').html('Mật khẩu hiện tại không đúng!');
                }  
            }
        };
        xhr.send(formData);
    }
});