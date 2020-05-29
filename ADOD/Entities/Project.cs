using CreateDB.Common;
using System;
using System.Collections.Generic;

namespace CreateDB.ADOD.Entities
{
    public class Project : IEntity
    {
        #region Ctor.
        public Project()
        {
            Name = string.Empty;
            BuildPipelines = new HashSet<BuildPipeline>();
            ReleasePipelines = new HashSet<ReleasePipeline>();
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        /// <summary>
        /// Azure DevOps ID.
        /// </summary>
        public Guid AzureDevOpsId { get; set; }
        public int OrganizationId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual Organization Organization { get; set; }
        public virtual ICollection<BuildPipeline> BuildPipelines { get; set; }
        public virtual ICollection<ReleasePipeline> ReleasePipelines { get; set; }
        #endregion
    }
}
