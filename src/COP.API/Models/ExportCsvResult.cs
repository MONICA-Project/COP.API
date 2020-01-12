﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace COP.API.Models
{
  

    [DataContract]
    public partial class ExportCsvResult : IEquatable<ExportCsvResult>
    {
        /// <summary>
        /// Thing id
        /// </summary>
        /// <value>Thing id</value>
        [DataMember(Name = "path")]
        public string Path { get; set; }






        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ExportCsvResult {\n");
            sb.Append("  Path: ").Append(Path).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ExportCsvResult)obj);
        }

        /// <summary>
        /// Returns true if Thing instances are equal
        /// </summary>
        /// <param name="other">Instance of Thing to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ExportCsvResult other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    Path == other.Path ||
                    Path != null &&
                    Path.Equals(other.Path)
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
                if (Path != null)
                    hashCode = hashCode * 59 + Path.GetHashCode();


                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ExportCsvResult left, ExportCsvResult right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExportCsvResult left, ExportCsvResult right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
