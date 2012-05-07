
/* ---- Begin integration of Underscore template engine with Knockout. Could go in a separate file of course. ---- */
ko.underscoreTemplateEngine = function () { }
ko.underscoreTemplateEngine.prototype = ko.utils.extend(new ko.templateEngine(), {
    renderTemplateSource: function (templateSource, bindingContext, options) {
        // Precompile and cache the templates for efficiency
        var precompiled = templateSource['data']('precompiled');
        if (!precompiled) {
            precompiled = _.template("<% with($data) { %> " + templateSource.text() + " <% } %>");
            templateSource['data']('precompiled', precompiled);
        }
        // Run the template and parse its output into an array of DOM elements
        var renderedMarkup = precompiled(bindingContext).replace(/\s+/g, " ");
        return ko.utils.parseHtmlFragment(renderedMarkup);
    },
    createJavaScriptEvaluatorBlock: function (script) {
        return "<%= " + script + " %>";
    }
});
ko.setTemplateEngine(new ko.underscoreTemplateEngine());
/* ---- End integration of Underscore template engine with Knockout ---- */

/// <reference path="jquery-1.4.4.js" />
/// <reference path="jquery-ui.js" />
$(document).ready(function () {
    $('.date').datepicker({ dateFormat: "dd/mm/yy" });
});
