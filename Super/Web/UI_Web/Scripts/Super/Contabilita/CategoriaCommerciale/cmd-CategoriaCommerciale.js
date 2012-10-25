
//Commands
var FilterCategoriaCommerciale = function (description, pageNum, pageSize) {
    this.Description = description;
    this.PageNum = pageNum;
    this.PageSize = pageSize;
}
var CreateCategoriaCommerciale = function (id, commitId, version,   description) {
    if (description == null || description == '')
        throw "description cannot be null or empty";
    
    CommandBase(this, id, commitId, version);
    this.Description = description;
};

var UpdateCategoriaCommerciale = function (id, commitId, version,   description) {
    if (description == null || description == '')
        throw "description cannot be null or empty";

    CommandBase(this, id, commitId, version);
    this.Description = description;
};

var DeleteCategoriaCommerciale = function (id, commitId, version) {
    CommandBase(this, id, commitId, version);
};

