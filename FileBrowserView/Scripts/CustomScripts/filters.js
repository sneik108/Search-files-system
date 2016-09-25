angular.module("fileBrowserApp")
.filter("deletePath", function () {
    return function (value, path) {
        value = value.replace(path, "").replace('\\', "");
        return value;
    }
});