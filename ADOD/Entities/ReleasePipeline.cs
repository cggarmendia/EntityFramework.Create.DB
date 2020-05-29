using CreateDB.Common;
using System;
using System.Collections.Generic;

namespace CreateDB.ADOD.Entities
{
    /// <summary>
    /// Definition of release.
    /// </summary>
    public class ReleasePipeline : IEntity
    {
        #region Ctor.
        public ReleasePipeline()
        {
            ReleaseEjecutions = new HashSet<ReleaseEjecution>();
            Environments = new HashSet<Environment>();
            ModifiedBy = string.Empty;
            IsDeleted = false;
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int AzureDevOpsId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? ModifiedOn { get; set; }
        public string ModifiedBy { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual Project Project { get; set; }
        public virtual ICollection<ReleaseEjecution> ReleaseEjecutions { get; set; }
        public virtual ICollection<Environment> Environments { get; set; }
        #endregion
    }
}