
(function () {
    'use strict';

    angular
       .module('TestApp.student.controllers')
       .controller('StudentListController', ['$route', '$location', 'blStudent', StudentListController]);

    function StudentListController($route, Location, Student) {

        var vm = this;

        function load(){
            vm.students = $route.current.locals.students.data;
        }

        function EditStudent(id){
            console.log(id);
        }

        vm.students = [];
        vm.EditStudent = EditStudent;

        load();
    }


})();
