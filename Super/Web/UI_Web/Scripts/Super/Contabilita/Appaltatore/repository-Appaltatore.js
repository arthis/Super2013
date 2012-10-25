var RepositoryAppaltatore = function (repositoryEngine,
    urlGetItems,
    urlCreateAppaltatore,
    urlUpdateAppaltatore,
    urlDeleteAppaltatore) {
    this.RepositoryEngine = repositoryEngine;


    this.getItems = function (command, success, error) {
        repositoryEngine.Post(urlGetItems, command, success, error);
    };

    this.createAppaltatore = function (command, success, error) {
        repositoryEngine.Post(urlCreateAppaltatore, command, success, error);
    };

    this.updateAppaltatore = function (command, success, error) {
        repositoryEngine.Post(urlUpdateAppaltatore, command, success, error);
    };

    this.deleteAppaltatore = function (command, success, error) {
        repositoryEngine.Post(urlDeleteAppaltatore, command, success, error);
    };
};
