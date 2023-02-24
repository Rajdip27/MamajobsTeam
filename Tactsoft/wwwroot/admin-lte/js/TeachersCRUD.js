//Student Modal Popup
var AddTeacher = function () {
    var url = "/Teacher/Create";
    $('#titleMediumModal').html("Add New Teacher");
    loadMediumModal(url);
};

var EditTeacher = function (id) {
    var url = "/Teacher/Edit?id=" + id;
    $('#titleMediumModal').html("Update Teacher");
    loadMediumModal(url);
};

var TeacherDetails = function (id) {
    var url = "/Teacher/Details?id=" + id;
    $('#titleMediumModal').html("Teacher Details");
    loadMediumModal(url);
};

var DeleteTeacher = function (id) {
    Swal.fire({
        title: 'Do you want to delete this item?',
        type: 'warning',
        icon:'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes'
    }).then((result) => {
        if (result.value) {
            $.ajax({
                type: "POST",
                url: "/Teacher/Delete?id=" + id,
                success: function (result) {
                    var message = "Teacher has been deleted successfully";
                    Swal.fire({
                        title: message,
                        text: 'Deleted!',
                        onAfterClose: () => {
                            location.reload();
                        }
                    });
                }
            });
        }
    });
};



var loadMediumModal = function (url) {
    $("#MediumModalDiv").load(url, function () {
        $("#MediumModal").modal("show");
        $("#Name").focus();
    });
};
