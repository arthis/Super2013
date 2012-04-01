function guidGenerator() {
    var S4 = function () {
        return (((1 + Math.random()) * 0x10000) | 0).toString(16).substring(1);
    };
    return (S4() + S4() + "-" + S4() + "-" + S4() + "-" + S4() + "-" + S4() + S4() + S4());
}

function ToDate(value) {
    if (value!=null)
        return new Date(parseInt(value.replace("/Date(", "").replace(")/", ""), 10));
    return null;
}



$.validator.unobtrusive.addValidation = function (selector) {
    //get the relevant form 
    var form = $(selector);
    // delete validator in case someone called form.validate()
    $(form).removeData('validator');
    $.validator.unobtrusive.parse(form);
}



var Spinner = function () {
    this.Spin = function (waiting) {
        if (waiting==null)
            alert("please call the Spin function using Spin({});");

        // create the loading window and set autoOpen to false
        $("#loading").dialog({
            autoOpen: false, // set this to false so we can manually open it
            dialogClass: "loadingScreenWindow",
            closeOnEscape: false,
            draggable: false,
            width: 460,
            minHeight: 50,
            modal: true,
            buttons: {},
            resizable: false,
            open: function () {
                // scrollbar fix for IE
                $('body').css('overflow', 'hidden');
                //remove the X
                $("a.ui-dialog-titlebar-close").remove();
            },
            close: function () {
                // reset overflow
                $('body').css('overflow', 'auto');
            }
        }); // end of dialog
        $("#loading").html(waiting.message && '' != waiting.message ? waiting.message : 'Please wait...');
	    $("#loading").dialog('option', 'title', waiting.title && '' != waiting.title ? waiting.title : 'Loading');
	    $("#loading").dialog('open');
    };
    this.StopSpin = function () {
        $("#loading").dialog("close");
    };
}
