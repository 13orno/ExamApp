

(function (_, ng) {
    'use strict';

    ng.module('TestApp.student.models').provider('blStudent', [Student]);

    function Student() {
        var url = 'api/students';

        this.$get = [
            '$http', function ($http) {
                return {
                    all: function () {
                        return $http.get(url);
                    },
                    create: function (student) {
                        return $http.post(url, student);
                    },
                    one: function (id) {
                        return $http.get(url + '/' + id);
                    },
                    destroy: function (id) {
                        return $http.delete(url + '/' + id);
                    }
                };
            }
        ];
    }



})(_, angular);