/// <reference path="/Scripts/Super/Contabilita/CategoriaCommerciale/vm-CategoriaCommerciale-index.js" />
/// <reference path="/Scripts/Super/Contabilita/CategoriaCommerciale/model-CategoriaCommerciale.js" />
/// <reference path="/Scripts/Super/Contabilita/CategoriaCommerciale/repository-CategoriaCommerciale.js" />
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


describe("creating an categoria commerciale viewmodel ", function () {

    var view, repository, dialog, viewModel = null;
    beforeEach(function () {
        view = new View();
        repository = new RepositoryCategoriaCommerciale(null, null, null, null, null, null);
        dialog = new DialogCategoriaCommerciale(null, null, null, null);

        viewModel = new vmCategoriaCommerciale(view, repository, dialog, 1, 10);
    });

    it("should create a viewmodel categoria commerciale", function () {
        expect(viewModel).not.toBeNull();
    });
    it("with the correct values of viewmodel categoria commerciale", function () {
        expect(viewModel.PageNum()).toEqual(1);
        expect(viewModel.PageSize()).toEqual(10);
        expect(viewModel.Dialog).not.toBeNull();
        expect(viewModel.Repository).not.toBeNull();
        expect(viewModel.View).not.toBeNull();
    });
});



describe("When the viewmodel shows CreateCategoriaCommerciale", function () {

    var viewModel, view, repository, dialog = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryCategoriaCommerciale(null, null, null, null, null);
        dialog = new DialogCategoriaCommerciale(null, null, null);


        spyOn(dialog, 'ShowCreateCategoriaCommerciale');

        viewModel = new vmCategoriaCommerciale(view, repository, dialog, 1, 10);
        viewModel.ShowCreateCategoriaCommerciale();

    });

    it("the dialog calls createCategoriaCommerciale", function () {
        expect(dialog.ShowCreateCategoriaCommerciale).toHaveBeenCalled();
    });
});

describe("When the viewmodel shows UpdateCategoriaCommerciale", function () {

    var viewModel, view, repository, dialog, item = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryCategoriaCommerciale(null, null, null, null, null);
        dialog = new DialogCategoriaCommerciale(null, null, null);
        item = new CategoriaCommerciale('id', 'version', new Date(), 'description');

        spyOn(dialog, 'ShowUpdateCategoriaCommerciale');

        viewModel = new vmCategoriaCommerciale(view, repository, dialog, 1, 10);
        viewModel.ShowUpdateCategoriaCommerciale(item);

    });

    it("the dialog calls updateCategoriaCommerciale", function () {
        expect(dialog.ShowUpdateCategoriaCommerciale).toHaveBeenCalled();
    });
});

describe("When the viewmodel shows deleteCategoriaCommerciale", function () {

    var viewModel, view, repository, dialog, item = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryCategoriaCommerciale(null, null, null, null, null);
        dialog = new DialogCategoriaCommerciale(null, null, null);
        item = new CategoriaCommerciale('id', 'version', new Date(), 'description');

        spyOn(dialog, 'ShowDeleteCategoriaCommerciale');

        viewModel = new vmCategoriaCommerciale(view, repository, dialog, 1, 10);
        viewModel.ShowDeleteCategoriaCommerciale(item);

    });

    it("the dialog calls deleteCategoriaCommerciale", function () {
        expect(dialog.ShowDeleteCategoriaCommerciale).toHaveBeenCalled();
    });
});

describe("When the viewmodel creates an CategoriaCommerciale", function () {

    var viewModel, view, repository, dialog, command = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryCategoriaCommerciale(null, null, null, null, null);
        dialog = new DialogCategoriaCommerciale(null, null, null);


        spyOn(repository, 'createCategoriaCommerciale');
        spyOn(view, 'Spin');

        viewModel = new vmCategoriaCommerciale(view, repository, dialog, 1, 10);
        viewModel.CreateCategoriaCommerciale(command);

    });

    it("the repository calls createCategoriaCommerciale", function () {
        expect(repository.createCategoriaCommerciale).toHaveBeenCalled();
    });
    it("the message wait arrives for creating categoria commerciale", function () {
        expect(view.Spin).toHaveBeenCalled();
    });
});

describe("When the viewmodel updates an CategoriaCommerciale", function () {

    var viewModel, view, repository, dialog, command = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryCategoriaCommerciale(null, null, null, null, null);
        dialog = new DialogCategoriaCommerciale(null, null, null);


        spyOn(repository, 'updateCategoriaCommerciale');
        spyOn(view, 'Spin');

        viewModel = new vmCategoriaCommerciale(view, repository, dialog, 1, 10);
        viewModel.UpdateCategoriaCommerciale(command);

    });

    it("the repository calls updateCategoriaCommerciale", function () {
        expect(repository.updateCategoriaCommerciale).toHaveBeenCalled();
    });
    it("the message wait arrives for updating categoria commerciale", function () {
        expect(view.Spin).toHaveBeenCalled();
    });
});

describe("When the viewmodel deletes an CategoriaCommerciale", function () {

    var viewModel, view, repository, dialog, command = null;


    beforeEach(function () {
        view = new View();
        repository = new RepositoryCategoriaCommerciale(null, null, null, null, null);
        dialog = new DialogCategoriaCommerciale(null, null, null);


        spyOn(repository, 'deleteCategoriaCommerciale');
        spyOn(view, 'Spin');

        viewModel = new vmCategoriaCommerciale(view, repository, dialog, 1, 10);
        viewModel.DeleteCategoriaCommerciale(command);

    });

    it("the repository calls deleteCategoriaCommerciale", function () {
        expect(repository.deleteCategoriaCommerciale).toHaveBeenCalled();
    });
    it("the message wait arrives for deleting categoria commerciale", function () {
        expect(view.Spin).toHaveBeenCalled();
    });
});



