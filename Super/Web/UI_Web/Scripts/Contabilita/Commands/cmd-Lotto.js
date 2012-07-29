
//Commands
var FilterLotto = function (description, pageNum, pageSize) {
    this.Description = description;
    this.PageNum = pageNum;
    this.PageSize = pageSize;
}
var CreateLotto = function (id, commitId, version,  interval, description) {
    if (description == null || description == '')
        throw "description cannot be null or empty";
    
    

    CommandBase(this, id, commitId, version);
    this.CreationDate = new Date().toJSON();
    this.Interval = interval;
    this.Description = description;
};

var UpdateLotto = function (id, commitId, version,  interval, description) {
    if (description == null || description == '')
        throw "description cannot be null or empty";

    CommandBase(this, id, commitId, version);
    this.Interval = interval;
    this.Description = description;
};

var DeleteLotto = function (id, commitId, version) {
    CommandBase(this, id, commitId, version);
};

