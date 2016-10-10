
(function () {
    'use strict';

    angular
       .module('TestApp.course.controllers')
       .controller('CourseListController', ['$route', '$location', 'blCourse', CourseListController]);

    function CourseListController($route, Location, Course) {

        var vm = this;

        function load() {
            vm.courses = $route.current.locals.courses.data;
        }

        vm.courses = [];

        load();
    }


})();
