

//Commands
var FilterImpianto = function (description, pageNum, pageSize) {
    this.Description = description;
    this.PageNum = pageNum;
    this.PageSize = pageSize;
}
var CreateImpianto = function (id, commitId, version, creationDate, intervall, description, idLotto) {
    if (description == null || description == '')
        return "description cannot be null or empty";
    if (creationDate == null)
        return "creationDate cannot be null or empty";
    if (idLotto == null)
        return "Lotto must be selected";

    CommandBase(this, id, commitId, version);
    this.CreationDate = dateFormat(creationDate, "isoDateTime");
    this.Intervall = intervall;
    this.Description = description;
    this.IdLotto = idLotto;
};

var UpdateImpianto = function (id, commitId, version,  intervall, description) {
    if (description == null || description == '')
        return "description cannot be null or empty";

    CommandBase(this, id, commitId, version);
    this.Intervall = intervall;
    this.Description = description;
};

var DeleteImpianto = function (id, commitId, version) {
    CommandBase(this, id, commitId, version);
};

