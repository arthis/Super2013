/// <reference path="/Scripts/Super/Contabilita/CategoriaCommerciale/repository-CategoriaCommerciale.js" />
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


describe("creating an categoriaCommerciale repository", function () {
    var urlGetItems = 'urlGetItems';
    var urlCreateCategoriaCommerciale = 'urlCreateCategoriaCommerciale';
    var urlUpdateCategoriaCommerciale = 'urlUpdateCategoriaCommerciale';
    var urlDeleteCategoriaCommerciale = "urlDeleteCategoriaCommerciale";
    var engine = new RepositoryEngine();
    var repository = new RepositoryCategoriaCommerciale(engine, urlGetItems, urlCreateCategoriaCommerciale, urlUpdateCategoriaCommerciale, urlDeleteCategoriaCommerciale);
    
    
    it("should create an CategoriaCommerciale repository", function () {
        expect(repository).not.toBeNull();
    });
    it("with the correct values of repository categoriaCommerciale", function () {
        expect(repository.RepositoryEngine).toEqual(engine);
    });
});
