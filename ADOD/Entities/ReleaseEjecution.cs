using CreateDB.Common;
using System;
using System.Collections.Generic;

namespace CreateDB.ADOD.Entities
{
    public class ReleaseEjecution : IEntity
    {
        #region Ctor.
        public ReleaseEjecution()
        {
            Name = string.Empty;
            ModifiedBy = string.Empty;
            Artifacts = new HashSet<Artifact>();
            ReleaseEjecutionEnvironments = new HashSet<ReleaseEjecutionEnvironment>();
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public int ReleasePipelineId { get; set; }
        public int AzureDevOpsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual ReleasePipeline ReleasePipeline { get; set; }
        public virtual ICollection<Artifact> Artifacts { get; set; }
        public virtual ICollection<ReleaseEjecutionEnvironment> ReleaseEjecutionEnvironments { get; set; }
        #endregion
    }
}
