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



describe("using url builder ", function () {
    var urlBuilder, url, id = null;
    beforeEach(function () {
        url = 'test';
        id = 2;
        urlBuilder = new UrlBuilder(url);

    });


    it("should gives the right url ", function () {
        expect(urlBuilder.WithId(id).Build()).toBe('test/2');
    });
});

describe("Opening a dialog box for updating appaltatore", function () {
    var urlCreateAppaltatore, urlFetchBuilderUpdateAppaltatore, urlFetchBuilderDeleteAppaltatore, dialEngine, viewmodel, view, dialog, id = null;
    beforeEach(function () {
        urlCreateAppaltatore = "urlCreateAppaltatore";
        urlFetchBuilderUpdateAppaltatore = new UrlBuilder("urlUpdateAppaltatore");
        urlFetchBuilderDeleteAppaltatore = new UrlBuilder("urlDeleteAppaltatore");
        dialEngine = new DialogEngine();
        id = '2';
        
        spyOn(dialEngine, 'OpenDetails');

        dialog = new DialogAppaltatore(dialEngine, urlCreateAppaltatore, urlFetchBuilderUpdateAppaltatore, urlFetchBuilderDeleteAppaltatore);
        dialog.ShowUpdateAppaltatore(viewmodel, view);
    });

    it("should call the udpate appaltatore with the right url ", function () {
        expect(dialEngine.OpenDetails).toHaveBeenCalledWith(viewmodel, view, 'urlUpdateAppaltatore/2', 'Edit Appaltatore');
    });
});

describe("Opening a dialog box for deleting appaltatore", function () {
    var urlCreateAppaltatore, urlFetchBuilderUpdateAppaltatore, urlFetchBuilderDeleteAppaltatore, dialEngine, viewmodel, view, dialog, id = null;
    beforeEach(function () {
        urlCreateAppaltatore = "urlCreateAppaltatore";
        urlFetchBuilderUpdateAppaltatore = new UrlBuilder("urlUpdateAppaltatore");
        urlFetchBuilderDeleteAppaltatore = new UrlBuilder("urlDeleteAppaltatore");
        dialEngine = new DialogEngine();
        id = 2;

        spyOn(dialEngine, 'OpenDetails');

        dialog = new DialogAppaltatore(dialEngine, urlCreateAppaltatore, urlFetchBuilderUpdateAppaltatore, urlFetchBuilderDeleteAppaltatore);
        dialog.ShowDeleteAppaltatore(viewmodel, view);
    });

    it("should call the delete appaltatore with the right url ", function () {
        expect(dialEngine.OpenDetails).toHaveBeenCalledWith(viewmodel, view, 'urlDeleteAppaltatore/2', 'Delete Appaltatore');
    });
});
