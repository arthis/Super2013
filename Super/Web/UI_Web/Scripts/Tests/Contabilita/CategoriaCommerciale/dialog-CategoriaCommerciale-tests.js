/// <reference path="/Scripts/Super/Contabilita/CategoriaCommerciale/dialog-CategoriaCommerciale.js" />
/// <reference path="/Scripts/Super/Contabilita/CategoriaCommerciale/cmd-CategoriaCommerciale.js" />
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


describe("creating an categoriaCommerciale dialog", function () {
    var urlCreateCategoriaCommerciale = "urlCreateCategoriaCommerciale";
    var urlFetchBuilderUpdateCategoriaCommerciale = new UrlBuilder("urlUpdateCategoriaCommerciale");
    var urlFetchBuilderDeleteCategoriaCommerciale = new UrlBuilder("urlDeleteCategoriaCommerciale");
    var dialEngine = new DialogEngine();
    
    var dialog = new DialogCategoriaCommerciale(dialEngine, urlCreateCategoriaCommerciale, urlFetchBuilderUpdateCategoriaCommerciale, urlFetchBuilderDeleteCategoriaCommerciale);
    it("should create an CategoriaCommerciale dialog", function () {
        expect(dialog).not.toBeNull();
    });
    it("with the correct values of categoriaCommerciale", function () {
        expect(dialog.DialogEngine).toEqual(dialEngine);
        expect(dialog.UrlCreateCategoriaCommerciale).toEqual(urlCreateCategoriaCommerciale);
        expect(dialog.UrlFetchBuilderUpdateCategoriaCommerciale).toEqual(urlFetchBuilderUpdateCategoriaCommerciale);
        expect(dialog.UrlFetchBuilderDeleteCategoriaCommerciale).toEqual(urlFetchBuilderDeleteCategoriaCommerciale);
    });
});

describe("Opening a dialog box for creatind categoriaCommerciale...", function () {
    var urlCreateCategoriaCommerciale, urlFetchBuilderUpdateCategoriaCommerciale, urlFetchBuilderDeleteCategoriaCommerciale, dialEngine, viewmodel, view, dialog = null;
    beforeEach(function() {
        urlCreateCategoriaCommerciale = "urlCreateCategoriaCommerciale";
        urlFetchBuilderUpdateCategoriaCommerciale = new UrlBuilder("urlUpdateCategoriaCommerciale");
        urlFetchBuilderDeleteCategoriaCommerciale = new UrlBuilder("urlDeleteCategoriaCommerciale");
        dialEngine = new DialogEngine();
        
        spyOn(dialEngine, 'OpenDetails');

        dialog = new DialogCategoriaCommerciale(dialEngine, urlCreateCategoriaCommerciale, urlFetchBuilderUpdateCategoriaCommerciale, urlFetchBuilderDeleteCategoriaCommerciale);
        dialog.ShowCreateCategoriaCommerciale(viewmodel, view);
    });


    it("should call the create categoriaCommerciale with the right url ", function () {
        expect(dialEngine.OpenDetails).toHaveBeenCalledWith(viewmodel, view, urlCreateCategoriaCommerciale, 'Create Categoria Commerciale');
    });
});

describe("Opening a dialog box for updating categoriaCommerciale", function () {
    var urlCreateCategoriaCommerciale, urlFetchBuilderUpdateCategoriaCommerciale, urlFetchBuilderDeleteCategoriaCommerciale, dialEngine, viewmodel, view, dialog, id = null;
    beforeEach(function () {
        urlCreateCategoriaCommerciale = "urlCreateCategoriaCommerciale";
        urlFetchBuilderUpdateCategoriaCommerciale = new UrlBuilder('urlUpdateCategoriaCommerciale');
        urlFetchBuilderDeleteCategoriaCommerciale = new UrlBuilder('urlDeleteCategoriaCommerciale');
        dialEngine = new DialogEngine();
        id = '2';
        
        spyOn(dialEngine, 'OpenDetails');

        dialog = new DialogCategoriaCommerciale(dialEngine, urlCreateCategoriaCommerciale, urlFetchBuilderUpdateCategoriaCommerciale, urlFetchBuilderDeleteCategoriaCommerciale);
        dialog.ShowUpdateCategoriaCommerciale(id, viewmodel, view);
    });
    
    it("should call the udpate categoriaCommerciale with the right url ", function () {
        expect(dialEngine.OpenDetails).toHaveBeenCalledWith(viewmodel, view, 'urlUpdateCategoriaCommerciale/2', 'Edit Categoria Commerciale');
    });
});

describe("Opening a dialog box for deleting categoriaCommerciale", function () {
    var urlCreateCategoriaCommerciale, urlFetchBuilderUpdateCategoriaCommerciale, urlFetchBuilderDeleteCategoriaCommerciale, dialEngine, viewmodel, view, dialog, id = null;
    beforeEach(function () {
        urlCreateCategoriaCommerciale = "urlCreateCategoriaCommerciale";
        urlFetchBuilderUpdateCategoriaCommerciale = new UrlBuilder("urlUpdateCategoriaCommerciale");
        urlFetchBuilderDeleteCategoriaCommerciale = new UrlBuilder("urlDeleteCategoriaCommerciale");
        dialEngine = new DialogEngine();
        id = 2;

        spyOn(dialEngine, 'OpenDetails');

        dialog = new DialogCategoriaCommerciale(dialEngine, urlCreateCategoriaCommerciale, urlFetchBuilderUpdateCategoriaCommerciale, urlFetchBuilderDeleteCategoriaCommerciale);
        dialog.ShowDeleteCategoriaCommerciale(id, viewmodel, view);
    });

    it("should call the delete categoriaCommerciale with the right url ", function () {
        expect(dialEngine.OpenDetails).toHaveBeenCalledWith(viewmodel, view, 'urlDeleteCategoriaCommerciale/2', 'Delete Categoria Commerciale');
    });
});
