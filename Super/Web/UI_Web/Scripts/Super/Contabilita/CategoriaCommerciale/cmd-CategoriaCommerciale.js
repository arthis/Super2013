
var CreateCategoriaCommerciale = function (id, commitId, version, description) {
	if (id == null)  throw "Id cannot be null";
    if (commitId == null) throw "commitId cannot be null";
    if (version == null) throw "Version cannot be null";
if (description == null || description == '') throw "description cannot be null or empty"; 
	    
    this.Id = id;
    this.CommitId = commitId;
    this.Version = version;
		this.Description=description;
	

};

	
var DeleteCategoriaCommerciale = function (id, commitId, version) {
	if (id == null)  throw "Id cannot be null";
    if (commitId == null) throw "commitId cannot be null";
    if (version == null) throw "Version cannot be null";
    
    this.Id = id;
    this.CommitId = commitId;
    this.Version = version;
	

};

	
var UpdateCategoriaCommerciale = function (id, commitId, version, description) {
	if (id == null)  throw "Id cannot be null";
    if (commitId == null) throw "commitId cannot be null";
    if (version == null) throw "Version cannot be null";
if (description == null || description == '') throw "description cannot be null or empty"; 
	    
    this.Id = id;
    this.CommitId = commitId;
    this.Version = version;
		this.Description=description;
	

};

	
