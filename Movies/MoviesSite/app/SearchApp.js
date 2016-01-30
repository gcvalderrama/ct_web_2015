var moviesapp = angular.module("moviesapp", ['ngRoute', 'kendo.directives']);moviesapp.config(['$routeProvider', function ($routeProvider) {
    $routeProvider.when('/default',
            {
                templateUrl: 'views/search.html',
                controller : 'SearchController'
            }
        ).otherwise({ redirectTo: '/default' });
    }]);