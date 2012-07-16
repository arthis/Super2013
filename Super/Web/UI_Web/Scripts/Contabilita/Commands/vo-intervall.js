//Value objects fort commands
var Intervall = function (start, end) {
    var self = this;

    this.ToIsoDateTime = function () {
        this.Start = dateFormat(self.Start, "isoDateTime");
        this.End = dateFormat(self.End, "isoDateTime");
        return this;
    };

    var validationError = CheckIntervall(start, end);
    if (CheckIntervall(start,end) != null)
        throw new validationError;

    this.Start = start;
    this.End = end;

};

function checkIntervall() {
    var start = $('#Start').val();
    var end = $('#End').val();
    return CheckIntervall(start, end);
}

function CheckIntervall(start, end) {
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

