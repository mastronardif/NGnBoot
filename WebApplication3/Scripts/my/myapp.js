angular.module("myapp", [])
    .controller("myappCtrl", function ($scope, $http) {

        $scope.name = "asdfasdfasf";
       
        $scope.ads = "";

        /***/
        var url = '/Home/GetAds/';
        $http.get(url)
            .then(function (resp) {
                $scope.ads = resp.data;
                console.log("ads = ", $scope.ads);
            });
        /*******/

        $scope.save = function () {
            alert('scope.save()');
        },

        $scope.init = function (employees) {
            $scope.employees = employees;
            console.log('INIT INIT');
        }


    });