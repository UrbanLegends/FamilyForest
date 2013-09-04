using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Management;
using System.Diagnostics;
using System.Reflection;
using System.Web;

namespace FamilyForest.RuntimeServices.HealthMonitoring.HealthEvents
{
    internal abstract class LogEvent : WebRequestEvent
    {
        private string correlatorId = string.Empty;
        private TraceEventType eventType = TraceEventType.Information;
        private LogCategory category = new LogCategory();
        private MethodBase methodBase;
        private HttpContext context;
        private string customerId = string.Empty;
        private System.Exception ex;
        private string sessionId = string.Empty;
        DateTime timeStamp;



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
        /// Property will return unique correlatorId for each request.
        /// </summary>
        public string CorrelatorId
        {
            get { return correlatorId; }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return Log.Category object.
        /// </summary>
        public LogCategory Category
        {
            get { return this.category; }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return severity of event type.
        /// </summary>
        public TraceEventType Severity
        {
            get
            {
                return this.eventType;
            }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return the MethodBase object.
        /// </summary>
        public MethodBase MethodBase
        {
            get
            {
                return this.methodBase;
            }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return the current HttpContext.
        /// </summary>
        public HttpContext Context
        {
            get
            {
                return this.context;
            }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return the exception object.
        /// </summary>
        public System.Exception Exception
        {
            get
            {
                return this.ex;
            }
        }

        /// <summary>
        /// This is a get only property.
        /// Property will return the User ID of the logged in user.
        /// </summary>
        public string CustomerId
        {
            get
            {
                return this.customerId;
            }
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
        ///  Calls the System.Web.Management.WebRequestEvent class with specified event parameters.
        /// </summary>
        /// <param name="category">The Log.Category object.</param>
        /// <param name="severity">The TraceEventType object</param>
        /// <param name="message">The message to log.</param>
        /// <param name="methodBase">The MethodBase object.</param>
        /// <param name="context">The HttpContext of the current executing request.</param>
        public LogEvent(LogCategory category, TraceEventType severity, string message, MethodBase methodBase, HttpContext context) :
            base(message, methodBase.Name, WebEventCodes.WebExtendedBase + 5001)
        {
            if (context != null)
            {
                //this.correlatorId = RuntimeUtilities.GetCorrelationId(context);
            }
            //this.category = category;
            this.eventType = severity;
            this.methodBase = methodBase;
            this.context = context;
            this.timeStamp = DateTime.Now;
        }

        /// <summary>
        ///  Calls the System.Web.Management.WebRequestEvent class with specified event parameters.
        /// </summary>
        /// <param name="category">The Log.Category object.</param>
        /// <param name="severity">The TraceEventType object</param>
        /// <param name="message">The message to log.</param>
        /// <param name="ex">The exception object.</param>
        /// <param name="methodBase">The MethodBase object.</param>
        /// <param name="context">The HttpContext of the current executing request.</param>
        /// <param name="customerId">The customerId of the logged in user.</param>        
        public LogEvent(LogCategory category, TraceEventType severity, string message, System.Exception ex, MethodBase methodBase, HttpContext context, string customerId)
            : base(message, methodBase.Name, WebEventCodes.WebExtendedBase + 5001)
        {
            this.ex = ex;
            if (context != null)
            {
                //this.correlatorId = RuntimeUtilities.GetCorrelationId(context);
            }
            this.category = category;
            this.eventType = severity;
            this.methodBase = methodBase;
            this.context = context;
            this.customerId = customerId;
            this.timeStamp = DateTime.Now;
            if (context != null && context.Session != null)
            {
                this.sessionId = context.Session.SessionID;
            }
            if (this.ex != null && this.ex.Source == null)
            {
                this.ex.Source = methodBase.ReflectedType.Assembly.GetName().Name;
            }
        }


        /// <summary>
        ///  Calls the System.Web.Management.WebRequestEvent class with specified event parameters.
        /// </summary>
        /// <param name="category">The Log.Category object.</param>
        /// <param name="severity">The TraceEventType object</param>
        /// <param name="message">The message to log.</param>
        /// <param name="ex">The exception object.</param>
        /// <param name="methodBase">The MethodBase object.</param>
        /// <param name="context">The HttpContext of the current executing request.</param>
        public LogEvent(LogCategory category, TraceEventType severity, string message, System.Exception ex, MethodBase methodBase, HttpContext context)
            : base(message, methodBase.Name, WebEventCodes.WebExtendedBase + 5001)
        {
            this.ex = ex;
            if (context != null)
            {
                //this.correlatorId = RuntimeUtilities.GetCorrelationId(context);
            }
            this.category = category;
            this.eventType = severity;
            this.methodBase = methodBase;
            this.context = context;
            this.timeStamp = DateTime.Now;
            if (context != null && context.Session != null)
            {
                this.sessionId = context.Session.SessionID;
            }
            if (this.ex != null && this.ex.Source == null)
            {
                this.ex.Source = methodBase.ReflectedType.Assembly.GetName().Name;
            }
        }

        /// <summary>
        ///  Calls the System.Web.Management.WebRequestEvent class with specified event parameters.
        /// </summary>
        /// <param name="category">The Log.Category object.</param>
        /// <param name="severity">The TraceEventType object</param>
        /// <param name="message">The message to log.</param>
        /// <param name="methodBase">The MethodBase object.</param>
        /// <param name="context">The HttpContext of the current executing request.</param>
        /// <param name="customerId">The customerId of the logged in user.</param>
        public LogEvent(LogCategory category, TraceEventType severity, string message, MethodBase methodBase, HttpContext context, string customerId)
            : this(category, severity, message, methodBase, context)
        {
            if (context != null)
            {
                //this.correlatorId = RuntimeUtilities.GetCorrelationId(context);
            }
            this.category = category;
            this.eventType = severity;
            this.methodBase = methodBase;
            this.context = context;
            this.customerId = customerId;
            this.timeStamp = DateTime.Now;
            if (context != null && context.Session != null)
            {
                this.sessionId = context.Session.SessionID;
            }
        }


        /// <summary>
        /// Add additional meta data to the log.
        /// </summary>
        /// <param name="formatter">The web formatter object.  This is used to add additional info to the log.</param>
        public override void FormatCustomEventDetails(WebEventFormatter formatter)
        {
            base.FormatCustomEventDetails(formatter);

            //formatter.AppendLine("ApplicationName: " + RuntimeUtilities.ApplicationName);
            //formatter.AppendLine("TimeZone: " + Utility.AbbreviateTimezone(dt));
            //formatter.AppendLine("TimeStampEastern: " + Utility.SchwabEST(dt));
            //formatter.AppendLine("TimeStampLocal: " + Utility.SchwabLocalTime(dt));
            //formatter.AppendLine("UserName: " + RuntimeUtilities.UserName);
            //formatter.AppendLine("CorrelatorID: " + RuntimeUtilities.CorrelationID);

        }
    }
}
