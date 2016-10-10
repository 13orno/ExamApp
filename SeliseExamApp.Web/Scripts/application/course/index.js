
(function (ng) {
    'use strict';

    ng.module('TestApp.course', [
        'ngRoute',
        'TestApp.course.controllers',
        'TestApp.course.models'
    ])
        .config([
            '$routeProvider',
            function ($routes) {
                $routes.when('/course/create', {
                    templateUrl: 'template/course/create.html',
                    controller: 'CourseCreateController',
                    controllerAs: 'CourseCreate'
                });
            }
        ]);

})(angular);