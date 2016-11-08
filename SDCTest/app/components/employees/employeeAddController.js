(function (app) {
    app.controller('employeeAddController', employeeAddController);

    employeeAddController.$inject = ['apiService', '$scope', 'notificationService', '$state', 'commonService','$http']

    function employeeAddController(apiService, $scope, notificationService, $state, commonService, $http) {

        $scope.ckeditorOptions = {
            language: 'vi',
            height: '200px'
        }

        $scope.ChooseImage = function () {
            var finder = new CKFinder();
            finder.selectActionFunction = function (fileurl) {
                $scope.employee.Image = fileurl;
            }
            finder.popup();
        }

        $scope.AddEmployee = AddEmployee;
        function AddEmployee(){
            apiService.post('api/employee/create',$scope.employee, function (result) {
                notificationService.Success(result.data.Name + 'đã được thêm mới!');
                $state.go('employees');
            }, function (err) {
                notificationService.Error('Thêm mới không thành công!');
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

        loadProvince();
        loadCounty();
    }
})(angular.module('SDCTest.employees'));