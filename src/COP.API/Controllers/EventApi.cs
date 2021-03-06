/*
 * MONICA COP API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 0.9.2
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.WebUtilities;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Primitives;
using Swashbuckle.AspNetCore.SwaggerGen;
using Newtonsoft.Json;
using System.ComponentModel.DataAnnotations;
using COP.API.Attributes;
using COP.API.Models;

namespace COP.API.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class EventApiController : Controller
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>get zone Incident id</remarks>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpGet]
        [Route("//event")]
        [ValidateModelState]
        [SwaggerOperation("EventGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Event), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult EventGet([FromHeader] string Authorization)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(Event));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(ErrorResponse));
            if (!ModelState.IsValid)
            {
                var error = ModelState.SelectMany(x => x.Value.Errors).First();
                if (error.ErrorMessage != null && error.ErrorMessage != String.Empty)
                {
                    return BadRequest(error.ErrorMessage);
                }
                else if (error.Exception?.Message != null)
                {
                    return BadRequest("Faulty input");
                }
                else
                    return BadRequest(ModelState);

            }


            string errorMessage = "";
            Event foundEvent = null;
            try
            {
                DatabaseInterface.DBEvent dBe = new DatabaseInterface.DBEvent();

                if (!dBe.GetEvent( ref errorMessage, ref foundEvent))
                    return BadRequest("Internal Server Error:" + errorMessage);

            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error:" + e.Message);
            }



            return new ObjectResult(foundEvent);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Update Event</remarks>
        /// <param name="status">Event information</param>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpPut]
        [Route("//event")]
        [ValidateModelState]
        [SwaggerOperation("EventPut")]
        [SwaggerResponse(statusCode: 200, type: typeof(Event), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult EventPut([FromBody]Event status, [FromHeader][Required]string Authorization)
        {
            if (!ModelState.IsValid)
            {
                var error = ModelState.SelectMany(x => x.Value.Errors).First();
                if (error.ErrorMessage != null && error.ErrorMessage != String.Empty)
                {
                    return BadRequest(error.ErrorMessage);
                }
                else if (error.Exception?.Message != null)
                {
                    return BadRequest("Faulty input");
                }
                else
                    return BadRequest(ModelState);

            }

            if (Authorization != settings.testToken)
                return BadRequest("Not allowed");
            string errorMessage = "";
            long foundEvent = 0;
            try
            {
                DatabaseInterface.DBEvent dBe = new DatabaseInterface.DBEvent();

                if (!dBe.UpdateEvent(status.Name,status.City, status.Lat,status.Lon, status.Zoom, (DateTime) status.Start, (DateTime)status.End, ref errorMessage, ref foundEvent))
                    return BadRequest("Internal Server Error:" + errorMessage);

            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error:" + e.Message);
            }
            return new ObjectResult(status);
        }
    }
}
