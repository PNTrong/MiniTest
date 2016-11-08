(function (app) {
    app.controller('employeeListController', employeeListController);

    employeeListController.$inject = ['apiService', '$scope', 'notificationService', '$ngBootbox', '$filter'];

    function employeeListController(apiService, $scope, notificationService, $ngBootbox, $filter) {
        $scope.employees = [];
        $scope.page = 0;
        $scope.pagesCount = 0;
        $scope.search = search;
        $scope.keyword = '';
        $scope.selectAll = selectAll;

        function search() {
            getEmployees();
        }

        $scope.isAll = false;
        function selectAll() {
            if ($scope.isAll === false) {
                angular.forEach($scope.products, function (item) {
                    item.checked = true;
                });
                $scope.isAll = true;
            } else {
                angular.forEach($scope.products, function (item) {
                    item.checked = false;
                });
                $scope.isAll = false;
            }
        }

        $scope.$watch("employees", function (n, o) {
            var checked = $filter("filter")(n, { checked: true });
            if (checked.length) {
                $scope.selected = checked;
                $('#btnDelete').removeAttr('disabled');
            } else {
                $('#btnDelete').attr('disabled', 'disabled');
            }
        }, true);

        $scope.deleteMultiple = deleteMultiple;
        function deleteMultiple() {
            var IDs = [];
            $.each($scope.selected, function (i, item) {
                IDs.push(item);
            });
            var config = {
                params: {
                    checkedEmployees: JSON.stringify(IDs)
                }
            }
            apiService.del('api/employee/deletemulti', config, function (result) {
                notificationService.Success('Xóa thành công ' + result.data + ' bản ghi.');
                search();
            }, function (error) {
                notificationService.Error('Xóa không thành công');
            });
        }

        $scope.getEmployees = getEmployees;
        function getEmployees(page) {
            page = page || 0;
            var config = {
                params: {
                    keyword: $scope.keyword,
                    page: page,
                    pageSize: 2
                }
            }
            apiService.get('api/employee/getall', config, function (result) {
                if (result.data.TotalRow == 0) {
                    notificationService.Warning("Không tìm thấy bảng ghi nào !");
                }
                $scope.employees = result.data.Items;
                $scope.page = result.data.Page;
                $scope.pagesCount = result.data.TotalPage;
                $scope.totalCount = result.data.TotalRow;
            },
            function (err) { console.log(err.data); });
        }
        $scope.getEmployees();
    }
})(angular.module('SDCTest.employees'));