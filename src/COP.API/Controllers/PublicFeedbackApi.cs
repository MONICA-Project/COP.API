/*
 * MONICA COP API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 0.1.0
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
    public class PublicFeedbackApiController : Controller
    {
        /// 
        /// </summary>
        /// <remarks>Get the avrages</remarks>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpGet]
        [Route("/publicfeedbackAVG")]
        [ValidateModelState]
        [SwaggerOperation("PublicfeedbackAVGGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(PublicFeedbackResultListResponse), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult PublicfeedbackAVGGet()
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
            List<PublicFeedbackResult> result = new List<PublicFeedbackResult>();
            try
            {
                DatabaseInterface.DBPublicFeedback dBPublicFeedback = new DatabaseInterface.DBPublicFeedback();
                if (!dBPublicFeedback.GetAvg( ref errorMessage, ref result))
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

            return new ObjectResult(result);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <remarks>add a new feedback</remarks>
        /// <param name="pubfeedback">small</param>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpPost]
        [Route("/publicfeedback")]
        [ValidateModelState]
        [SwaggerOperation("PublicfeedbackPost")]
        [SwaggerResponse(statusCode: 200, type: typeof(GeneralResponse), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult PublicfeedbackPost([FromBody]PublicFeedback pubfeedback)
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
            try
            {
                DatabaseInterface.DBPublicFeedback dBPublicFeedback = new DatabaseInterface.DBPublicFeedback();
                if (!dBPublicFeedback.AddOrUpdatePublicFeedback(pubfeedback.Phoneid, pubfeedback.FeedbackType, (double) pubfeedback.FeedbackValue, ref errorMessage))
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
            exampleJson = "{\n  \"success\" : true,\n  \"newid\" : " + newZoneID.ToString() + "\n}";

            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<GeneralPostResponse>(exampleJson)
            : default(GeneralPostResponse);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <remarks>results</remarks>
        /// <param name="feedbackType"></param>
        /// <response code="200">Success</response>
        /// <response code="0">Error</response>
        [HttpGet]
        [Route("/publickfeedbackresult/{feedbackType}")]
        [ValidateModelState]
        [SwaggerOperation("PublickfeedbackresultFeedbackTypeGet")]
        [SwaggerResponse(statusCode: 200, type: typeof(PublicFeedbackResult), description: "Success")]
        [SwaggerResponse(statusCode: 0, type: typeof(ErrorResponse), description: "Error")]
        public virtual IActionResult PublickfeedbackresultFeedbackTypeGet([FromRoute][Required]string feedbackType)
        { 
            //TODO: Uncomment the next line to return response 200 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(200, default(PublicFeedbackResult));

            //TODO: Uncomment the next line to return response 0 or use other options such as return this.NotFound(), return this.BadRequest(..), ...
            // return StatusCode(0, default(ErrorResponse));

            string exampleJson = null;
            exampleJson = "{\n  \"feedback_meanvalue\" : 6.02745618307040320615897144307382404804229736328125,\n  \"count\" : 0.80082819046101150206595775671303272247314453125,\n  \"feedbackType\" : \"feedbackType\"\n}";
            
            var example = exampleJson != null
            ? JsonConvert.DeserializeObject<PublicFeedbackResult>(exampleJson)
            : default(PublicFeedbackResult);
            //TODO: Change the data returned
            return new ObjectResult(example);
        }
    }
}
