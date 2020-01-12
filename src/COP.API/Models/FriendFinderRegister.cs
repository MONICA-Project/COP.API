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
    public partial class FriendFinderRegister : IEquatable<FriendFinderRegister>
    {

        /// <summary>
        /// Wristband ID
        /// </summary>
        /// <value>ID of wristband</value>
        [DataMember(Name = "wristbandId")]
        public string WristbandId { get; set; }

        /// <summary>
        /// Thing id
        /// </summary>
        /// <value>Thing id</value>
        [DataMember(Name = "nickName")]
        public string NickName { get; set; }





        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class FriendFinder {\n");
            sb.Append("  WristbandId: ").Append(WristbandId).Append("\n");
            sb.Append("  NickName: ").Append(NickName).Append("\n");
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
            return obj.GetType() == GetType() && Equals((FriendFinderRegister)obj);
        }

        /// <summary>
        /// Returns true if Thing instances are equal
        /// </summary>
        /// <param name="other">Instance of Thing to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(FriendFinderRegister other)
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
                    WristbandId == other.WristbandId ||
                    WristbandId != null &&
                    WristbandId.Equals(other.WristbandId)
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
                if (WristbandId != null)
                    hashCode = hashCode * 59 + WristbandId.GetHashCode();
               
                return hashCode;
            }
        }

        #region Operators
#pragma warning disable 1591

        public static bool operator ==(FriendFinderRegister left, FriendFinderRegister right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(FriendFinderRegister left, FriendFinderRegister right)
        {
            return !Equals(left, right);
        }

#pragma warning restore 1591
        #endregion Operators
    }
}
