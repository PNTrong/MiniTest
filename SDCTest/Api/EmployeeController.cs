using AutoMapper;
using Model.Models;
using SDCTest.Common.Core;
using SDCTest.Models;
using Service;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SDCTest.Common.Extension;
using System.Linq;
using System;

namespace SDCTest.Api
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiControllerBase
    {
        private IEmployeeService _employeeService;

        public EmployeeController(IErrorService errorService, IEmployeeService employeeService) : base(errorService)
        {
            this._employeeService = employeeService;
        }

        [Route("getall")]
        [HttpGet]
        [AllowAnonymous]
        public HttpResponseMessage GetAll(HttpRequestMessage req, string keyword, int page, int pageSize = 20)
        {
            return CreateHttpResponse(req, () =>
            {
                HttpResponseMessage res = null;
                int totalRow = 0;
                var employees = _employeeService.GetAll(keyword);
                totalRow = employees.Count();

                var query = employees.OrderByDescending(x => x.Name).Skip(page * pageSize).Take(pageSize);

                var resData = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(query);

                var paginationSet = new PaginationSet<EmployeeViewModel>()
                {
                    Items = resData,
                    Page = page,
                    TotalRow = totalRow,
                    TotalPage = (int)Math.Ceiling((decimal)totalRow / pageSize)
                };
                res = req.CreateResponse(HttpStatusCode.OK, paginationSet);
                return res;
            });
        }


        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetListbyProvinceId(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var employees = _employeeService.GetAll(id);

                var responseData = Mapper.Map<IEnumerable<Employee>, IEnumerable<EmployeeViewModel>>(employees);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage req, EmployeeViewModel empVm)
        {
            return CreateHttpResponse(req, () =>
            {
                HttpResponseMessage res = null;
                if (ModelState.IsValid)
                {
                    var employee = new Employee();
                    employee.UpdateEmployee(empVm);

                    _employeeService.Add(employee);
                    _employeeService.SaveChanges();

                    var resData = Mapper.Map<Employee, EmployeeViewModel>(employee);
                    res = req.CreateResponse(HttpStatusCode.OK, resData);
                }
                else
                {
                    req.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return res;
            });
        }



   

}
}