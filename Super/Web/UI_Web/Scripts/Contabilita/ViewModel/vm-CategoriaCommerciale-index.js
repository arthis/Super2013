//Model
var CategoriaCommerciale = function (id, version, creationDate,  description) {
    this.Id = ko.observable(id);
    this.CreationDate = ko.observable(creationDate.format("dd/mm/yyyy HH:MM"));
    this.Description = ko.observable(description);
    this.Version = version;
}

//ViewModel
var vmStuff = function (pageNum, pageSize,
    urlGetItems,
    urlCreateCategoriaCommerciale,
    urlFetchBuilderEditCategoriaCommerciale,
    urlFetchBuilderDeleteCategoriaCommerciale) {

    var self = this;
    this.Repository = new Repository();
    this.View = new View();

    //filtro
    this.Description = ko.observable();
    this.PageNum = ko.observable(pageNum);
    this.PageSize = ko.observable(pageSize);

    this.Items = ko.mapping.fromJS([]);

    this.ShowCreateCategoriaCommerciale = function (item) {
        self.OpenDetails(urlCreateCategoriaCommerciale, 'Create categoria commerciale');
    };

    this.CreateCategoriaCommerciale = function (url, command) {
        self.View.Spin({ title: "Please Wait", message: "creating categoria commerciale..." });
        self.Repository.Post(url, command, self.AcceptSuccess, self.AcceptError);
    };

    this.ShowEditCategoriaCommerciale = function (item) {
        self.OpenDetails(urlFetchBuilderEditCategoriaCommerciale.WithId(item.Id()).Build(), 'Edit categoria commerciale');
    };

    this.UpdateCategoriaCommerciale = function (url, command) {
        self.View.Spin({ title: "Please Wait", message: "updating categoria commerciale..." });
        self.Repository.Post(url, command, self.AcceptSuccess, self.AcceptError);
    };

    this.ShowDeleteCategoriaCommerciale = function (item) {
        self.OpenDetails(urlFetchBuilderDeleteCategoriaCommerciale.WithId(item.Id()).Build(), 'Delete CategoriaCommerciale');
    };

    this.DeleteCategoriaCommerciale = function (url, command) {
        self.View.Spin({ title: "Please Wait", message: "deleting categoria commerciale..." });
        self.Repository.Post(url, command, self.AcceptSuccess, self.AcceptError);
    };

    this.GetItems = function (pageNum) {
        self.View.Spin({ title: "Please Wait", message: "Loading data..." });
        if (pageNum == null)
            self.PageNum(1);
        else
            self.PageNum(pageNum);
        var command = new FilterCategoriaCommerciale(self.Description(), self.PageNum(), self.PageSize());
        self.Repository.Post(urlGetItems, command, self.GetItemsSuccess, self.GetItemsError);
    };

    this.GetItemsSuccess = function (items) {
        self.Items.removeAll();
        ko.utils.arrayForEach(items.results, function (item) {
            self.Items.push(new CategoriaCommerciale(item.Id, item.Version, ToDate(item.CreationDate), item.Description));
        });
        self.View.Paginate(self.PageNum(), self.PageSize(), items.count, self.GetItems);
        self.View.StopSpin();
    };

    this.GetItemsError = function () {
        self.View.StopSpin();
        alert('error while fetching data');
    };


    //dialog
    this.OpenDetails = function (url, title) {

        $('#details').dialog({
            autoOpen: false,
            width: 350,
            height: 400,
            position: 'center',
            resizable: true,
            title: title,
            modal: true,
            open: function (event, ui) {
                self.View.Spin({ title: "Please Wait", message: "openng data..." });
                $(this).load(url);
                self.View.StopSpin();
            },
            buttons: {
                "Accept": function () {
                    self.Accept(self);
                },
                "Cancel": function () {
                    if (self.Cancel(self))
                        self.CloseDetails();
                }
            }
        });
        $('#details').dialog("open");
    };

    this.CloseDetails = function () {
        $('#details').dialog("close");
    };

    this.AcceptSuccess = function (items) {
        if (items != null) {
            ShowSummaryError("error_mssg", items.validations);
        } else {
            HideSummaryError("error_mssg");
            setTimeout(function () { self.GetItems(viewModel.PageNum()) }, 1250);
            self.CloseDetails();
        }
        self.View.StopSpin();
    };

    this.AcceptError = function (cmd) {
        self.View.StopSpin();

        alert("error");
    };

    this.Cancel = function (cmd) {
        //do something useful here
        return true;
    };


}