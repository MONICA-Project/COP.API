/*
 * MONICA
 *
 * Images.
 *
 * OpenAPI spec version: 1.0.0
 * 
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using System;
using System.Linq;
using System.IO;
using System.Text;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace COP.API.Models
{ 
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Image : IEquatable<Image>
    { 
        /// <summary>
        /// Image ID.
        /// </summary>
        /// <value>Image ID.</value>
        [DataMember(Name="id")]
        public int? Id { get; set; }

        /// <summary>
        /// Gets or Sets ImgUrl
        /// </summary>
        [DataMember(Name="imgUrl")]
        public string ImgUrl { get; set; }

        /// <summary>
        /// Gets or Sets University
        /// </summary>
        [JsonConverter(typeof(Newtonsoft.Json.Converters.StringEnumConverter))]
        public enum UniversityEnum
        {
            
            /// <summary>
            /// Enum LUUEnum for LUU
            /// </summary>
            [EnumMember(Value = "LUU")]
            LUU = 1,
            
            /// <summary>
            /// Enum LBUEnum for LBU
            /// </summary>
            [EnumMember(Value = "LBU")]
            LBU = 2
        }

        /// <summary>
        /// Gets or Sets University
        /// </summary>
        [DataMember(Name="university")]
        public UniversityEnum? University { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Image {\n");
            sb.Append("  Id: ").Append(Id).Append("\n");
            sb.Append("  ImgUrl: ").Append(ImgUrl).Append("\n");
            sb.Append("  University: ").Append(University).Append("\n");
            sb.Append("}\n");
            return sb.ToString();
        }

        /// <summary>
        /// Returns the JSON string presentation of the object
        /// </summary>
        /// <returns>JSON string presentation of the object</returns>
        public string ToJson()
        {
            return JsonConvert.SerializeObject(this, Formatting.Indented);
        }

        /// <summary>
        /// Returns true if objects are equal
        /// </summary>
        /// <param name="obj">Object to be compared</param>
        /// <returns>Boolean</returns>
        public override bool Equals(object obj)
        {
            if (ReferenceEquals(null, obj)) return false;
            if (ReferenceEquals(this, obj)) return true;
            return obj.GetType() == GetType() && Equals((Image)obj);
        }

        /// <summary>
        /// Returns true if Image instances are equal
        /// </summary>
        /// <param name="other">Instance of Image to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Image other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Id == other.Id ||
                    Id != null &&
                    Id.Equals(other.Id)
                ) && 
                (
                    ImgUrl == other.ImgUrl ||
                    ImgUrl != null &&
                    ImgUrl.Equals(other.ImgUrl)
                ) && 
                (
                    University == other.University ||
                    University != null &&
                    University.Equals(other.University)
                );
        }

        /// <summary>
        /// Gets the hash code
        /// </summary>
        /// <returns>Hash code</returns>
        public override int GetHashCode()
        {
            unchecked // Overflow is fine, just wrap
            {
                var hashCode = 41;
                // Suitable nullity checks etc, of course :)
                    if (Id != null)
                    hashCode = hashCode * 59 + Id.GetHashCode();
                    if (ImgUrl != null)
                    hashCode = hashCode * 59 + ImgUrl.GetHashCode();
                    if (University != null)
                    hashCode = hashCode * 59 + University.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Image left, Image right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Image left, Image right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
