/// <reference path="/Assets/admin/libs/angular/angular.js" />

(function () {
    angular.module('SDCTest.counties', ['SDCTest.common']).config(config);

    config.$inject = ['$stateProvider', '$urlRouterProvider'];

    function config($stateProvider, $urlRouterProvider) {
        $stateProvider.state('counties', {
            url: "/counties",
            templateUrl: "/app/components/counties/countyListView.html",
            controller: "countyListController"
        }).state('add_county', {
            url: "/add_county",
            templateUrl: "/app/components/counties/countyAddView.html",
            controller: "countyAddController"
        }).state('edit_county', {
            url: "/edit_county/:id",
            templateUrl: "/app/components/counties/countyEditView.html",
            controller: "countyEditController"
        });
    }
})();