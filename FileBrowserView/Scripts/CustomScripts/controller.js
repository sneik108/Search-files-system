angular.module("fileBrowserApp").controller("FileBrowserCtrl", function ($scope, $http) {
    $scope.tableUrl = "Views/table.html";
    $scope.fileInfoUrl = "Views/fileInfo.html";
    $scope.errorsUrl = "Views/errors.html";
    $scope.loading = true;
    $http.get('http://localhost:60878/api/browser').success(function (response) {
        $scope.dirData = response;
        $scope.loading = false;
    });
    $scope.getData = function (path) {
        $scope.loading = true;
        if (path == null) {
            $http.get('http://localhost:60878/api/browser').success(function (response) {
                $scope.dirData = response;
                $scope.errors = null;
                $scope.backPointer = null;
                $scope.fileData = null;
                $scope.currentPath = null;
                $scope.oldPath = null;
                $scope.smallGroup = null;
                $scope.middleGroup = null;
                $scope.largeGroup = null;
                $scope.loading = false;
                
            });
        }
        else {
            $http.get("http://localhost:60878/api/browser?id=" + path).success(function (response) {
                $scope.fileData = response.fileNames; //This was done to decrease the markup code (in html)
                $scope.dirData = response.directoryNames;
                $scope.currentPath = path;
                $scope.oldPath = response.oldPath;
                $scope.smallGroup = response.numberOfSmallGroup;
                $scope.middleGroup = response.numberOfMiddleGroup;
                $scope.largeGroup = response.numberOfLargeGroup;
                $scope.backPointer = "Back";
                $scope.loading = false;
            });
        }
    }
})