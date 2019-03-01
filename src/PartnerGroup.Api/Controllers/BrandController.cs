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

        [HttpPut]
        public IActionResult UpdateBrand([FromQuery] long id, [FromBody] BrandCommand command)
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
    }
}
