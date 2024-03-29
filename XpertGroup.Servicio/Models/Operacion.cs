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
using System.Runtime.Serialization;
using System.Text;

namespace IO.Swagger.Models
{
    /// <summary>
    /// 
    /// </summary>
    [DataContract]
    public partial class Operacion : IEquatable<Operacion>
    { 
        /// <summary>
        /// Gets or Sets _Operacion
        /// </summary>
        [DataMember(Name="operacion")]
        public string _Operacion { get; set; }

        /// <summary>
        /// Returns the string presentation of the object
        /// </summary>
        /// <returns>String presentation of the object</returns>
        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append("class Operacion {\n");
            sb.Append("  _Operacion: ").Append(_Operacion).Append("\n");
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
            return obj.GetType() == GetType() && Equals((Operacion)obj);
        }

        /// <summary>
        /// Returns true if Operacion instances are equal
        /// </summary>
        /// <param name="other">Instance of Operacion to be compared</param>
        /// <returns>Boolean</returns>
        public bool Equals(Operacion other)
        {
            if (ReferenceEquals(null, other)) return false;
            if (ReferenceEquals(this, other)) return true;

            return 
                (
                    _Operacion == other._Operacion ||
                    _Operacion != null &&
                    _Operacion.Equals(other._Operacion)
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
                    if (_Operacion != null)
                    hashCode = hashCode * 59 + _Operacion.GetHashCode();
                return hashCode;
            }
        }

        #region Operators
        #pragma warning disable 1591

        public static bool operator ==(Operacion left, Operacion right)
        {
            return Equals(left, right);
        }

        public static bool operator !=(Operacion left, Operacion right)
        {
            return !Equals(left, right);
        }

        #pragma warning restore 1591
        #endregion Operators
    }
}
