using AutoMapper;
using Model.Models;
using SDCTest.Common.Core;
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
    [RoutePrefix("api/county")]
    public class CountyController : ApiControllerBase
    {
        private ICountyService _countyService;

        public CountyController(IErrorService errorService, ICountyService countyService) : base(errorService)
        {
            this._countyService = countyService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var list = _countyService.GetAll();

                var responseData = Mapper.Map<IEnumerable<County>, IEnumerable<CountyViewModel>>(list);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        [Route("getbyid/{id:int}")]
        [HttpGet]
        public HttpResponseMessage GetListbyProvinceId(HttpRequestMessage request, int id)
        {
            return CreateHttpResponse(request, () =>
            {
                var counties = _countyService.GetAll(id);

                var responseData = Mapper.Map<IEnumerable<County>, IEnumerable<CountyViewModel>>(counties);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);

                return response;
            });
        }

    }
}
