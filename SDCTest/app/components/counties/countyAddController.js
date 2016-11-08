(function (app) {
    app.controller('countyAddController', countyAddController);

    countyAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService'];

    function countyAddController(apiService, $scope, notificationService, $state, commonService) {

        $scope.AddCounty = AddCounty;

        function AddCounty() {
            apiService.post('api/county/create', $scope.county,
                function (result) {
                    notificationService.Success(result.data.Name + ' đã được thêm mới.');
                    $state.go('counties');
                }, function (error) {
                    notificationService.Error('Thêm mới không thành công.');
                });
        }

        $scope.provinces = [];
        function loadProvince() {
            apiService.get('api/province/getallparents', null, function (result) {
                $scope.provinces = result.data;
            }, function () {
                console.log('Cannot get list parent');
            });
        }

        loadProvince();
    }

})(angular.module('SDCTest.counties'));