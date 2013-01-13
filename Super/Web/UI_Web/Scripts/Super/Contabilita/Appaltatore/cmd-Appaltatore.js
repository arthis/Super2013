
var CreateAppaltatore = function (id, commitId, version, description) {
	if (id == null)  throw "Id cannot be null";
    if (commitId == null) throw "commitId cannot be null";
    if (version == null) throw "Version cannot be null";
if (description == null || description == '') throw "description cannot be null or empty"; 
	    
    this.Id = id;
    this.CommitId = commitId;
    this.Version = version;
		this.Description=description;
	

};

	
var DeleteAppaltatore = function (id, commitId, version) {
	if (id == null)  throw "Id cannot be null";
    if (commitId == null) throw "commitId cannot be null";
    if (version == null) throw "Version cannot be null";
    
    this.Id = id;
    this.CommitId = commitId;
    this.Version = version;
	

};

	
var UpdateAppaltatore = function (id, commitId, version, description) {
	if (id == null)  throw "Id cannot be null";
    if (commitId == null) throw "commitId cannot be null";
    if (version == null) throw "Version cannot be null";
if (description == null || description == '') throw "description cannot be null or empty"; 
	    
    this.Id = id;
    this.CommitId = commitId;
    this.Version = version;
		this.Description=description;
	

};

	
