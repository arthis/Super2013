//Model
var Appaltatore = function(id, version, creationDate, description) {
    this.Id = ko.observable(id);
    this.CreationDate = ko.observable(creationDate.format("dd/mm/yyyy HH:MM"));
    this.Description = ko.observable(description);
    this.Version = version;
};

//var AppaltatoreTest = function (id, version, creationDate, description) {
//    this.Id = ko.observable(id);
//    this.CreationDate = ko.observable(creationDate.format("dd/mm/yyyy HH:MM"));
//    this.Description = ko.observable(description);
//    this.Version = version;
//};
var vmAppaltatoreTest = function () {
    this.myFunction = function() { alert('toto'); };
};

var myDependency = function() {
    this.myfunctionDep = function() { alert('sdsds'); };
};

var myModel = function (dep) {
    var self = this;
    this.Dependency = dep;
    
    this.myFunction = function () { self.Dependency.myfunctionDep(); };
};

//ViewModel
var vmAppaltatore = function(
    view,
    repository,
    dialog,
    pageNum, pageSize
) {

    var self = this;
    this.Repository = repository;
    this.View = view;
    this.Dialog = dialog;

    //filtro
    this.Description = ko.observable();
    this.PageNum = ko.observable(pageNum);
    this.PageSize = ko.observable(pageSize);

    this.Items = ko.mapping.fromJS([]);

    this.ShowCreateAppaltatore = function() {
        self.Dialog.ShowCreateAppaltatore(self, self.View);
    };

    this.CreateAppaltatore = function(command) {
        self.View.Spin({ title: "Please Wait", message: "creating appaltatore..." });
        self.Repository.createAppaltatore(command, self.AcceptSuccess, self.AcceptError);
    };

    this.ShowUpdateAppaltatore = function(item) {
        self.Dialog.ShowUpdateAppaltatore(item.Id(), self, self.View);
    };

    this.UpdateAppaltatore = function(url, command) {
        self.View.Spin({ title: "Please Wait", message: "updating appaltatore..." });
        self.Repository.updateAppaltatore(command, self.AcceptSuccess, self.AcceptError);
    };

    this.ShowDeleteAppaltatore = function(item) {
        self.Dialog.ShowDeleteAppaltatore(item.Id(), self, self.View);
    };

    this.DeleteAppaltatore = function(url, command) {
        self.View.Spin({ title: "Please Wait", message: "deleting appaltatore..." });
        self.Repository.deleteAppaltatore(command, self.AcceptSuccess, self.AcceptError);
    };

    this.GetItems = function(pageNum) {
        self.View.Spin({ title: "Please Wait", message: "Loading data..." });
        if (pageNum == null)
            self.PageNum(1);
        else
            self.PageNum(pageNum);
        var command = new VisualizzareAppaltatore(self.Description(), self.PageNum(), self.PageSize());
        self.Repository.getItems(command, self.GetItemsSuccess, self.GetItemsError);
    };

    this.GetItemsSuccess = function(items) {
        self.Items.removeAll();
        ko.utils.arrayForEach(items.results, function(item) {
            self.Items.push(new Appaltatore(item.Id, item.Version, ToDate(item.CreationDate), item.Description));
        });
        self.View.Paginate(self.PageNum(), self.PageSize(), items.count, self.GetItems);
        self.View.StopSpin();
    };

    this.GetItemsError = function() {
        self.View.StopSpin();
        alert('error while fetching data');
    };


    this.AcceptSuccess = function(items) {
        if (items != null) {
            ShowSummaryError("error_mssg", items.validations);
        } else {
            HideSummaryError("error_mssg");
            setTimeout(function() { self.GetItems(viewModel.PageNum()) }, 1250);
            self.Dialog.CloseDetails();
        }
        self.View.StopSpin();
    };

    this.AcceptError = function(cmd) {
        self.View.StopSpin();

        alert("error");
    };

    this.Cancel = function() {
        //do something useful here
        return true;
    };


};



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

var DialogAppaltatore = function(
    urlCreateAppaltatore,
    urlFetchBuilderUpdateAppaltatore,
    urlFetchBuilderDeleteAppaltatore) {
    var self = this;
    this.UrlCreateAppaltatore = urlCreateAppaltatore;
    this.UrlFetchBuilderUpdateAppaltatore = urlFetchBuilderUpdateAppaltatore;
    this.UrlFetchBuilderDeleteAppaltatore = urlFetchBuilderDeleteAppaltatore;

    this.ShowCreateAppaltatore = function(viewmodel,view) {
        self.OpenDetails(viewmodel, view, self.UrlCreateAppaltatore, 'Create Appaltatore');
    };

    this.ShowUpdateAppaltatore = function (id, viewmodel, view) {
        self.OpenDetails(viewmodel, view, self.UrlFetchBuilderUpdateAppaltatore.WithId(id).Build(), 'Edit Appaltatore');
    };

    this.ShowDeleteAppaltatore = function (id, viewmodel, view) {
        self.OpenDetails(viewmodel, view, self.UrlFetchBuilderDeleteAppaltatore.WithId(id).Build(), 'Delete Appaltatore');
    };

    //dialog
    this.OpenDetails = function(viewmodel, view, url, title) {
        var self = this;
        this.ViewModel = viewmodel;
        this.View = view;
        this.Url = url;
        this.Title = title;

        $('#details').dialog({
            autoOpen: false,
            width: 350,
            height: 400,
            position: 'center',
            resizable: true,
            title: title,
            modal: true,
            open: function(event, ui) {
                self.View.Spin({ title: "Please Wait", message: "openng data..." });
                $(this).load(self.Url);
                self.View.StopSpin();
            },
            buttons: {
                "Accept": function() {
                    self.ViewModel.Accept(self.ViewModel);
                },
                "Cancel": function() {
                    if (self.ViewModel.Cancel())
                        self.CloseDetails();
                }
            }
        });
        $('#details').dialog("open");
    };
    this.CloseDetails = function() {
        $('#details').dialog("close");
    };
};

