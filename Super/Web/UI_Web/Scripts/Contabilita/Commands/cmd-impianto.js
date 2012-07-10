var CommandBase = function ( self, id, commitId, version) {
    self.Id = id;
    self.CommitId = commitId;
    self.Version = version;
}

//Commands
var ViewItems = function (description, pageNum, pageSize) {
    this.Description = description;
    this.PageNum = pageNum;
    this.PageSize = pageSize;
}
var CreateImpianto = function (id, commitId, version, creationDate, intervall, idLotto, description) {
    CommandBase(this, id, commitId, version);
    this.CreationDate = dateFormat(creationDate, "isoDateTime");
    this.Intervall = intervall.ToIsoDateTime(); 
    this.IdLotto = idLotto;
    this.Description = description;
}
var UpdateImpianto = function (id, commitId, version, intervall, description) {
    CommandBase(this, id, commitId, version);
    this.Intervall = intervall.ToIsoDateTime(); ;
    this.Description = description;
}
var DeleteImpianto = function (id, commitId, version) {
    CommandBase(this, id, commitId, version);
}
