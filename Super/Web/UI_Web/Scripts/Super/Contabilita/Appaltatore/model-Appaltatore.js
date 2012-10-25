//Model
var Appaltatore = function (id, version, creationDate, description) {
    this.Id = ko.observable(id);
    this.CreationDate = ko.observable(creationDate.format("dd/mm/yyyy HH:MM"));
    this.Description = ko.observable(description);
    this.Version = version;
};