/// <reference path="/Scripts/Super/Contabilita/Appaltatore/repository-Appaltatore.js" />
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


describe("creating an appaltatore repository", function () {
    var urlGetItems = 'urlGetItems';
    var urlCreateAppaltatore = 'urlCreateAppaltatore';
    var urlUpdateAppaltatore = 'urlUpdateAppaltatore';
    var urlDeleteAppaltatore = "urlDeleteAppaltatore";
    var engine = new RepositoryEngine();
    var repository = new RepositoryAppaltatore(engine, urlGetItems, urlCreateAppaltatore, urlUpdateAppaltatore, urlDeleteAppaltatore);
    
    
    it("should create an Appaltatore repository", function () {
        expect(repository).not.toBeNull();
    });
    it("with the correct values of repository appaltatore", function () {
        expect(repository.RepositoryEngine).toEqual(engine);
    });
});
