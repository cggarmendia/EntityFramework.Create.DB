using CreateDB.Common;
using System;
using System.Collections.Generic;

namespace CreateDB.ADOD.Entities
{
    /// <summary>
    /// Definition of build.
    /// </summary>
    public class BuildPipeline : IEntity
    {
        #region Ctor.
        public BuildPipeline()
        {
            BuildEjecutions = new HashSet<BuildEjecution>();
            CreatedOn = DateTime.Now;
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public int ProjectId { get; set; }
        public int AzureDevOpsId { get; set; }
        public int Revision { get; set; }
        public string Name { get; set; }
        public string AuthoredBy { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual Project Project { get; set; }
        public virtual ICollection<BuildEjecution> BuildEjecutions { get; set; }
        #endregion
    }
}
