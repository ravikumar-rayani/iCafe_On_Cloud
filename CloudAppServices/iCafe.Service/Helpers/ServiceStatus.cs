using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Runtime.Serialization;
using Newtonsoft.Json;

namespace iCafe.Service.Helpers
{
    #region Status Object Class
    /// <summary>
    /// Public class to return input status
    /// </summary>
    public class ServiceStatus
    {
        #region Public properties.
        /// <summary>
        /// Get/Set property for accessing Status Code
        /// </summary>
        [JsonProperty("StatusCode")]
        
        public int StatusCode { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        [JsonProperty("StatusMessage")]
        
        public string StatusMessage { get; set; }
        /// <summary>
        /// Get/Set property for accessing Status Message
        /// </summary>
        [JsonProperty("ReasonPhrase")]
        
        public string ReasonPhrase { get; set; }

        #endregion
    }

    #endregion
}