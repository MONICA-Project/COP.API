/*
 * MONICA COP API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 0.3.0
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
using Newtonsoft.Json.Linq;
using System.ComponentModel.DataAnnotations;
using COP.API.Attributes;
using COP.API.Models;
using Microsoft.AspNetCore.SignalR;

namespace COP.API.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class IncidentApiController : Controller
    {
        private readonly IHubContext<EventHubs.COPUpdate> _hubContext;

        public IncidentApiController(IHubContext<EventHubs.COPUpdate> hubContext)
        {
            _hubContext = hubContext;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>get zone Incident id</remarks>
        /// <param name="incidentId"></param>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpGet]
        [Route("/incident/{incidentId}")]
        [ValidateModelState]
        [SwaggerOperation("IncidentIncidentIdGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(Incident), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult IncidentIncidentIdGet([FromRoute][Required]string incidentId,[FromHeader][Required()]string Authorization)
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
            Incident foundIncident = null;
            try
            {
                DatabaseInterface.DBIncident dBi = new DatabaseInterface.DBIncident();

                if (!dBi.GetIncident(int.Parse(incidentId), ref errorMessage, ref foundIncident))
                    return BadRequest("Internal Server Error:" + errorMessage);

            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error:" + e.Message);
            }



            return new ObjectResult(foundIncident);
        }
  

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>Update Incident</remarks>
        /// <param name="incidentId"></param>
        /// <param name="status">incident status</param>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpPut]
        [Route("/incident/{incidentId}")]
        [ValidateModelState]
        [SwaggerOperation("IncidentIncidentIdPut")]
        [SwaggerResponse(statusCode: 200, type: typeof(Incident), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult IncidentIncidentIdPut([FromRoute][Required]string incidentId, [FromBody]Incident status, [FromHeader][Required()] string Authorization)
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
            long newThingID = 0;
            string errorMessage = "";
            try
            {
                DatabaseInterface.DBIncident dBi = new DatabaseInterface.DBIncident();

                if (!dBi.UpdateIncident(int.Parse(incidentId),status.Description, status.Type, status.Position, (int)status.Prio, status.Status, (double)status.Probability, status.Interventionplan, (DateTime)status.Incidenttime, status.Wbid,status.Telephone, status.AdditionalMedia, status.MediaType, status.Area, ref errorMessage, ref newThingID))
                    return BadRequest("Internal Server Error:" + errorMessage);
                dynamic message = new JObject();
                message.type = "statusupdate";
                message.incidentid = int.Parse(incidentId);
                message.incidenttype = status.Type;
                message.status = status.Status;
                message.prio = status.Prio;
                message.timestamp = DateTime.Now;
                message.mediatype = status.MediaType;
                message.additionalmedia = status.AdditionalMedia;
                message.wbid = status.Wbid;
                string strMessage = message.ToString();
                _hubContext.Clients.All.SendAsync("Incidents",strMessage);
            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error:" + e.Message);
            }


            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GeneralResponse));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(ErrorResponse));


            string exampleJson = null;
            exampleJson = "{\n  \"success\" : true,\n  \"newid\" : " + newThingID.ToString() + "\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GeneralPostResponse>(exampleJson)
            : default(GeneralPostResponse);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>add a new incident</remarks>
        /// <param name="incidentType">type</param>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpPost]
        [Route("/incident")]
        [ValidateModelState]
        [SwaggerOperation("IncidentPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(GeneralResponse), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult IncidentPost([FromBody]Incident incidentType, [FromHeader][Required()]string Authorization)
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
            long newThingID = 0;
            string errorMessage = "";
            try
            {
                DatabaseInterface.DBIncident dBi = new DatabaseInterface.DBIncident();

                if (!dBi.AddIncident(incidentType.Description,incidentType.Type,incidentType.Position,(int) incidentType.Prio,incidentType.Status,(double) incidentType.Probability,incidentType.Interventionplan,(DateTime) incidentType.Incidenttime,  incidentType.Wbid, incidentType.Telephone, incidentType.AdditionalMedia, incidentType.MediaType, incidentType.Area, ref errorMessage, ref newThingID))
                    return BadRequest("Internal Server Error:" + errorMessage);
                dynamic message = new JObject();
                message.type = "newincident";
                message.incidentid = newThingID;
                message.status = incidentType.Status;
                message.incidenttype = incidentType.Type;
                message.prio = incidentType.Prio;
                message.timestamp = DateTime.Now;
                message.mediatype = incidentType.MediaType;
                message.additionalmedia = incidentType.AdditionalMedia;
                message.wbid = incidentType.Wbid;
                string strMessage = message.ToString();
                _hubContext.Clients.All.SendAsync("Incidents", strMessage);
            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error:" + e.Message);
            }


            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(GeneralResponse));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(ErrorResponse));


            string exampleJson = null;
            exampleJson = "{\n  \"success\" : true,\n  \"newid\" : " + newThingID.ToString() + "\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GeneralPostResponse>(exampleJson)
            : default(GeneralPostResponse);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>list all zones</remarks>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="take"></param>
        /// <param name="skip"></param>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpGet]
        [Route("/incidents")]
        [ValidateModelState]
        [SwaggerOperation("IncidentsGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(GetIncidentListResponse), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult IncidentsGet([FromQuery]string type, [FromQuery]string status, [FromQuery]int? take, [FromQuery]int? skip, [FromHeader][Required()]string Authorization)
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
            int defaultTake = 1000;
            int defaultSkip = 0;
            if (take == null)
                take = defaultTake;
            if (skip == null)
                skip = defaultSkip;
            if (Authorization != settings.testToken)
                return BadRequest("Not allowed");
            long newZoneID = 0;
            string errorMessage = "";
            List<Incident> results = new List<Incident>();
            try
            {
                DatabaseInterface.DBIncident dBi = new DatabaseInterface.DBIncident();
                if (!dBi.ListIncidents(type,status,(int) take,(int) skip, ref errorMessage, ref results))
                    return BadRequest("Internal Server Error:" + errorMessage);

            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error:" + e.Message);
            }


            return new ObjectResult(results);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>list all zones</remarks>
        /// <param name="type"></param>
        /// <param name="status"></param>
        /// <param name="Authorization">Authorization Header</param>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpGet]
        [Route("/media")]
        [ValidateModelState]
        [SwaggerOperation("IncidentsGetImage")]
        [SwaggerResponse(statusCode: 200)]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult IncidentsGetMedia([FromQuery]string media, [FromQuery]string mediaType, [FromHeader][Required()]string Authorization)
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
                    return BadRequest("Error in the input");
                }
                else
                    return BadRequest(ModelState);

            }
            if (Authorization != settings.testToken)
                return BadRequest("Not allowed");
            try
            {
                string mimeType = "";
                var image = System.IO.File.OpenRead(settings.mediaPath + media);
                if (mediaType == "picture")
                    mimeType = "image/png";
                else if (mediaType == "video")
                    mimeType = "video/mp4";
                else if (mediaType == "audio")
                    mimeType = "video/3gpp";
                else
                    return BadRequest("Internal Server Error: Unknown media type:"+ mediaType);
                return File(image, mimeType);


            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error:" + e.Message);
            }


           
        }

    }
}
