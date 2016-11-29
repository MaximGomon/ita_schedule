// validation of all inputs in the ad user form
function userTypeValidation() {
    var text = $("#Type :selected").text();
    
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