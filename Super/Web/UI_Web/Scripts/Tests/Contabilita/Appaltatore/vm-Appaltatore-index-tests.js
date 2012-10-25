/// <reference path="/Scripts/Super/Contabilita/Appaltatore/vm-Appaltatore-index.js" />
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



describe("creating an appaltatore viewmodel ", function () {
    var view = new View();
    var repository = new RepositoryAppaltatore(null,null,null,null,null);
    var dialog = DialogAppaltatore(null,null,null);
    
    var viewModel = new vmAppaltatore(view, repository, dialog, 1,10);
    it("should create a viewmodel", function () {
        expect(viewModel).not.toBeNull();
    });
    it("with the correct values of viewmodel", function () {
        expect(viewModel.PageNum()).toEqual(1);
        expect(viewModel.PageSize()).toEqual(10);
        expect(viewModel.Dialog).not.toBeNull();
        expect(viewModel.Repository).not.toBeNull();
        expect(viewModel.View).not.toBeNull();
    });
});

describe("When the viewmodel shows CreateAppaltatore", function () {

    var viewModel, view, repository, dialog = null;
    

    beforeEach(function () {
        view = new View();
        repository = new RepositoryAppaltatore(null, null, null, null, null);
        dialog = new DialogAppaltatore(null, null, null);
       

        spyOn(dialog, 'ShowCreateAppaltatore');

        viewModel = new vmAppaltatore(view,repository,dialog,1,10);
        viewModel.ShowCreateAppaltatore();
        
    });

    it("the dialog calls createAppaltatore", function () {
        expect(dialog.ShowCreateAppaltatore).toHaveBeenCalled();
    });
});

describe("When the viewmodel shows UpdateAppaltatore", function () {

    var viewModel, view, repository, dialog, item = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryAppaltatore(null, null, null, null, null);
        dialog = new DialogAppaltatore(null, null, null);
        item = new Appaltatore('id', 'version', new Date(), 'description');

        spyOn(dialog, 'ShowUpdateAppaltatore');

        viewModel = new vmAppaltatore(view, repository, dialog, 1, 10);
        viewModel.ShowUpdateAppaltatore(item);

    });

    it("the dialog calls updateAppaltatore", function () {
        expect(dialog.ShowUpdateAppaltatore).toHaveBeenCalled();
    });
});

describe("When the viewmodel shows deleteAppaltatore", function () {

    var viewModel, view, repository, dialog, item = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryAppaltatore(null, null, null, null, null);
        dialog = new DialogAppaltatore(null, null, null);
        item = new Appaltatore('id', 'version', new Date(), 'description');

        spyOn(dialog, 'ShowDeleteAppaltatore');

        viewModel = new vmAppaltatore(view, repository, dialog, 1, 10);
        viewModel.ShowDeleteAppaltatore(item);

    });

    it("the dialog calls deleteAppaltatore", function () {
        expect(dialog.ShowDeleteAppaltatore).toHaveBeenCalled();
    });
});

describe("When the viewmodel creates an Appaltatore", function () {

    var viewModel, view, repository, dialog, command = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryAppaltatore(null, null, null, null, null);
        dialog = new DialogAppaltatore(null, null, null);
        

        spyOn(repository, 'createAppaltatore');
        spyOn(view, 'Spin');

        viewModel = new vmAppaltatore(view, repository, dialog, 1, 10);
        viewModel.CreateAppaltatore(command);

    });

    it("the repository calls createAppaltatore", function () {    
        expect(repository.createAppaltatore).toHaveBeenCalled();
    });
    it("the message wait arrives for creating", function () {    
        expect(view.Spin).toHaveBeenCalled();
    });
});

describe("When the viewmodel updates an Appaltatore", function () {

    var viewModel, view, repository, dialog, command = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryAppaltatore(null, null, null, null, null);
        dialog = new DialogAppaltatore(null, null, null);


        spyOn(repository, 'updateAppaltatore');
        spyOn(view, 'Spin');

        viewModel = new vmAppaltatore(view, repository, dialog, 1, 10);
        viewModel.UpdateAppaltatore(command);

    });

    it("the repository calls updateAppaltatore", function () {
        expect(repository.updateAppaltatore).toHaveBeenCalled();
    });
    it("the message wait arrives for updating", function () {
        expect(view.Spin).toHaveBeenCalled();
    });
});

describe("When the viewmodel deletes an Appaltatore", function () {

    var viewModel, view, repository, dialog, command = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryAppaltatore(null, null, null, null, null);
        dialog = new DialogAppaltatore(null, null, null);


        spyOn(repository, 'deleteAppaltatore');
        spyOn(view, 'Spin');

        viewModel = new vmAppaltatore(view, repository, dialog, 1, 10);
        viewModel.DeleteAppaltatore(command);

    });

    it("the repository calls deleteAppaltatore", function () {
        expect(repository.deleteAppaltatore).toHaveBeenCalled();
    });
    it("the message wait arrives for deleting", function () {
        expect(view.Spin).toHaveBeenCalled();
    });
});


