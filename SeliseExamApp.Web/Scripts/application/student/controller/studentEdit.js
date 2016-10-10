
(function () {
    'use strict';

    angular
       .module('TestApp.student.controllers')
       .controller('StudentEditController', ['$route', '$location', 'blStudent', StudentEditController]);

    function StudentEditController($route, Location, Student) {

        var vm = this;

        function load() {
            vm.user = $route.current.locals.student.data;
            vm.courses = $route.current.locals.courses.data;
            vm.editCourses = vm.user.CourseItems;
        }

        function checkItem(id)
        {
            var flag = false;
            var abc = _.contains(_.pluck(vm.editCourses, 'Id'), id);
            if (abc){
                flag = true;
            }
            return flag;
        }

        function selectCourse() {
            var selectedFilters = _(vm.courses).filter(function (item) { return item.selected; });
            vm.editCourses1 = _.pluck(selectedFilters, 'Id');
        }

        function submitForm() {
            vm.user.coursesList = vm.editCourses;
            console.log(vm.user.coursesList);

            //if (vm.userForm.$invalid) {
            //    return;
            //}
            //Student.create(vm.user).then(function () {
            //    alert('Student Successfully Added');
            //    vm.goToList();
            //}, function (response) {
            //});
        }

        load();
        vm.checkItem = checkItem;
        vm.submitForm = submitForm;
        vm.coursesList = [];
        vm.selectCourse = selectCourse;
    }


})();