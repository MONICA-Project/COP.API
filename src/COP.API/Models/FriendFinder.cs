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
    public partial class FriendFinder : IEquatable<FriendFinder>
    {
        /// <summary>
        /// Thing id
        /// </summary>
        /// <value>Thing id</value>
        [DataMember(Name = "nickName")]
        public string NickName { get; set; }

        

        /// <summary>
        /// Thing latitude
        /// </summary>
        /// <value>Thing latitude</value>
        [DataMember(Name = "lat")]
        public decimal? Lat { get; set; }

        /// <summary>
        /// Thing latitude
        /// </summary>
        /// <value>Thing latitude</value>
        [DataMember(Name = "lon")]
        public decimal? Lon { get; set; }

        // <summary>
        /// Thing latitude
        /// </summary>
        /// <value>Thing latitude</value>
        [DataMember(Name = "lastSeen")]
        public string LastSeen { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FriendFinder {\n");
            sb.Append("  NickName: ").Append(NickName).Append("\n");
            sb.Append("  Lat: ").Append(Lat).Append("\n");
            sb.Append("  Lon: ").Append(Lon).Append("\n");
            sb.Append("  LastSeen: ").Append(LastSeen).Append("\n");
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
            return obj.GetType() == GetType() && Equals((FriendFinder)obj);
        }

        /// <summary>
        /// Returns true if Thing instances are equal
        /// </summary>
        /// <param name="other">Instance of Thing to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FriendFinder other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return
                (
                    NickName == other.NickName ||
                    NickName != null &&
                    NickName.Equals(other.NickName)
                ) &&
                (
                    Lat == other.Lat ||
                    Lat != null &&
                    Lat.Equals(other.Lat)
                ) &&
                (
                    LastSeen == other.LastSeen ||
                    LastSeen != null &&
                    LastSeen.Equals(other.LastSeen)
                ) &&
                (
                    Lon == other.Lon ||
                    Lon != null &&
                    Lon.Equals(other.Lon)
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
                if (NickName != null)
                    hashCode = hashCode * 59 + NickName.GetHashCode();
                if (Lat != null)
                    hashCode = hashCode * 59 + Lat.GetHashCode();
                if (Lon != null)
                    hashCode = hashCode * 59 + Lon.GetHashCode();
                if (LastSeen != null)
                    hashCode = hashCode * 59 + LastSeen.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(FriendFinder left, FriendFinder right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FriendFinder left, FriendFinder right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
