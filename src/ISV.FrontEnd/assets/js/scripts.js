
jQuery(document).ready(function() {
	
    
    /*
        Login form validation
    */
    $('.login-form input[type="text"], .login-form input[type="password"], .login-form').on('focus', function() {
    	$(this).removeClass('input-validation-error');
		$('[data-valmsg-for^=' +$(this)[0].id).remove();
    });

	
    $('.registration-form input[type="text"], .registration-form input[type="password"]').on('focus', function() {
        $(this).removeClass('input-validation-error');
        $('[data-valmsg-for^=' + $(this)[0].id).remove();
    });
    
});
