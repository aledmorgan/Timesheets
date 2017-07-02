function ukFormattedMoment(date) {
    var validFormat = date.substr(6, 4) + "/" + date.substr(3, 2) + "/" + date.substr(0, 2);
    return moment(validFormat, "YYYY/MM/DD");
}