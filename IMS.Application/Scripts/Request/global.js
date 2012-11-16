$(document).ready(function () {
    $('.carousel').carousel();
    $('#UserName').addClass("input-block-level").attr("placeholder", "Juan Dela Cruz");
    $('#Password').addClass("input-block-level").attr("placeholder", "pass@*****");
    $('.validation-summary-errors').addClass("alert alert-error login-errors");    
});

$('.dropdown-toggle').click(function () {
    showDropDown();
});

$('.close').click(function () {
    closeDropDown();
});

closeDropDown = function () {    
        $('.dropdown-menu').fadeOut('slow', function () { });
        $('.btn-group').removeClass("open");
    }

showDropDown = function () {
    $('.dropdown-menu').show().animate({ top: 37 }, 200, function () { });
        $('.btn-group').addClass("open");
    }

$("#Register").click(function () {
    window.location = "../Account/Register";
});

//Validations 
fadeRegisterErrors = function () {
    $('.register .editor-field span').fadeIn().delay(2000).fadeOut('slow');
    $('.login-errors').fadeIn().delay(2000).fadeOut('slow');
}

fadeLoginErrors = function () {
    $('.login .editor-field span').fadeIn().delay(2000).fadeOut('slow');
    $('.login-errors').fadeIn().delay(2000).fadeOut('slow');
}

