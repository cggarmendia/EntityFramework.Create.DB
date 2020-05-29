using CreateDB.Common;
using System;

namespace CreateDB.ADOD.Entities
{
    public class Deployment : IEntity
    {
        #region Ctor.
        public Deployment()
        {
            RequestedBy = string.Empty;
            RequestedFor = string.Empty;
            OperationStatus = string.Empty;
            Reason = string.Empty;
            Status = string.Empty;
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public int AzureDevOpsId { get; set; }
        public int ReleaseEjecutionEnvironmentId { get; set; }
        public int Attempt { get; set; }
        public DateTime LastModifiedOn { get; set; }
        public bool HasStarted { get; set; }
        public string RequestedBy { get; set; }
        public string RequestedFor { get; set; }
        public string OperationStatus { get; set; }
        public string Reason { get; set; }
        public string Status { get; set; }

        #endregion

        #region Navigation_Properties.
        public virtual ReleaseEjecutionEnvironment ReleaseEjecutionEnvironment { get; set; }
        #endregion
    }
}
