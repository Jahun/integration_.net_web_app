
//Email validator begin
var emailValidator = function (email) {
    var compem = /[A-Z0-9._%+-]+@[A-Z0-9.-]+\b[.][A-Z]{2,4}/igm;
    return compem.test(email);
}
//Email validator end

//Input error begin
var inputerror = function (t) {
    t.addClass('inputerror', 1000);
    setTimeout(function () {
        t.removeClass('inputerror');
    }, 3000);
}
//Input error end

$(function () {

    $('input[name="register"]').click(function (e) {

        var name = $('input[name="name"]');
        var email = $('input[name="email"]');
        var password = $('input[name="password"]');
        var retype_password = $('input[name="retype_password"]');
        var enter = true;
        $('input').each(function (i) {
            var th = $('input').eq(i);
            if (th.val() == '') {
                inputerror(th);
                enter = false;
            }
        });
        if (password.val() != retype_password.val()) {
            inputerror(password);
            inputerror(retype_password);
            enter = false;
        }
        if (!emailValidator(email.val().trim())) {
            inputerror(email);
            enter = false;
        }

        if (enter == false) {
            e.preventDefault();
        }

    });

});