using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Web;
using System.Diagnostics;
using System.Web.Management;

namespace FamilyForest.RuntimeServices.HealthMonitoring.HealthEvents
{
    /// <summary>
    /// This is the error Event class.  
    /// This class will be used to log all exceptions having Error category in the application.
    /// </summary>
    internal class ErrorEvent : BaseErrorEvent
    {
       
        public ErrorEvent(string message, MethodBase methodBase, System.Exception ex, HttpContext context, string customerId)
            : base(LogCategory.Error, TraceEventType.Error, message, methodBase, ex, context, customerId)
        {

        }


       
        public override void FormatCustomEventDetails(WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);
        }

    }
}
