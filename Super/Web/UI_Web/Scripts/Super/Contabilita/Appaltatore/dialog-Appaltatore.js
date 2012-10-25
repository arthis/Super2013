
var DialogAppaltatore = function (
    dialEngine,
    urlCreateAppaltatore,
    urlFetchBuilderUpdateAppaltatore,
    urlFetchBuilderDeleteAppaltatore) {
    var self = this;
    this.UrlCreateAppaltatore = urlCreateAppaltatore;
    this.UrlFetchBuilderUpdateAppaltatore = urlFetchBuilderUpdateAppaltatore;
    this.UrlFetchBuilderDeleteAppaltatore = urlFetchBuilderDeleteAppaltatore;
    this.DialogEngine = dialEngine;

    this.ShowCreateAppaltatore = function (viewmodel, view) {
        self.DialogEngine.OpenDetails(viewmodel, view, self.UrlCreateAppaltatore, 'Create Appaltatore');
    };

    this.ShowUpdateAppaltatore = function (id, viewmodel, view) {
        self.DialogEngine.OpenDetails(viewmodel, view, self.UrlFetchBuilderUpdateAppaltatore.WithId(id).Build(), 'Edit Appaltatore');
    };

    this.ShowDeleteAppaltatore = function (id, viewmodel, view) {
        self.DialogEngine.OpenDetails(viewmodel, view, self.UrlFetchBuilderDeleteAppaltatore.WithId(id).Build(), 'Delete Appaltatore');
    };
    this.CloseDetails = function () {
        self.DialogEngine.CloseDetails();
    };
    
};
