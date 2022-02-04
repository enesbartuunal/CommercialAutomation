$(function () {
    $(".delete").click(function () {
        let id = $(this).attr("id");
        Swal.fire({
            title: " Bilgiler silinecektir, onaylıyor musunuz?",
            showCancelButton: true,
            confirmButtonText: "Sil",
            cancelButtonText: "İptal"
        }).then(function (result) {
            if (result.isConfirmed) {
                $.ajax({
                    type: "Post",
                    dataType: "Json",
                    url: "/Fatura/Delete",
                    data: { id: id },
                    success: function (response) {
                        Swal.fire({
                            title: "Bilgiler silindi!",
                            confirmButtonText: "Tamam"
                        }).then(function (result) {
                            if (result.isConfirmed)
                                location.reload();
                        });
                    }
                });
            }

        });
    });
});