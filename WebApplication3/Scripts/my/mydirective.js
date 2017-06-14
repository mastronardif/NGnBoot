// * Directives extend the capabilities of HTML
// * Angular touches the DOM at two points, directives and template compilation
// * examples of directives are ng-model, ng-if, ng-show, ng-repeat
// * Directives are camelCased, attributes are snake-cased
// * The template can be specified in the template attribute
// * Or the templateUrl attribute
// * restrict (AEC)
// * scope: true creates a scope
// * Controller

(function() {
    angular.module('myapp')
    .directive('usefulDirective', function() {
      var directive = {
        template: "<p>Hello from the directive!</p> cat_list.html",
        restrict: 'AEC',
        scope:true,
        controller: function ($scope) { }
      };
      return directive;
        });

})();

(function () {
    angular.module('myapp')
        .directive('catList', function () {
            var directive = {
                templateUrl: "/Static/cat_list.html",
                restrict: 'AEC',
                scope: true,
                controller: Controller
            };
            return directive;
        });

    function Controller($scope, cats) {
        $scope.catName = "Felix";
        $scope.cats = cats.get(); //["felix","elmo","ralf"];//cats.get();
    }

})();

//angular.module('myapp', [])
angular.module('myapp')
    .service('cats', function () {
        this.get = function () {
            return ['manny', 'herbie'];
        }
    });


