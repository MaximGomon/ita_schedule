$(document).ready(function () {
    $("#btn-submit").attr("disabled", true);
});

function validateAddSubjectForm(arr) {
    arr = JSON.parse(arr);
    var valid = true;
    valid = checkEmpty($("#Name"));
    
    valid = valid && checkNumber($("#Code"), arr);

    $("#btn-submit").attr("disabled", true);
    if (valid) {
        $("#btn-submit").attr("disabled", false);
    }
}

function checkEmpty(obj) {
    var name = $(obj).attr("name");
    $("." + name + "-validation").html("");
    $(obj).css("border", "");
    var nameVal = $.trim($(obj).val());

    if (nameVal === "" || nameVal.length > 400) {
        $(obj).css("border", "#FF0000 1px solid");
        $("." + name + "-validation").html("Required");
        return false;
    }

    return true;
}

function checkNumber(obj, arr) {
    var result = true;

    var name = $(obj).attr("name");
    $("." + name + "-validation").html("");
    $(obj).css("border", "");

    result = checkEmpty(obj);

    if (!result) {
        $(obj).css("border", "#FF0000 1px solid");
        $("." + name + "-validation").html("Required");
        return false;
    }
    var test = parseInt($(obj).val());

    if ($(obj).val() < 1 || $(obj).val().length > 99999999 || jQuery.inArray(test, arr) !== -1) {
        $(obj).css("border", "#FF0000 1px solid");
        $("." + name + "-validation").html("Required");
        return false;
    }
    
    return result;
}