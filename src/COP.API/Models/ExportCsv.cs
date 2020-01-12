using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace COP.API.Models
{
        ///  
    /// </summary>
    [DataContract]
    public partial class ExportCsv : IEquatable<ExportCsv>
    {
        /// <summary>
        /// Thing id
        /// </summary>
        /// <value>Thing id</value>
        [DataMember(Name = "thingId")]
        public string ThingId { get; set; }

        /// <summary>
        /// ObservationType
        /// </summary>
        /// <value>Type of observation, i.e. LAeq et c</value>
        [DataMember(Name = "observationType")]
        public string ObservationType { get; set; }

        /// <summary>
        /// startTime
        /// </summary>
        /// <value>Start time for export</value>
        [DataMember(Name = "startTime")]
        public DateTime StartTime { get; set; }

        /// <summary>
        /// endTime
        /// </summary>
        /// <value>End time for export</value>
        [DataMember(Name = "endTime")]
        public DateTime EndTime { get; set; }






        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class ExportCsv {\n");
            sb.Append("  ThingId: ").Append(ThingId).Append("\n");
            sb.Append("  ObservationType: ").Append(ObservationType).Append("\n");
            sb.Append("  StartTime: ").Append(StartTime).Append("\n");
            sb.Append("  endTime: ").Append(EndTime).Append("\n");
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
            return obj.GetType() == GetType() && Equals((ExportCsv)obj);
        }

        /// <summary>
        /// Returns true if Thing instances are equal
        /// </summary>
        /// <param name="other">Instance of Thing to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(ExportCsv other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    ObservationType == other.ObservationType ||
                    ObservationType != null &&
                    ObservationType.Equals(other.ObservationType)
                ) &&
                (
                    ThingId == other.ThingId ||
                    ThingId != null &&
                    ThingId.Equals(other.ThingId)
                ) &&
                (
                    EndTime == other.EndTime ||
                    EndTime != null &&
                    EndTime.Equals(other.EndTime)
                ) &&
                (
                    StartTime == other.StartTime ||
                    StartTime != null &&
                    StartTime.Equals(other.StartTime)
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
                if (ObservationType != null)
                    hashCode = hashCode * 59 + ObservationType.GetHashCode();
                if (ThingId != null)
                    hashCode = hashCode * 59 + ThingId.GetHashCode();
                if (StartTime != null)
                    hashCode = hashCode * 59 + StartTime.GetHashCode();
                if (EndTime != null)
                    hashCode = hashCode * 59 + EndTime.GetHashCode();

                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(ExportCsv left, ExportCsv right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(ExportCsv left, ExportCsv right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
