using CreateDB.Common;
using System.Collections.Generic;

namespace CreateDB.ADOD.Entities
{
    public class ReleaseEjecutionEnvironment : IEntity
    {
        #region Ctor.
        public ReleaseEjecutionEnvironment()
        {
            EnvironmentName = string.Empty;
            LastDeploymentStatus = string.Empty;
            Deployments = new HashSet<Deployment>();
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public int AzureDevOpsId { get; set; }
        public int ReleaseEjecutionId { get; set; }
        public int? EnvironmentId { get; set; }
        public string EnvironmentName { get; set; }
        public string LastDeploymentStatus { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual ReleaseEjecution ReleaseEjecution { get; set; }
        public virtual Environment Environment { get; set; }
        public virtual ICollection<Deployment> Deployments { get; set; }
        #endregion
    }
}
