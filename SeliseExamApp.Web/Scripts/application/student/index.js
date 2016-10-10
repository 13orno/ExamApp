


(function (ng) {
    'use strict';

    ng.module('TestApp.student', [
        'ngRoute',
        'TestApp.student.controllers',
        'TestApp.student.models',
        'TestApp.course.models'
    ])
        .config([
            '$routeProvider',
            function ($routes) {
                $routes.when('/student/create', {
                    templateUrl: 'template/student/create.html',
                    controller: 'StudentCreateController',
                    controllerAs: 'StudentCreate',
                    resolve: {
                        courses: [
                            'blCourse',
                            function (Course) {
                                return Course.all();
                            }
                        ]
                    }
                });

                $routes.when('/student/:id', {
                    templateUrl: 'template/student/view.html',
                    controller: 'StudentViewController',
                    controllerAs: 'StudentView',
                    resolve: {
                        student: [
                            '$route',
                            'blStudent',
                            function ($route, Student) {
                                return Student.one($route.current.params.id);
                            }
                        ]
                    }
                });

                $routes.when('/student/edit/:id', {
                    templateUrl: 'template/student/edit.html',
                    controller: 'StudentEditController',
                    controllerAs: 'StudentEdit',
                    resolve: {
                        student: [
                            '$route',
                            'blStudent',
                            function ($route, Student) {
                                return Student.one($route.current.params.id);
                            }
                        ],
                        courses: [
                            'blCourse',
                            function (Course) {
                                return Course.all();
                            }
                        ]
                    }
                });
            }
        ]);

})(angular);