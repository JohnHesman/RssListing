angular.module("umbraco")
    .controller("theWebExp.rssListing.grideditorcontroller",
        function ($scope) {
            if ($scope.control.title === undefined) {
                $scope.control.title = "";
            }
            if ($scope.control.feedUrl === undefined) {
                $scope.control.feedUrl = "";
            }
        });