using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Management;
using System.Reflection;
using System.Web;

namespace FamilyForest.RuntimeServices.HealthMonitoring.HealthEvents
{
    /// <summary>
    /// This is the abstract instrumentation Event class.  
    /// This class is base for all custom Instrumentation Events.
    /// </summary>
    internal abstract class InstrumentationEvent : WebRequestEvent
    {

        string relatorId = string.Empty;
        string requestType = "";
        string requestValue = "";
        long milliseconds;
        string requestUrl = "";
        string customerId = "";
        string sessionId = "";
        MethodBase eventSource;
        DateTime timeStamp;
        string logMessage = string.Empty;
      
        /// <summary>
        /// This is a get only property.
        /// Property will return unique correlatorId for each request.
        /// </summary>
        public string CorrelatorId
        {
            get { return relatorId; }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return type of request raising the event.
        /// </summary>
        public string RequestType
        {
            get { return this.requestType; }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return source of request raising the event.
        /// </summary>
        public string RequestValue
        {
            get { return this.requestValue; }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return user ID of Logged in user.
        /// </summary>
        public string CustomerId
        {
            get { return this.customerId; }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return request url.
        /// </summary>
        public string RequestUrl
        {
            get { return this.requestUrl; }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return time in millisecond.
        /// </summary>
        public long Milliseconds
        {
            get { return this.milliseconds; }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return the object that is the source of the event.
        /// </summary>
        public MethodBase EventSource
        {
            get
            {
                return this.eventSource;
            }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return Session ID.
        /// </summary>
        public string SessionId
        {
            get { return this.sessionId; }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return current DateTime.
        /// </summary>
        public DateTime TimeStamp
        {
            get { return timeStamp; }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return Message to Log.
        /// </summary>
        public string LogMessage
        {
            get { return this.logMessage; }
        }

      
        public InstrumentationEvent(string requestType, string requestValue, MethodBase eventSource, string requestUrl, long milliseconds, HttpContext context, string customerId, string message)
            : base(requestType, requestValue, WebEventCodes.WebExtendedBase + 5001)
        {

            if (context != null)
            {
                
            }
            this.requestType = requestType;
            this.requestValue = requestValue;
            this.milliseconds = milliseconds;
            this.requestUrl = requestUrl;
            this.customerId = customerId;
            this.eventSource = eventSource;
            this.timeStamp = DateTime.Now;
            this.logMessage = message;
            if (context != null && context.Session != null)
            {
                this.sessionId = context.Session.SessionID;
            }
            else if (context != null && context.Items["SessionId"] != null)
            {
                this.sessionId = context.Items["SessionId"].ToString();
            }

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
