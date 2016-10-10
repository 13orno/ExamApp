


(function (_, ng) {
    'use strict';

    ng.module('TestApp.course.models').provider('blCourse', [Course]);

    function Course() {
        var url = 'api/courses';

        this.$get = [
            '$http', function ($http) {
                return {
                    all: function () {
                        return $http.get(url);
                    },
                    create: function (course) {
                        return $http.post(url, course);
                    }
                };
            }
        ];
    }

})(_, angular);