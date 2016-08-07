angular.module("myapp", [])
    .controller("myappCtrl", function ($scope, $http) {

        $scope.name = "asdfasdfasf";

        $scope.save = function () {
            alert('scope.save()');
        }


    });