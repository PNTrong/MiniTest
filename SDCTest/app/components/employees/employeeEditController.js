(function (app) {
    app.controller('employeeEditController', employeeEditController);

    employeeEditController.$inject = ['apiService', '$scope', 'notificationService', '$state', '$stateParams', 'commonService','$http'];

    function employeeEditController(apiService, $scope, notificationService, $state, $stateParams, commonService,$http) {


        $scope.UpdateEmployee = UpdateEmployee;

        function loadEmployeeDetail() {
            apiService.get('api/employee/getbyid/' + $stateParams.id, null, function (result) {
                $scope.employee = result.data;
            }, function (error) {
                notificationService.displayError(error.data);
            });
        }

        $scope.UpdateEmployee = UpdateEmployee;
        function UpdateEmployee() {
            apiService.put('api/employee/update', $scope.employee, function (result) {
                notificationService.Success(result.data.Name + 'đã được cập nhập!');
                $state.go('employees');
            }, function (err) {
                notificationService.Error('Cập nhật không thành công!');
            });
        }

        $scope.provinces = [];

        function loadProvince() {
            apiService.get('api/province/getall', null, function (result) {
                $scope.provinces = result.data;
            }, function () {
                console.log('Can not get parent list');
            });
        }


        $scope.counties = [];
        $scope.loadCounty = loadCounty;

        function loadCounty(id) {
            $http.get("api/county/getbyid/" + id).then(function (res) {
                $scope.counties = res.data;
            }, function (err) { console.log('Can not get parent list'); });
        }




        loadEmployeeDetail();
        loadProvince();
        loadCounty();
    }

})(angular.module('SDCTest.employees'));