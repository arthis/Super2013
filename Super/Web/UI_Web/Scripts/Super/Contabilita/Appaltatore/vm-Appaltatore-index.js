


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

    this.UpdateAppaltatore = function(command) {
        self.View.Spin({ title: "Please Wait", message: "updating appaltatore..." });
        self.Repository.updateAppaltatore(command, self.AcceptSuccess, self.AcceptError);
    };

    this.ShowDeleteAppaltatore = function(item) {
        self.Dialog.ShowDeleteAppaltatore(item.Id(), self, self.View);
    };

    this.DeleteAppaltatore = function(command) {
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
            self.GetItems(viewModel.PageNum());
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





