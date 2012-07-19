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


$.ajaxSetup({ cache: false });



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



var DateTimeMin = new Date().setFullYear(2000, 0, 1);
var DateTimeMax = new Date().setFullYear(2050, 0, 1);


function jq(myid) {
    return '#' + myid.replace(/(:|\.)/g, '\\$1');
}




var Spinner = function () {
    this.Spin = function (waiting) {
        if (waiting == null)
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

//View
var View = function () {
    var self = this;

    this.Pagination = $("#pagination");
    this.Spinner = new Spinner();

    this.Spin = function (waiting) {
        self.Spinner.Spin(waiting);
    };
    this.StopSpin = function () {
        self.Spinner.StopSpin();
    };


    //pagination
    this.Paginate = function(pageNum, pageSize, totalItems, action) {
        self.Pagination.paging(totalItems, {
            format: "- (qq.) < nnncnnn > (.pp)",
            perpage: pageSize,
            lapping: 0,
            page: pageNum,
            onSelect: function(page) {
                if (pageNum != page) {
                    action(page);
                }
            },
            onFormat: function(type) {

                switch (type) {
                case 'left':
                    if (this.page > 5)
                        return '<em><a href="#' + this.value + '">' + this.value + '</a></em>';
                    return "";
                case 'right':
                    if (this.page < (this.pages - 5))
                        return '<em><a href="#' + this.value + '">' + this.value + '</a></em>';
                    return "";
                case 'block':
                    if (!this.active)
                        return '<span class="disabled"  title="Pagina ' + this.value + '">' + this.value + '</span>';
                    else if (this.value != this.page)
                        return '<em><a href="#' + this.value + '" title="Pagina ' + this.value + '">' + this.value + '</a></em>';
                    return '<span class="this-page">' + this.value + '</span>';
                case 'next':
                    if (this.active)
                        return '<a href="#' + this.value + '" class="next">></a>';
                    return '<span class="disabled">></span>';
                case 'prev':
                    if (this.active)
                        return '<a href="#' + this.value + '" class="prev"><</a>';
                    return '<span class="disabled"><</span>';
                case 'first':
                    if (this.active)
                        return '<a href="#' + this.value + '" class="first">First</a>';
                    return '<span class="disabled">First</span>';
                case 'last':
                    if (this.active)
                        return '<a href="#' + this.value + '" class="last">Last</a>';
                    return '<span class="disabled">Last</span>';
                case "leap":
                    if (this.active && (this.page > 5) && (this.page < (this.pages - 5)))
                        return '<span class="break">...</span>';
                    return "";
                case 'fill':
                    if (this.active)
                        return "Pages:&nbsp;";
                    return "";
                }
            }
        });
    };
};

//Repository
var Repository = function () {
    this.Post = function (url, command, success, error) {
        jQuery.ajaxSettings.traditional = true;
        $.ajax({
            type: 'Post',
            url: url,
            data: JSON.stringify(command),
            contentType: 'application/json; charset=utf-8',
            success: success,
            error: error,
            dataType: 'json'
        });
    };
};

var UrlFetchBuilder = function (url) {
    var self = this;
    this.Url = url;

    this.WithId = function (id) {
        self.Id = id;
        return self;
    };

    this.Build = function () {
        if (this.Id == null)
            throw "cannot fetch an entity with no Id";
        return self.Url + '/' + self.Id;
    };
}

var CommandBase = function (self, id, commitId, version) {
    if (id == null)
        throw "Id cannot be null";
    if (commitId == null)
        throw "commitId cannot be null";
    if (version == null)
        throw "Version cannot be null";


    self.Id = id;
    self.CommitId = commitId;
    self.Version = version;
};


var ShowSummaryError = function (divName, messages) {
    var errorMessage = document.getElementById(divName);
    var messageList = "";

    //    for (i = 0; i < messages.length; i++) {
        messageList += " - <b>" + messages.Title + "</b>, " + messages.Message + "<br />";
    //    }
    
    if (errorMessage != null) {
        errorMessage.innerHTML = "<br /><b>Oops!</b> There was a problem with your submission:<br /><br />";
        errorMessage.innerHTML += messageList;
        errorMessage.innerHTML += "<br />Please make the necessary corrections, and resubmit the form.<br />";
        errorMessage.className = "visible errormessage";
    }
};

var HideSummaryError = function (divName) {
    var errorMessage = document.getElementById(divName);
    errorMessage.className = "hidden errormessage";
}