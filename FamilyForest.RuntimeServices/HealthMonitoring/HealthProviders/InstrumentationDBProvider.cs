using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Management;
using System.Security.Permissions;
using System.Collections.Specialized;
using FamilyForest.RuntimeServices.HealthMonitoring.HealthEvents;

namespace FamilyForest.RuntimeServices.HealthMonitoring.HealthProviders
{
    [AspNetHostingPermission(SecurityAction.LinkDemand, Level = AspNetHostingPermissionLevel.Minimal),
         AspNetHostingPermission(SecurityAction.InheritanceDemand, Level = AspNetHostingPermissionLevel.Minimal), PermissionSet(SecurityAction.InheritanceDemand, Unrestricted = true)]
    public class InstrumentationDBProvider : BufferedWebEventProvider
    {
        // The local path of the file where
        // to store event information.
        string LogProcedureName = "WriteInstrumentationLog"; //"WriteAuditLog";
        string ErrorProcedureName = "WriteErrorLog";

        //private string providerName, buffer, bufferMode;

        string connectionString = "";

        bool logMessage = true;

        bool loggingError;
        bool loggingInstrument;

        /// <summary>
        /// These constants represent database column names.
        /// </summary>
        #region Constants
        private const string FieldRequestType = "RequestType";
        private const string FieldRequestValue = "RequestValue";
        private const string FieldMilliseconds = "Milliseconds";
        private const string FieldTimestamp = "Timestamp";
        private const string FieldMachineName = "MachineName";
        private const string FieldRequestUrl = "RequestUrl";
        private const string FieldCorrelatorId = "CorrelatorID";
        private const string FieldcustomerId = "CustomerID";
        private const string FieldLogId = "LogId";
        private const string FieldSessionId = "SessionId";
        private const string FieldMessage = "Message";
        private const string FieldRequestSource = "RequestSource";
      
        private const string FieldQueryString = "QueryString";

        //        private const string ErrorRequestType   = "15";
        private const string Exempted_URL_Key = "Exempted_URL_List";

        // Error Logging Constant
        private const string FieldSeverity = "Severity";
        private const string FieldLogMsg = "LogMsg";
        private const string FieldExSrc = "ExSrc";
        private const string FieldExMsg = "ExTypeMsg";
        private const string FieldInnerExMsg = "InnerExTypeMsg";
        private const string FieldInnerMostExMsg = "InnerMostExTypeMsg";

        #endregion

        /// <summary>
        /// Initializes the provider.
        /// </summary>
        /// <param name="name">The name of the Provider</param>
        /// <param name="config">The configuration Information</param>
        public override void Initialize(string name,
         NameValueCollection config)
        {

            //connectionString = config.Get("connectionStringName");
            string configDescription = "";
            RepairAttribute(config, "connectionStringName", ref connectionString);
            RepairAttribute(config, "LogMessage", ref configDescription);
            if (string.IsNullOrEmpty(configDescription))
            {
                logMessage = true;
            }
            else if (string.Compare(configDescription, "false", true) == 0)
            {
                logMessage = false;
            }
            base.Initialize(name, config);
        }

        /// <summary>
        /// To remove Custom Attributes.
        /// </summary>
        /// <param name="config">The configuration information</param>
        /// <param name="attrib">The custom Attribute to Remove from configuration</param>
        /// <param name="connectionString">The connectionString Name</param>
        private void RepairAttribute(NameValueCollection config, string attrib, ref string connectionString)
        {
            connectionString = config.Get(attrib);
            config.Remove(attrib);
        }

        /// <summary>
        /// Processes the incoming events.
        /// This method performs custom processing and, if buffering is enabled, 
        /// it calls the base.ProcessEvent to buffer the event information.
        /// </summary>
        /// <param name="raisedEvent">The raised Event details</param>
        public override void ProcessEvent(WebBaseEvent raisedEvent)
        {
            if (UseBuffering)
            {
                base.ProcessEvent(raisedEvent);     // Buffering enabled, call the base event to buffer event information.
            }
            else
            {
                // Store the information in the specified file.
                StoreToDB(raisedEvent);
            }

        }

        /// <summary>
        /// Processes the messages that have been buffered.
        /// It is called by the ASP.NET when the flushing of 
        /// the buffer is required according to the parameters 
        /// defined in the 'bufferModes' element of the 
        /// 'healthMonitoring' configuration section.
        /// </summary>
        /// <param name="flushInfo">The buffered Events Information</param>
        public override void ProcessEventFlush(WebEventBufferFlushInfo flushInfo)
        {
            if (null != flushInfo)
            {
                foreach (WebBaseEvent raisedEvent in flushInfo.Events)
                    StoreToDB(raisedEvent);
            }
        }

        /// <summary>
        /// Performs standard shutdown.
        /// </summary>
        public override void Shutdown()
        {
            // Flush the buffer, if needed.
            Flush();
        }

        /// <summary>
        /// Store information in a Database
        /// </summary>
        /// <param name="flushInfo">The buffered Event Information</param>
        private void StoreToDB(WebBaseEvent flushInfo)
        {
            InstrumentationEvent evt = (flushInfo as InstrumentationEvent);
         
         
        }
    }
   
}
