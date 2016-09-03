#region Using namespaces.
using System;
using System.Net;
using System.Runtime.Serialization;
#endregion


namespace iCafe.Service.ErrorHelper
{
    /// <summary>
    /// Api Exception
    /// </summary>
    public class ApiException : Exception, IApiExceptions
    {
        #region Public Serializable properties.
        
        public int ErrorCode { get; set; }
        
        public string ErrorDescription { get; set; }
        
        public HttpStatusCode HttpStatus { get; set; }
        
        string reasonPhrase = "ApiException";

        
        public string ReasonPhrase
        {
            get { return this.reasonPhrase; }

            set { this.reasonPhrase = value; }
        }
        #endregion
    }
}