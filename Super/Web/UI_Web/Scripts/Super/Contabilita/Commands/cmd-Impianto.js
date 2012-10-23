

//Commands
var FilterImpianto = function (description, pageNum, pageSize) {
    this.Description = description;
    this.PageNum = pageNum;
    this.PageSize = pageSize;
}
var CreateImpianto = function (id, commitId, version,  interval, description, idLotto) {
    if (description == null || description == '')
        throw "description cannot be null or empty";
    
    
    if (idLotto == null)
        throw "Lotto must be selected";

    CommandBase(this, id, commitId, version);
    this.Interval = interval;
    this.Description = description;
    this.IdLotto = idLotto;
};

var UpdateImpianto = function (id, commitId, version,  interval, description) {
    if (description == null || description == '')
        throw "description cannot be null or empty";

    CommandBase(this, id, commitId, version);
    this.Interval = interval;
    this.Description = description;
};

var DeleteImpianto = function (id, commitId, version) {
    CommandBase(this, id, commitId, version);
};

