 //ViewModel
var ViewModel = function (repository, details, formDetails, view, pageNum, pageSize, updateLink, createLink) {
    var self = this;

    //filtro
    this.Description = ko.observable();
    this.PageNum = ko.observable(pageNum);
    this.PageSize = ko.observable(pageSize);

    this.Items = ko.mapping.fromJS([]);
    this.SelectedItem = ko.observable();
    this.Details = details;
    this.FormDetails = formDetails;
    this.View = view;

    this.ShowEditItem = function (item) {
        self.View.Spin({ title: "Please Wait", message: "Opening form..." });
        self.SelectedItem(item);
        self.OpenDetails(updateLink, 'Update un impianto');
        self.View.StopSpin();
    };
    this.ShowAddItem = function () {
        self.View.Spin({ title: "Please Wait", message: "Opening form..." });
        var now = new Date();
        var newItem = new Impianto(guidGenerator(), 0, now, now, now, null, '', true);
        self.SelectedItem(newItem);
        self.OpenDetails(createLink, 'Aggiungere un impianto');
        self.View.StopSpin();
    };
    this.DeleteItem = function (item) {

        self.View.Spin({ title: "Please Wait", message: "Deleting impianto..." });
        repository.Delete(item, self.DeleteItemSuccess, self.DeleteItemError);
    };

    this.DeleteItemSuccess = function (selected) {
        self.Items.remove(item);
        self.View.StopSpin();
        alert("item " + selected.Id() + " removed");
    };

    this.DeleteItemError = function (selected) {
        self.View.StopSpin();
        alert("item " + selected.Id() + " not removed");
    };

    this.Accept = function (form) {

        self.View.Spin({ title: "Please Wait", message: "Accepting modification..." });
        var selected = self.SelectedItem();

        if ($(form).valid())
            if (selected.IsNew)
                repository.Add(selected, self.AcceptSuccess, self.AcceptError);
            else
                repository.Update(selected, self.AcceptSuccess, self.AcceptError);
        else
            alert("error");
    };

    this.AcceptSuccess = function (selected) {
        selected.Accept();
        if (selected.IsNew)
            self.Items.push(selected);
        self.SelectedItem("");
        self.View.CloseDetails();
        self.View.StopSpin();
    };

    this.AcceptError = function (selected) {
        self.View.StopSpin();
        alert("error repository");
    };


    this.Cancel = function () {
        self.SelectedItem().Cancel();
        self.SelectedItem("");
        self.View.CloseDetails();
    };

    this.GetItems = function (pageNum) {
        self.View.Spin({ title: "Please Wait", message: "Loading data..." });
        if (pageNum == null)
            self.PageNum(1);
        else
            self.PageNum(pageNum);
        repository.GetItems(self.Description(), self.PageNum(), self.PageSize(), self.GetItemsSuccess, self.GetItemsError);
    };

    this.GetItemsSuccess = function (items) {
        self.Items.removeAll();
        ko.utils.arrayForEach(items.results, function (item) {
            self.Items.push(new Impianto(item.Id, item.Version, ToDate(item.CreationDate), ToDate(item.Start), ToDate(item.End), item.Description));
        });
        self.View.Paginate(self.PageNum(), self.PageSize(), items.count, self.GetItems);
        self.View.StopSpin();
    };

    this.GetItemsError = function () {
        self.View.StopSpin();
        alert('error while fetching data');
    };


    //dialog
    this.OpenDetails = function (urlView, title) {

        $('#' + self.Details).dialog({
            autoOpen: false,
            width: 350,
            height: 400,
            position: 'center',
            resizable: true,
            title: title,
            modal: true,
            open: function (event, ui) {
                $(this).load(urlView, function () {
                    ko.applyBindings(self, document.getElementById(self.Details));
                });
            },
            buttons: {
                "Accept": function () {
                    var form = document.getElementById(self.FormDetails);
                    if (self.Accept(form))
                        $(this).dialog("close");
                },
                "Cancel": function () {
                    self.Cancel();
                    $(this).dialog("close");
                }
            }
        });
        $('#' + self.Details).dialog("open"); 
    };

    this.CloseDetails = function() {
        $('#' + self.Details).dialog("close");
    };
}