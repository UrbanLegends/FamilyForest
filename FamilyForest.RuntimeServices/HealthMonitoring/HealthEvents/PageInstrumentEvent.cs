using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web.Management;
using System.Web;

namespace FamilyForest.RuntimeServices.HealthMonitoring.HealthEvents
{
    /// <summary>
    /// This class is used to instrument the Web Page(.aspx) execution time.
    /// </summary>
    internal class PageInstrumentEvent : InstrumentationEvent
    {
       
        public PageInstrumentEvent(string requestType, string requestValue, MethodBase eventSource, string requestUrl, long milliseconds, HttpContext context, string customerId, string message)
            : base(requestType, requestValue, eventSource, requestUrl, milliseconds, context, customerId, message)
        {
        }

        /// <summary>
        /// Add additional meta data to the log.
        /// </summary>
        /// <param name="formatter">The web formatter object.  This is used to add additional info to the log.</param>
        public override void FormatCustomEventDetails(WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);
        }
    }
}
