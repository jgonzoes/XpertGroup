/*
 * XpertGroup Prueba
 *
 * Este es el api que se podra consumir desde la aplicacion 
 *
 * OpenAPI spec version: 1.0.0
 * Contact: jgonzoe@gmail.com
 * Generated by: https://github.com/swagger-api/swagger-codegen.git
 */

using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.Serialization;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Solicitud : IEquatable<Solicitud>
    { 
        /// <summary>
        /// Casos de prueba
        /// </summary>
        /// <value>Casos de prueba</value>
        [Required]
        [DataMember(Name="T")]
        public int? T { get; set; }

        /// <summary>
        /// Gets or Sets Atributo
        /// </summary>
        [Required]
        [DataMember(Name="atributo")]
        public List<Atributo> Atributo { get; set; }



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
            return obj.GetType() == GetType() && Equals((Solicitud)obj);
        }

        /// <summary>
        /// Returns true if Solicitud instances are equal
        /// </summary>
        /// <param name="other">Instance of Solicitud to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Solicitud other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    T == other.T ||
                    T != null &&
                    T.Equals(other.T)
                ) && 
                (
                    Atributo == other.Atributo ||
                    Atributo != null &&
                    Atributo.SequenceEqual(other.Atributo)
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
                    if (T != null)
                    hashCode = hashCode * 59 + T.GetHashCode();
                    if (Atributo != null)
                    hashCode = hashCode * 59 + Atributo.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Solicitud left, Solicitud right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Solicitud left, Solicitud right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
