angular.module("umbraco")
    .controller("theWebExp.rssListing.grideditorcontroller",
        function ($scope, $http) {
            $scope.feedItems = [];
            if ($scope.control.title === undefined) {
                $scope.control.title = "";
            }
            if ($scope.control.feedUrl === undefined) {
                $scope.control.feedUrl = "";
            } else {
                getFeedItems();
            }
            function getFeedItems() {
                $http({
                    method: "POST",
                    url: "/Umbraco/Api/RssListingPreview/GetListingItems",
                    data: { feedUrl: $scope.control.feedUrl }
                })
                    .then(function successCallback(response) {
                        $scope.feedItems = response.data;
                    }, function errorCallback(response) {
                        $scope.feedItems = [];
                    });
            }
            $scope.$watch('control.feedUrl', function () {
                getFeedItems();
            });
        });