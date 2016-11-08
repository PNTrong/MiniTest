(function (app) {
    app.controller('provinceAddController', provinceAddController);

    provinceAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService', '$http']

    function provinceAddController(apiService, $scope, notificationService, $state, commonService, $http) {
        $scope.AddProvince = AddProvince;
        function AddProvince() {
            apiService.post('api/province/create', $scope.province, function (result) {
                notificationService.Success(result.data.Name + 'đã được thêm mới!');
                $state.go('provinces');
            }, function (err) {
                notificationService.Error('Thêm mới không thành công!');
            });
        }
    }
})(angular.module('SDCTest.provinces'));