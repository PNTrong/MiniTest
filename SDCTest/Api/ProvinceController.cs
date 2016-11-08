using AutoMapper;
using Model.Models;
using SDCTest.Common.Core;
using SDCTest.Common.Extension;
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

                var responseData = Mapper.Map<IEnumerable<Province>,IEnumerable<ProvinceViewModel>>(list);

                var response = request.CreateResponse(HttpStatusCode.OK, responseData);
                return response;
            });
        }


        [Route("create")]
        [HttpPost]
        [AllowAnonymous]
        public HttpResponseMessage Create(HttpRequestMessage req, ProvinceViewModel provinceVm)
        {
            return CreateHttpResponse(req, () =>
            {
                HttpResponseMessage res = null;
                if (ModelState.IsValid)
                {
                    var province = new Province();
                    province.UpdateProvince(provinceVm);

                    _provinceService.Add(province);
                    _provinceService.SaveChanges();

                    var resData = Mapper.Map<Province, ProvinceViewModel>(province);
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