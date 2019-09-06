using RestSharp;
using System;
using System.Collections.Generic;
using XpertGroup.Helper.Client;
using XpertGroup.Models;
using XpertGroupIC.Constntes;

namespace XpertGroup.Helper.Api
{
    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public interface IServicioApi
    {
        /// <summary>
        /// envie los requerimientos del servicio expuesta 
        /// </summary>
        /// <param name="body">Todos los parametros requeridos para enviar el servicio</param>
        /// <returns></returns>
        IRestResponse CrearSolicitud(SolicitudModel body);
    }

    /// <summary>
    /// Represents a collection of functions to interact with the API endpoints
    /// </summary>
    public class ServicioApi : IServicioApi
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="ServicioApi"/> class.
        /// </summary>
        /// <param name="apiClient"> an instance of ApiClient (optional)</param>
        /// <returns></returns>
        public ServicioApi(ApiClient apiClient = null)
        {
            if (apiClient == null) // use the default one in Configuration
                this.ApiClient = Configuration.DefaultApiClient;
            else
                this.ApiClient = apiClient;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="ServicioApi"/> class.
        /// </summary>
        /// <returns></returns>
        public ServicioApi(String basePath)
        {
            this.ApiClient = new ApiClient(basePath);
        }

        /// <summary>
        /// Sets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public void SetBasePath(String basePath)
        {
            this.ApiClient.BasePath = basePath;
        }

        /// <summary>
        /// Gets the base path of the API client.
        /// </summary>
        /// <param name="basePath">The base path</param>
        /// <value>The base path</value>
        public String GetBasePath(String basePath)
        {
            return this.ApiClient.BasePath;
        }

        /// <summary>
        /// Gets or sets the API client.
        /// </summary>
        /// <value>An instance of the ApiClient</value>
        public ApiClient ApiClient { get; set; }

        /// <summary>
        /// envie los requerimientos del servicio expuesta 
        /// </summary>
        /// <param name="body">Todos los parametros requeridos para enviar el servicio</param> 
        /// <returns></returns>            
        public IRestResponse CrearSolicitud(SolicitudModel body)
        {
            if (body == null) throw new ApiException(400, Constantes.SERVICIO_ERROR_400);

            var path = Constantes.NOMBRE_SERVICIO;
            path = path.Replace("{format}", "json");

            var queryParams = new Dictionary<String, String>();
            var headerParams = new Dictionary<String, String>();
            var formParams = new Dictionary<String, String>();
            var fileParams = new Dictionary<String, FileParameter>();
            String postBody = null;

            postBody = ApiClient.Serialize(body); // http body (model) parameter

            // authentication setting, if any
            String[] authSettings = new String[] { };

            // make the HTTP request
            IRestResponse response = (IRestResponse)ApiClient.CallApi(path, Method.POST, queryParams, postBody, headerParams, formParams, fileParams, authSettings);

            if (((int)response.StatusCode) >= 400)
                throw new ApiException((int)response.StatusCode, Constantes.SERVICIO_ERROR_40X + response.Content, response.Content);
            else if (((int)response.StatusCode) == 0)
                throw new ApiException((int)response.StatusCode, Constantes.SERVICIO_ERROR_40X + response.ErrorMessage, response.ErrorMessage);

            return response;
        }

    }
}