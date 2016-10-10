


(function (ng) {
    ng.module('TestApp', [
            'ngRoute',
            'ngAnimate',
            'TestApp.course',
            'TestApp.student'
    ])
        .config([
            '$routeProvider', function ($routeProvider) {
                $routeProvider.when('/', {
                    templateUrl: 'template/dashboard/dashboard.html'
                });

                $routeProvider.when('/student', {
                    templateUrl: 'template/student/studentList.html',
                    controller: 'StudentListController',
                    controllerAs: 'StudentList',
                    resolve: {
                        students: [
                            'blStudent',
                            function (Student) {
                                return Student.all();
                            }
                        ]
                    }
                });

                $routeProvider.when('/course', {
                    templateUrl: 'template/course/courseList.html',
                    controller: 'CourseListController',
                    controllerAs: 'CourseList',
                    resolve: {
                        courses: [
                            'blCourse',
                            function (Course) {
                                return Course.all();
                            }
                        ]
                    }
                });

                $routeProvider.otherwise('/');
            }
        ]);
})(angular);