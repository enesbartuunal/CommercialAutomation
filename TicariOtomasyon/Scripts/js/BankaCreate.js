$(function () {
    //modalı açmak için kullanılıyor.
    $(".btnShowModal").click(function () {
        $('#setUser1').modal('show');
    });
    $(".btnFList").click(function () {
        $('#setUser2').modal('show');
        $('#setUser1').modal('hide');
        $('#setUser').modal('hide');
    });
    $(".btnMList").click(function () {
        $('#setUser').modal('show');
        $('#setUser1').modal('hide');
        $('#setUser2').modal('hide');
    });

    //modalda seç butonuna başıldıldıktan sonra listeden secilen musteri/firma bilgisini gösterme 
    $(".btnSetM").click(function () {
        var selecteditem = document.getElementById("listM");
        var listlength = selecteditem.options.length;
        for (var i = 0; i < listlength; i++) {
            if (selecteditem.options[i].selected) {
                $("#sonuctext").html(selecteditem.options[i].text);
                $("#sonuctext2").html(selecteditem.options[i].value);
                $('#setUser').modal('hide');
                
            }
        }

    });

    $(".btnSetF").click(function () {
        var selecteditem = document.getElementById("listF");
        var listlength = selecteditem.options.length;
        for (var i = 0; i < listlength; i++) {
            if (selecteditem.options[i].selected) {
                $("#sonuctext3").html(selecteditem.options[i].text);
                $("#sonuctext4").html(selecteditem.options[i].value);
                $('#setUser2').modal('hide');
                
            }
        }

    });

});