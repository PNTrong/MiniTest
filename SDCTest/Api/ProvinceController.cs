using AutoMapper;
using Model.Models;
using SDCTest.Common.Core;
using SDCTest.Models;
using Service;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SDCTest.Api
{
    [RoutePrefix("api/province")]
    public class ProvinceController : ApiControllerBase
    {
        private IProvinceService _provinceService;

        public ProvinceController(IErrorService errorService, IProvinceService provinceService) : base(errorService)
        {
            _provinceService = provinceService;
        }

        [Route("getall")]
        [HttpGet]
        public HttpResponseMessage GetAll(HttpRequestMessage request)
        {
            return CreateHttpResponse(request, () =>
            {
                var list = _provinceService.GetAll();

                var responseData = Mapper.Map<IEnumerable<Province>, IEnumerable<ProvinceViewModel>>(list);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }
    }
}