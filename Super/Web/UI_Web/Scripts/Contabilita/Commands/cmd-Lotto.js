
//Commands
var FilterLotto = function (description, pageNum, pageSize) {
    this.Description = description;
    this.PageNum = pageNum;
    this.PageSize = pageSize;
}
var CreateLotto = function (id, commitId, version, creationDate, intervall, description) {
    if (description == null || description == '')
        return "description cannot be null or empty";
    if (creationDate == null)
        return "creationDate cannot be null or empty";

    CommandBase(this, id, commitId, version);
    this.CreationDate = dateFormat(creationDate, "isoDateTime");
    this.Intervall = intervall;
    this.Description = description;
};

var UpdateLotto = function (id, commitId, version,  intervall, description) {
    if (description == null || description == '')
        return "description cannot be null or empty";

    CommandBase(this, id, commitId, version);
    this.Intervall = intervall;
    this.Description = description;
};

var DeleteLotto = function (id, commitId, version) {
    CommandBase(this, id, commitId, version);
};

