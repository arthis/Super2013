//Repository
var Repository = function () {
    this.GetItems = function (description, pageNum, pageSize, success, error) {
        jQuery.ajaxSettings.traditional = true;
        var command = new ViewItems(description, pageNum, pageSize);
        $.ajax({
            type: 'Post',
            url: '@Url.Action("GetItems")',
            data: JSON.stringify(command),
            contentType: 'application/json; charset=utf-8',
            success: success,
            error: error,
            dataType: 'json'
        });
    };
    this.Add = function (selected, success, error) {
        var returnValue = false;
        var command = new CreateImpianto(selected.Id(), guidGenerator(), selected.Version(), selected.CreationDate(), selected.Start(), selected.End(), selected.IdLotto(), selected.Description())
        $.ajax({
            type: 'Post',
            url: '@Url.Action("Create")',
            data: JSON.stringify(command),
            contentType: 'application/json; charset=utf-8',
            success: function () { returnValue = success(selected) },
            error: function () { returnValue = error(selected) },
            dataType: 'json',
            async: false
        });
        return returnValue;
    };
    this.Update = function (selected, success, error) {
        var returnValue = false;
        var command = new UpdateImpianto(selected.Id(), guidGenerator(), selected.Version(), selected.Start(), selected.End(), selected.Description())
        $.ajax({
            type: 'Post',
            url: '@Url.Action("Update")',
            data: JSON.stringify(command),
            contentType: 'application/json; charset=utf-8',
            success: function () { returnValue = success(selected) },
            error: function () { returnValue = error(selected) },
            dataType: 'json',
            async: false
        });
        return returnValue;
    };
    this.Delete = function (selected, success, error) {
        var returnValue = false;
        var command = new DeleteImpianto(selected.Id(), guidGenerator(), selected.Version())
        $.ajax({
            type: 'Post',
            url: '@Url.Action("Delete")',
            data: JSON.stringify(command),
            contentType: 'application/json; charset=utf-8',
            success: function () { returnValue = success(selected) },
            error: function () { returnValue = error(selected) },
            dataType: 'json',
            async: false
        });
        return returnValue;
    };
}