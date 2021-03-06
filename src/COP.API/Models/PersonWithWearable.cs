/*
 * MONICA COP API
 *
 * No description provided (generated by Swagger Codegen https://github.com/swagger-api/swagger-codegen)
 *
 * OpenAPI spec version: 0.9.0
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
    public partial class PersonWithWearable : IEquatable<PersonWithWearable>
    { 
        /// <summary>
        /// PersonId
        /// </summary>
        /// <value>PersonId</value>
        [DataMember(Name="personId")]
        public int? PersonId { get; set; }

        /// <summary>
        /// Person name
        /// </summary>
        /// <value>Person name</value>
        [DataMember(Name="name")]
        public string Name { get; set; }  

        /// <summary>
        /// Person status
        /// </summary>
        /// <value>Person status</value>
        [DataMember(Name="status")]
        public bool? Status { get; set; }


        /// <summary>
        /// Person role (e.g. GUARD, CREW, PARAMEDIC,POLICE)
        /// </summary>
        /// <value>Person role (e.g. GUARD, CREW, PARAMEDIC,POLICE)</value>
        [DataMember(Name="role")]
        public string Role { get; set; }

        /// <summary>
        /// Person role description
        /// </summary>
        /// <value>Person role description</value>
        [DataMember(Name="roleDescription")]
        public string RoleDescription { get; set; }

        /// <summary>
        /// Person latitude
        /// </summary>
        /// <value>Person latitude</value>
        [DataMember(Name="lat")]
        public decimal? Lat { get; set; }

        /// <summary>
        /// Person latitude
        /// </summary>
        /// <value>Person latitude</value>
        [DataMember(Name="lon")]
        public decimal? Lon { get; set; }

        /// <summary>
        /// time of wearable connection (e.g. &#39;2016-06-17T15:28:34Z&#39; (RFC 3339, ISO 8601))
        /// </summary>
        /// <value>time of wearable connection (e.g. &#39;2016-06-17T15:28:34Z&#39; (RFC 3339, ISO 8601))</value>
        [DataMember(Name="timestamp")]
        public DateTime? Timestamp { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class PersonWithWearable {\n");
            sb.Append("  PersonId: ").Append(PersonId).Append("\n");
            sb.Append("  Name: ").Append(Name).Append("\n");
            sb.Append("  Status: ").Append(Status).Append("\n");
            sb.Append("  Role: ").Append(Role).Append("\n");
            sb.Append("  RoleDescription: ").Append(RoleDescription).Append("\n");
            sb.Append("  Lat: ").Append(Lat).Append("\n");
            sb.Append("  Lon: ").Append(Lon).Append("\n");
            sb.Append("  Timestamp: ").Append(Timestamp).Append("\n");
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
            return obj.GetType() == GetType() && Equals((PersonWithWearable)obj);
        }

        /// <summary>
        /// Returns true if PersonWithWearable instances are equal
        /// </summary>
        /// <param name="other">Instance of PersonWithWearable to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(PersonWithWearable other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    PersonId == other.PersonId ||
                    PersonId != null &&
                    PersonId.Equals(other.PersonId)
                ) && 
                (
                    Name == other.Name ||
                    Name != null &&
                    Name.Equals(other.Name)
                ) && 
                (
                    Status == other.Status ||
                    Status != null &&
                    Status.Equals(other.Status)
                ) && 
                (
                    Role == other.Role ||
                    Role != null &&
                    Role.Equals(other.Role)
                ) && 
                (
                    RoleDescription == other.RoleDescription ||
                    RoleDescription != null &&
                    RoleDescription.Equals(other.RoleDescription)
                ) && 
                (
                    Lat == other.Lat ||
                    Lat != null &&
                    Lat.Equals(other.Lat)
                ) && 
                (
                    Lon == other.Lon ||
                    Lon != null &&
                    Lon.Equals(other.Lon)
                ) && 
                (
                    Timestamp == other.Timestamp ||
                    Timestamp != null &&
                    Timestamp.Equals(other.Timestamp)
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
                    if (PersonId != null)
                    hashCode = hashCode * 59 + PersonId.GetHashCode();
                    if (Name != null)
                    hashCode = hashCode * 59 + Name.GetHashCode();
                    if (Status != null)
                    hashCode = hashCode * 59 + Status.GetHashCode();
                    if (Role != null)
                    hashCode = hashCode * 59 + Role.GetHashCode();
                    if (RoleDescription != null)
                    hashCode = hashCode * 59 + RoleDescription.GetHashCode();
                    if (Lat != null)
                    hashCode = hashCode * 59 + Lat.GetHashCode();
                    if (Lon != null)
                    hashCode = hashCode * 59 + Lon.GetHashCode();
                    if (Timestamp != null)
                    hashCode = hashCode * 59 + Timestamp.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(PersonWithWearable left, PersonWithWearable right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(PersonWithWearable left, PersonWithWearable right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
