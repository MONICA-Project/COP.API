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
    public partial class HeatMapImage : IEquatable<HeatMapImage>
    { 
        /// <summary>
        /// Image Url
        /// </summary>
        /// <value>Image Url</value>
        [DataMember(Name="url")]
        public string Url { get; set; }

        /// <summary>
        /// Heatmap Lower Left Corner
        /// </summary>
        /// <value>Heatmap Lower Left Corner</value>
        [DataMember(Name="latStart")]
        public decimal? LatStart { get; set; }

        /// <summary>
        /// Heatmap Lower Left Corner
        /// </summary>
        /// <value>Heatmap Lower Left Corner</value>
        [DataMember(Name="lonStart")]
        public decimal? LonStart { get; set; }

        /// <summary>
        /// Heatmap Upper Right Corner
        /// </summary>
        /// <value>Heatmap Upper Right Corner</value>
        [DataMember(Name="latEnd")]
        public decimal? LatEnd { get; set; }

        /// <summary>
        /// Heatmap Upper Right Corner
        /// </summary>
        /// <value>Heatmap Upper Right Corner</value>
        [DataMember(Name="lonEnd")]
        public decimal? LonEnd { get; set; }

        /// <summary>
        /// Heatmap rotation from true north
        /// </summary>
        /// <value>Heatmap rotation from true north</value>
        [DataMember(Name="RoatationDegrees")]
        public decimal? RoatationDegrees { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class HeatMapImage {\n");
            sb.Append("  Url: ").Append(Url).Append("\n");
            sb.Append("  LatStart: ").Append(LatStart).Append("\n");
            sb.Append("  LonStart: ").Append(LonStart).Append("\n");
            sb.Append("  LatEnd: ").Append(LatEnd).Append("\n");
            sb.Append("  LonEnd: ").Append(LonEnd).Append("\n");
            sb.Append("  RoatationDegrees: ").Append(RoatationDegrees).Append("\n");
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
            return obj.GetType() == GetType() && Equals((HeatMapImage)obj);
        }

        /// <summary>
        /// Returns true if HeatMapImage instances are equal
        /// </summary>
        /// <param name="other">Instance of HeatMapImage to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(HeatMapImage other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    Url == other.Url ||
                    Url != null &&
                    Url.Equals(other.Url)
                ) && 
                (
                    LatStart == other.LatStart ||
                    LatStart != null &&
                    LatStart.Equals(other.LatStart)
                ) && 
                (
                    LonStart == other.LonStart ||
                    LonStart != null &&
                    LonStart.Equals(other.LonStart)
                ) && 
                (
                    LatEnd == other.LatEnd ||
                    LatEnd != null &&
                    LatEnd.Equals(other.LatEnd)
                ) && 
                (
                    LonEnd == other.LonEnd ||
                    LonEnd != null &&
                    LonEnd.Equals(other.LonEnd)
                ) && 
                (
                    RoatationDegrees == other.RoatationDegrees ||
                    RoatationDegrees != null &&
                    RoatationDegrees.Equals(other.RoatationDegrees)
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
                    if (Url != null)
                    hashCode = hashCode * 59 + Url.GetHashCode();
                    if (LatStart != null)
                    hashCode = hashCode * 59 + LatStart.GetHashCode();
                    if (LonStart != null)
                    hashCode = hashCode * 59 + LonStart.GetHashCode();
                    if (LatEnd != null)
                    hashCode = hashCode * 59 + LatEnd.GetHashCode();
                    if (LonEnd != null)
                    hashCode = hashCode * 59 + LonEnd.GetHashCode();
                    if (RoatationDegrees != null)
                    hashCode = hashCode * 59 + RoatationDegrees.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(HeatMapImage left, HeatMapImage right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(HeatMapImage left, HeatMapImage right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
