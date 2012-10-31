
var DialogCategoriaCommerciale = function (
    dialEngine,
    urlCreateCategoriaCommerciale,
    urlFetchBuilderUpdateCategoriaCommerciale,
    urlFetchBuilderDeleteCategoriaCommerciale) {
    var self = this;
    this.UrlCreateCategoriaCommerciale = urlCreateCategoriaCommerciale;
    this.UrlFetchBuilderUpdateCategoriaCommerciale = urlFetchBuilderUpdateCategoriaCommerciale;
    this.UrlFetchBuilderDeleteCategoriaCommerciale = urlFetchBuilderDeleteCategoriaCommerciale;
    this.DialogEngine = dialEngine;

    this.ShowCreateCategoriaCommerciale = function (viewmodel, view) {
        self.DialogEngine.OpenDetails(viewmodel, view, self.UrlCreateCategoriaCommerciale, 'Create Categoria Commerciale');
    };

    this.ShowUpdateCategoriaCommerciale = function (id, viewmodel, view) {
        self.DialogEngine.OpenDetails(viewmodel, view, self.UrlFetchBuilderUpdateCategoriaCommerciale.WithId(id).Build(), 'Edit Categoria Commerciale');
    };

    this.ShowDeleteCategoriaCommerciale = function (id, viewmodel, view) {
        self.DialogEngine.OpenDetails(viewmodel, view, self.UrlFetchBuilderDeleteCategoriaCommerciale.WithId(id).Build(), 'Delete Categoria Commerciale');
    };
    this.CloseDetails = function () {
        self.DialogEngine.CloseDetails();
    };
    
};
