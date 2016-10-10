


(function () {
    'use strict';

    angular
       .module('TestApp.student.controllers')
       .controller('CourseCreateController', ['$route', '$location','blCourse', CourseCreateController]);

    function CourseCreateController($route, Location, Course) {

        var vm = this;

        function load() {

        }

        function submitForm() {
            console.log(vm.user);

            if (vm.userForm.$invalid) {
                return;
            }
            Course.create(vm.user).then(function () {
                alert('Student Successfully Added');
                vm.goToList();
            }, function (response) {
            });
        }

        function goToList() {
            Location.path('/course');
        }

        vm.submitForm = submitForm;
        vm.goToList = goToList;

        load();
    }


})();
