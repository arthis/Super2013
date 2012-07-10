//Value objects fort commands
var Intervall = function (startDate, endDate) {
    if (startDate < DateTimeMin)
        throw "startDate cannot be lesser than DateTimeMin";
    if (endDate < DateTimeMin)
        throw "startDate cannot be lesser than DateTimeMin";
    if (startDate > DateTimeMax)
        throw "startDate cannot be greater than DateTimeMax";
    if (endDate > DateTimeMax)
        throw "startDate cannot be greater than DateTimeMax";
    if (startDate > endDate)
        throw "startDate cannot be greater than endDate";

    this.StartDate = startDate;
    this.EndDate = endDate;

    this.ToIsoDateTime = function () {
        this.StartDate = dateFormat(self.StartDate, "isoDateTime");
        this.EndDate = dateFormat(self.EndDate, "isoDateTime");
        return this;
    };
}