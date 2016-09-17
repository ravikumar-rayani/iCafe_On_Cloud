#region Using namespaces.
using System.Web.Script.Serialization;
using System.Data;
using System.Collections.Generic;
using System;

#endregion

namespace iCafe.Service.Helpers
{
    public static class JSONHelper
    {
         #region Public extension methods.
        /// <summary>
        /// Extened method of object class
        /// Converts an object to a json string.
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public static string ToJSON(this object obj)
        {
            var serializer = new JavaScriptSerializer();
            try
            {
                return serializer.Serialize(obj);
            }
            catch(Exception ex)
            {
                return ex.Message;
            }
        }
         #endregion
    }
}