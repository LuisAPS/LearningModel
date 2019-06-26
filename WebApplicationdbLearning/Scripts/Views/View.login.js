var View = {
	login: {
		Init :function(o) {
		    domVO = o;
		    $(domVO.button.Signme).click(function () {
		        View.login.Validate()

		    });

		},
		Validate: function () {
		    $.ajax({
		        type: "POST",
		        url: domVO.method.login,
		        data: JSON.stringify({ sPerson: $(domVO.text.User).val(), sPassword: $(domVO.text.Pass).val() }),
		        contentType: "application/json; charset=utf-8",
		        dataType: "json",
		        success: function (r) {
		            if (r.IsAuthenticated)
		            {
		                window.location.replace(r.url); //this.window.location.href = r.url;
		            }
		            else
		            {
                        toastr["error"]("Usuario no autenticado");
		            }
		   
		            
		            
		           
		        },
		        error: function (a, b, c) {
                    
		        }
		    });
			
		}

	}
};

var domVO = {

}