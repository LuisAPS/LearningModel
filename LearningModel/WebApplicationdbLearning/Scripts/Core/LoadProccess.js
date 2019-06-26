var LoadProccess = {
    RemoveLoad:function(){
        $("#WindowLoad").remove();
    },
    ShowLoad: function (mensaje) {
        LoadProccess.RemoveLoad();

        if (mensaje == undefined)
        {
            mensaje = "Procesando petición <br> Espere por favor";
        }

        height = 20;
        var ancho = 0;
        var alto = 0;


        if (window.innerWidth == undefined)
            ancho = window.screen.width;
        else
            ancho = window.innerWidth;

        if (window.innerHeight == undefined)
            alto = window.screen.Height;
        else
            alto= window.innerHeight;

        var heightdiv = alto / 2 - parseInt(height) / 2
        imgCentro = "<div style='text-align:center;height:" + alto + "px;'><div style='color:#000;margin-top:" + heightdiv + "px; font-weight:bold'>" + mensaje + "</div><img src='img/load.gif'></div>";

        div = document.createElement("div");
        div.id = "WindowLoad";
        div.style.width = ancho + "px";
        div.style.height = alto + "px";
        $("body").append(div);

        input = document.createElement("input");
        input.id = "focusInput";
        input.type = "text";

        $("WindowLoad").append(input);

        $("focusInput").focus();
        $("focusInput").hide();

        $("WindowLoad").html(imgCentro);

    }

}