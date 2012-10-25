/// <reference path="/Scripts/Super/Contabilita/Appaltatore/dialog-Appaltatore.js" />
/// <reference path="/Scripts/Super/Contabilita/Appaltatore/cmd-Appaltatore.js" />
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


describe("creating an appaltatore dialog", function () {
    var urlCreateAppaltatore = "urlCreateAppaltatore";
    var urlFetchBuilderUpdateAppaltatore = new UrlBuilder("urlUpdateAppaltatore");
    var urlFetchBuilderDeleteAppaltatore = new UrlBuilder("urlDeleteAppaltatore");
    var dialEngine = new DialogEngine();
    
    var dialog = new DialogAppaltatore(dialEngine, urlCreateAppaltatore, urlFetchBuilderUpdateAppaltatore, urlFetchBuilderDeleteAppaltatore);
    it("should create an Appaltatore dialog", function () {
        expect(dialog).not.toBeNull();
    });
    it("with the correct values of appaltatore", function () {
        expect(dialog.DialogEngine).toEqual(dialEngine);
        expect(dialog.UrlCreateAppaltatore).toEqual(urlCreateAppaltatore);
        expect(dialog.UrlFetchBuilderUpdateAppaltatore).toEqual(urlFetchBuilderUpdateAppaltatore);
        expect(dialog.UrlFetchBuilderDeleteAppaltatore).toEqual(urlFetchBuilderDeleteAppaltatore);
    });
});

describe("Opening a dialog box for creatind appaltatore...", function () {
    var urlCreateAppaltatore, urlFetchBuilderUpdateAppaltaore, urlFetchBuilderDeleteAppaltatore, dialEngine, viewmodel, view, dialog = null;
    beforeEach(function() {
        urlCreateAppaltatore = "urlCreateAppaltatore";
        urlFetchBuilderUpdateAppaltatore = new UrlBuilder("urlUpdateAppaltatore");
        urlFetchBuilderDeleteAppaltatore = new UrlBuilder("urlDeleteAppaltatore");
        dialEngine = new DialogEngine();
        
        spyOn(dialEngine, 'OpenDetails');

        dialog = new DialogAppaltatore(dialEngine, urlCreateAppaltatore, urlFetchBuilderUpdateAppaltatore, urlFetchBuilderDeleteAppaltatore);
        dialog.ShowCreateAppaltatore(viewmodel, view);
    });


    it("should call the create appaltatore with the right url ", function () {
        expect(dialEngine.OpenDetails).toHaveBeenCalledWith(viewmodel, view, urlCreateAppaltatore, 'Create Appaltatore');
    });
});

describe("Opening a dialog box for updating appaltatore", function () {
    var urlCreateAppaltatore, urlFetchBuilderUpdateAppaltatore, urlFetchBuilderDeleteAppaltatore, dialEngine, viewmodel, view, dialog, id = null;
    beforeEach(function () {
        urlCreateAppaltatore = "urlCreateAppaltatore";
        urlFetchBuilderUpdateAppaltatore = new UrlBuilder('urlUpdateAppaltatore');
        urlFetchBuilderDeleteAppaltatore = new UrlBuilder('urlDeleteAppaltatore');
        dialEngine = new DialogEngine();
        id = '2';
        
        spyOn(dialEngine, 'OpenDetails');

        dialog = new DialogAppaltatore(dialEngine, urlCreateAppaltatore, urlFetchBuilderUpdateAppaltatore, urlFetchBuilderDeleteAppaltatore);
        dialog.ShowUpdateAppaltatore(id, viewmodel, view);
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
        dialog.ShowDeleteAppaltatore(id, viewmodel, view);
    });

    it("should call the delete appaltatore with the right url ", function () {
        expect(dialEngine.OpenDetails).toHaveBeenCalledWith(viewmodel, view, 'urlDeleteAppaltatore/2', 'Delete Appaltatore');
    });
});
