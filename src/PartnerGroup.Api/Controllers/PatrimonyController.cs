using System;
using Microsoft.AspNetCore.Mvc;
using PartnerGroup.Application.Contracts;
using PartnerGroup.Api.Controllers.Core;
using Microsoft.AspNetCore.Authorization;
using PartnerGroup.Application.Command.Patrimony;

namespace PartnerGroup.Api.Controllers
{
    [AllowAnonymous]
    [Route("api/v1/patrimonios")]
    public class PatrimonyController : BaseController
    {
        private readonly IPatrimonyService _service;
        public PatrimonyController(IPatrimonyService service)
        {
            _service = service;
        }

        [HttpGet]
        public IActionResult Patrimonies()
        {
            try
            {
                var result = _service.Patrimonies();
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }

        [HttpGet("{id:int}")]
        public IActionResult PatrimonyById(long id)
        {
            try
            {
                var result = _service.PatrimonyById(id);
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }

        [HttpPost]
        public IActionResult NewPatrimony([FromBody] PatrimonyCommand command)
        {
            try
            {
                var result = _service.NewPatrimony(command);
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }

        [HttpPut("{id:int}")]
        public IActionResult UpdatePatrimony(long id, [FromBody] PatrimonyCommand command)
        {
            try
            {
                var result = _service.UpdatePatrimony(id, command);
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }

        [HttpDelete("{id:int}")]
        public IActionResult DeletePatrimony(long id)
        {
            try
            {
                var result = _service.DeletePatrimony(id);
                return Response(result, _service.Notifications);
            }
            catch (Exception exception)
            {
                return Error(exception);
            }
        }
    }
}
