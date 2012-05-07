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


var Utf8 = {

    // public method for url encoding
    encode: function (string) {
        string = string.replace(/\r\n/g, "\n");
        var utftext = "";

        for (var n = 0; n < string.length; n++) {

            var c = string.charCodeAt(n);

            if (c < 128) {
                utftext += String.fromCharCode(c);
            }
            else if ((c > 127) && (c < 2048)) {
                utftext += String.fromCharCode((c >> 6) | 192);
                utftext += String.fromCharCode((c & 63) | 128);
            }
            else {
                utftext += String.fromCharCode((c >> 12) | 224);
                utftext += String.fromCharCode(((c >> 6) & 63) | 128);
                utftext += String.fromCharCode((c & 63) | 128);
            }

        }

        return utftext;
    },

    // public method for url decoding
    decode: function (utftext) {
        var string = "";
        var i = 0;
        var c = c1 = c2 = 0;

        while (i < utftext.length) {

            c = utftext.charCodeAt(i);

            if (c < 128) {
                string += String.fromCharCode(c);
                i++;
            }
            else if ((c > 191) && (c < 224)) {
                c2 = utftext.charCodeAt(i + 1);
                string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
                i += 2;
            }
            else {
                c2 = utftext.charCodeAt(i + 1);
                c3 = utftext.charCodeAt(i + 2);
                string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
                i += 3;
            }

        }

        return string;
    },

     // public method for url decoding
    decodeArray: function (utfArray) {
        var string = "";
        var i = 0;
        var c = c1 = c2 = 0;

        while (i < utfArray.length) {

            c = utfArray[i];

            if (c < 128) {
                string += String.fromCharCode(c);
                i++;
            }
            else if ((c > 191) && (c < 224)) {
                c2 = utfArray[i + 1];
                string += String.fromCharCode(((c & 31) << 6) | (c2 & 63));
                i += 2;
            }
            else {
                c2 = utfArray[i + 1];
                c3 = utfArray[i + 2];
                string += String.fromCharCode(((c & 15) << 12) | ((c2 & 63) << 6) | (c3 & 63));
                i += 3;
            }

        }

        return string;
    }

}