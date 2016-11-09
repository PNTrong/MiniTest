using AutoMapper;
using Model.Models;
using SDCTest.Common.Core;
using SDCTest.Common.Extension;
using SDCTest.Models;
using Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

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

        [Route("getbyProvince/{id:int}")]
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

        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetById(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var employees = _employeeService.GetById(id);

                var responseData = Mapper.Map<Employee,EmployeeViewModel>(employees);

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
                    var errors = ModelState.Values.SelectMany(v => v.Errors);
                    req.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
                }
                return res;
            });
        }

        [Route("update")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Update(HttpRequestMessage req, EmployeeViewModel empVm)
        {
            return CreateHttpResponse(req, () =>
            {
                HttpResponseMessage res = null;
                if (ModelState.IsValid)
                {
                    var employee = _employeeService.GetById(empVm.ID);
                    employee.UpdateEmployee(empVm);

                    _employeeService.Update(employee);
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

        [Route("delete")]
        [HttpDelete]
        [AllowAnonymous]
        public HttpResponseMessage Delete(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                HttpResponseMessage response = null;
                if (!ModelState.IsValid)
                {
                    response = request.CreateResponse(HttpStatusCode.BadRequest, ModelState);
                }
                else
                {
                    var emp = _employeeService.Delete(id);
                    _employeeService.SaveChanges();

                    var responseData = Mapper.Map<Employee, EmployeeViewModel>(emp);
                    response = request.CreateResponse(HttpStatusCode.Created, responseData);
                }

                return response;
            });
        }

    }
}