function validateAddTeacherForm() {

    var valid = true;
    valid = checkEmpty($("#Name"));

    $("#btn-submit").attr("disabled", true);
    if (valid) {
        $("#btn-submit").attr("disabled", false);
    }
}

function checkEmpty(obj) {
    var name = $(obj).attr("name");
    $("." + name + "-validation").html("");
    $(obj).css("border", "");
    if ($(obj).val() == "" || $(obj).val().length > 400) {
        $(obj).css("border", "#FF0000 1px solid");
        $("." + name + "-validation").html("Required");
        return false;
    }

    return true;
}