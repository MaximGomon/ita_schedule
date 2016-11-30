// validation of all inputs in the ad user form
function userTypeValidation() {
    var text = $("#TypeOfUser :selected").text();
    
    if (text === "Teacher") {
        $("#studentBlock").css("display", "none");
        $("StudentId").prop("required", false);
        $("#teacherBlock").css("display", "block");
        $("#TeacherId").prop("required", true);
    } else if (text === "Student") {
        $("#teacherBlock").css("display", "none");
        $("#TeacherId").prop("required", false);
        $("#studentBlock").css("display", "block");
        $("#StudentId").prop("required", true);
    } else {
        $("#studentBlock").css("display", "none");
        $("StudentId").prop("required", false);
        $("#teacherBlock").css("display", "none");
        $("#TeacherId").prop("required", false);
    }
}

$(function () {
    userTypeValidation();
});

function validateUpdateUserForm(logins) {
    console.log(logins);
    logins = JSON.parse(logins);

    var valid = checkLogin($("#Login"), logins);

    $("#btn-submit").attr("disabled", true);
    if (valid) {
        $("#btn-submit").attr("disabled", false);
    }
}

function checkLogin(obj, arr) {
    if (jQuery.inArray($(obj).val().toLowerCase(), arr) !== -1) {
        $(obj).css("border", "#FF0000 1px solid");
        $("." + name + "-validation").html("Required");
        return false;
    } else {
        $("." + name + "-validation").html("");
        $(obj).css("border", "");
        return true;
    }
}

