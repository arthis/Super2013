//Value objects fort commands
var Interval = function (start, end) {
    var self = this;

    var validationError = CheckInterval(start, end);
    if (CheckInterval(start,end) != null)
        throw new validationError;

    this.Start = start.toJSON();
    this.End = end.toJSON();

};

var JsonDateFromddmmyyyy = function(date) {
    
    return dateFormat(date.toString(), "isoDateTime");
};

function checkInterval() {
    var start = $('#Start').val();
    var end = $('#End').val();
    return CheckInterval(start, end);
}

function CheckInterval(start, end) {
    if (start < DateTimeMin)
        return "startDate cannot be lesser than DateTimeMin";
    if (end < DateTimeMin)
        return "startDate cannot be lesser than DateTimeMin";
    if (start > DateTimeMax)
        return "startDate cannot be greater than DateTimeMax";
    if (end > DateTimeMax)
        return "startDate cannot be greater than DateTimeMax";
    if (start > end)
        return "startDate cannot be greater than endDate";
}

