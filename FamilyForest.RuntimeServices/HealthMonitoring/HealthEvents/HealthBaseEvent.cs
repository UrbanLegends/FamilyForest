using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Management;
using System.Diagnostics;
using System.Reflection;

namespace FamilyForest.RuntimeServices.HealthMonitoring.HealthEvents
{
    /// <summary>
    /// This class is used to raise all custom events
    /// </summary>
    internal static class HealthBaseEvent
    {
        /// <summary>
        /// Raises the specified event.
        /// </summary>
        /// <param name="eventraised">A System.Web.Management.WebBaseEvent object</param>
        public static void Raise(WebBaseEvent eventraised)
        {
           
            WebBaseEvent.Raise(eventraised);
           
        }
    }
}
