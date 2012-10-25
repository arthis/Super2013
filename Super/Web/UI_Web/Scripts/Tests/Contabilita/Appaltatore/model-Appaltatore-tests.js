/// <reference path="/Scripts/Super/Contabilita/Appaltatore/query-Appaltatore.js" />
/// <reference path="/Scripts/dateFormat.js" />
/// <reference path="/Scripts/jquery-1.8.0.min.js" />
/// <reference path="/Scripts/jquery-ui-1.8.23.custom.min.js" />
/// <reference path="/Scripts/underscore-1.3.1.js" />
/// <reference path="/Scripts/knockout-2.0.0rc.js" />
/// <reference path="/Scripts/knockout.mapping-latest.js" />
/// <reference path="/Scripts/EditorHookup.js" />
/// <reference path="/Scripts/json2.js" />
/// <reference path="/Scripts/jquery.paging.js" />
/// <reference path="/Scripts/functions.js" />
/// <reference path="/Scripts/functionsDetails.js" />
/// <reference path="/Scripts/uuid.js" />
/// <reference path="/Scripts/jquery.validationEngine.js" />
/// <reference path="/Scripts/jquery.validationEngine-it.js" />


describe("creating an Visualizzare Appaltatore query", function () {
    var pageNum = "12";
    var pageSize = "150";
    var description = "description";
    var query = new VisualizzareAppaltatore(description,pageNum, pageSize);
    it("should create an VisualizzareAppaltatore query", function () {
        expect(query).not.toBeNull();
    });
    it("with the correct values of appaltatore", function () {
        expect(query.PageNum).toEqual(pageNum);
        expect(query.PageSize).toEqual(pageSize);
        expect(query.Description).toEqual(description);
    });
});

