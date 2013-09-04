using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Reflection;
using System.Diagnostics;
using System.Web.Management;

namespace FamilyForest.RuntimeServices.HealthMonitoring.HealthEvents
{
    /// <summary>
    /// This is the base error Event class.  
    /// This class will be used to log any exceptions in the application.  
    /// </summary>
    internal abstract class BaseErrorEvent : LogEvent
    {
                
        public BaseErrorEvent(LogCategory category, TraceEventType severity, string message, MethodBase methodBase, System.Exception ex, HttpContext context, string customerId)
            : base(category, severity, message, ex, methodBase, context, customerId)
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
