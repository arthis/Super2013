//Model
var Impianto = function (id, version, creationDate, start, end, idLotto, description, isNew) {
    var self = this;
    this.Id = ko.observable(id);
    this.CreationDate = ko.observable(creationDate.format("dd/mm/yyyy HH:MM"));
    this.Start = ko.observable(start.format("dd/mm/yyyy"));
    this.End = ko.observable(end.format("dd/mm/yyyy"));
    this.IdLotto = ko.observable(idLotto);
    this.Description = ko.observable(description);
    this.Version = version;
    this.IsNew = isNew;

    this.EditStart = ko.observable(start.format("dd/mm/yyyy"));
    this.EditEnd = ko.observable(end.format("dd/mm/yyyy"));
    this.EditDescription = ko.observable(description);

    //reset to originals on cancel 
    this.Cancel = function () {
        this.Start(this.EditStart()).End(this.EditEnd()).Description(this.EditDescription());
    } .bind(this);

    //persist edits to real values on accept
    this.Accept = function () {
        this.EditStart(this.Start()).EditEnd(this.End()).EditDescription(this.Description());
    } .bind(this);
}