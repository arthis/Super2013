
//Commands
var FilterAppaltatore = function (description, pageNum, pageSize) {
    this.Description = description;
    this.PageNum = pageNum;
    this.PageSize = pageSize;
}
var CreateAppaltatore = function (id, commitId, version,   description) {
    if (description == null || description == '')
        throw "description cannot be null or empty";
    
    CommandBase(this, id, commitId, version);
    this.CreationDate = new Date().toJSON();
    this.Description = description;
};

var UpdateAppaltatore = function (id, commitId, version,   description) {
    if (description == null || description == '')
        throw "description cannot be null or empty";

    CommandBase(this, id, commitId, version);
    this.Description = description;
};

var DeleteAppaltatore = function (id, commitId, version) {
    CommandBase(this, id, commitId, version);
};

