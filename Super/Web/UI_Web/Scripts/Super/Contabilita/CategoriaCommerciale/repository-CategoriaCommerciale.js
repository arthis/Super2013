var RepositoryCategoriaCommerciale = function (repositoryEngine,
    urlGetItems,
    urlCreateCategoriaCommerciale,
    urlUpdateCategoriaCommerciale,
    urlDeleteCategoriaCommerciale) {
    this.RepositoryEngine = repositoryEngine;


    this.getItems = function (command, success, error) {
        repositoryEngine.Post(urlGetItems, command, success, error);
    };

    this.createCategoriaCommerciale = function (command, success, error) {
        repositoryEngine.Post(urlCreateCategoriaCommerciale, command, success, error);
    };

    this.updateCategoriaCommerciale = function (command, success, error) {
        repositoryEngine.Post(urlUpdateCategoriaCommerciale, command, success, error);
    };

    this.deleteCategoriaCommerciale = function (command, success, error) {
        repositoryEngine.Post(urlDeleteCategoriaCommerciale, command, success, error);
    };
};
