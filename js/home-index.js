// home-index.js

var app = angular.module("myapp", []);

app.controller("homeIndexController", function ($scope, $http) {
    $scope.data = [];
    $scope.isBusy = true;

    $http.get("/RedditJson")
    .then(function (result) {
        angular.copy(result.data, $scope.data);
        $scope.myValue = false;
    },
    function () {
        $scope.error = "Reddit Seems to be Down";
        $scope.myValue = true;
    })
    .then(function () {
        $scope.isBusy = false;
    });
});