using System;
using Microsoft.AspNetCore.Mvc;
using PartnerGroup.Api.Controllers.Core;
using Microsoft.AspNetCore.Authorization;
using PartnerGroup.Application.Contracts;
using PartnerGroup.Application.Command.Brand;

namespace PartnerGroup.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/v1/marcas")]
    public class BrandController : BaseController
    {
        private readonly IBrandService _service;
        public BrandController(IBrandService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Brands()
        {
            try
            {
                var result = _service.Brands();
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult Brand(long id)
        {
            try
            {
                var result = _service.Brand(id);
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }

        [HttpGet("{id:int}/patrimonios")]
        public IActionResult BrandPatrimony(long id)
        {
            try
            {
                var result = _service.PatrimonyByBrandId(id);
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }

        [HttpPost]
        public IActionResult NewBrand([FromBody] BrandCommand command)
        {
            try
            {
                var result = _service.NewBrand(command);
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdateBrand(long id, [FromBody] BrandCommand command)
        {
            try
            {
                var result = _service.UpdateBrand(id, command);
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeleteBrand(long id)
        {
            try
            {
                var result = _service.DeleteBrand(id);
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }
    }
}
