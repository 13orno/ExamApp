
(function () {
    'use strict';

    angular
       .module('TestApp.student.controllers')
       .controller('StudentViewController', ['$route', '$location', 'blStudent', StudentViewController]);

    function StudentViewController($route, Location, Student) {

        var vm = this;

        function load() {
            vm.student = $route.current.locals.student.data;
        }


        function DeleteStudent(id) {
            Student.destroy(id).then(function () {
                alert('Student Successfully Delete');
                Location.path('/student');
            }, function (response) {
            });
        }

        load();


        vm.DeleteStudent = DeleteStudent;
    }


})();
