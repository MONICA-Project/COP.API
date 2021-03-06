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
using System.ComponentModel.DataAnnotations;
using COP.API.Attributes;
using COP.API.Models;

namespace COP.API.Controllers
{ 
    /// <summary>
    /// 
    /// </summary>
    public class ProAcousticFeedbackTypeApiController : Controller
    { 
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>add a new Pro Acoustic Feedback type</remarks>
        /// <param name="feedbackTypeName">Feedback Type Name</param>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpPost]
        [Route("/proacousticfeedbacktype")]
        [ValidateModelState]
        [SwaggerOperation("ProacousticfeedbacktypePost")]
        [SwaggerResponse(statusCode: 200, type: typeof(GeneralResponse), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult ProacousticfeedbacktypePost([FromBody]ProAcousticFeedbackType feedbackTypeName, [FromHeader] string Authorization)
        {
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            
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
            long newThingID = 0;
            string errorMessage = "";
            try
            {
                DatabaseInterface.DBProfAcousticFeedbackTypes dBpaf = new DatabaseInterface.DBProfAcousticFeedbackTypes();

                if (!dBpaf.AddFeedbackType(feedbackTypeName.FeedbackTypeName, feedbackTypeName.FeedbackTypeDescription, ref errorMessage, ref newThingID))
                    return BadRequest("Internal Server Error:" + errorMessage);

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
        /// <remarks>list all Pro Acoustic Feedback types</remarks>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpGet]
        [Route("/proacousticfeedbacktypes")]
        [ValidateModelState]
        [SwaggerOperation("ProacousticfeedbacktypesGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(ProAcousticFeedbackTypelistResponse), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult ProacousticfeedbacktypesGet( [FromHeader] string Authorization)
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
            long newZoneID = 0;
            string errorMessage = "";
            List<ProAcousticFeedbackType> results = new List<ProAcousticFeedbackType>();
            try
            {
                DatabaseInterface.DBProfAcousticFeedbackTypes dBpaf = new DatabaseInterface.DBProfAcousticFeedbackTypes();
                if (!dBpaf.ListProAcousticFeedbackTypes(ref errorMessage, ref results))
                    return BadRequest("Internal Server Error:" + errorMessage);

            }
            catch (Exception e)
            {
                return BadRequest("Internal Server Error:" + e.Message);
            }


            return new ObjectResult(results);
        }
    }
}
