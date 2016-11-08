/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('SDCTest.provinces', ['SDCTest.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('provinces', {
            url: "/provinces",
            templateUrl: "/app/components/provinces/provinceListView.html",
            controller: "provinceListController"
        }).state('add_province', {
            url: "/add_province",
            templateUrl: "/app/components/provinces/provinceAddView.html",
            controller: "provinceAddController"
        }).state('edit_province', {
            url: "/edit_province/:id",
            templateUrl: "/app/components/provinces/provinceEditView.html",
            controller: "provinceEditController"
        });
    }
})();