using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Reflection;
using System.Diagnostics;
using FamilyForest.RuntimeServices.HealthMonitoring.HealthEvents;

namespace FamilyForest.RuntimeServices.HealthMonitoring
{
    
    public static class EventManager
    {
        public static void RaisePageInstrumentationEvent(long milliseconds, MethodBase eventSource, string customerId, string message)
        {
           
            
                HealthBaseEvent.Raise(new PageInstrumentEvent("Page", "pageName", eventSource, HttpContext.Current.Request.Url.OriginalString, milliseconds, HttpContext.Current, customerId, message));
            


        }

        
    }
}
