

(function () {
    'use strict';

    angular
       .module('TestApp.student.controllers')
       .controller('StudentCreateController', ['$route', '$location', 'blStudent', StudentCreateController]);

    function StudentCreateController($route, Location, Student) {

        var vm = this;

        function load() {
            vm.courses = $route.current.locals.courses.data;
        }

        function selectCourse() {
            var selectedFilters = _(vm.courses).filter(function (item) { return item.selected; });
            vm.coursesList = _.pluck(selectedFilters, 'Id');
        }

        function submitForm()
        {
            vm.user.coursesList = vm.coursesList;
            console.log(vm.user.coursesList);

            if (vm.userForm.$invalid) {
                return;
            }
            Student.create(vm.user).then(function () {
                alert('Student Successfully Added');
                vm.goToList();
                }, function (response) {
            });
        }

        function goToList() {
            Location.path('/student');
        }

        vm.courses = [];
        vm.coursesList = [];
        vm.selectCourse = selectCourse;
        vm.submitForm = submitForm;
        vm.goToList = goToList;

        load();
    }


})();
