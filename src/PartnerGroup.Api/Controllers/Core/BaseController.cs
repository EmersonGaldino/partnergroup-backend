using System;
using System.Linq;
using Flunt.Notifications;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace PartnerGroup.Api.Controllers.Core
{
    public abstract class BaseController : Controller
    {
        protected new IActionResult Response(object result = null, IEnumerable<Notification> notifications = null)
        {
            try
            {
                if (!notifications.Any())
                    return Ok(new { success = true, data = result });
                else
                    return BadRequest(new { success = false, errors = notifications });
            }
            catch (Exception ex)
            {
                return Error(ex);
            }
        }

        protected IActionResult Error(Exception ex)
        {
            return BadRequest(new { success = false, errors = new[] { ex.Message, ex.InnerException?.Message } });
        }
    }
}
