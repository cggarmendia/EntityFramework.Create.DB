using CreateDB.Common;
using System.Collections.Generic;

namespace CreateDB.ADOD.Entities
{
    public class Environment : IEntity
    {
        #region Ctor.
        public Environment()
        {
            Name = string.Empty;
            ReleaseEjecutionEnvironments = new HashSet<ReleaseEjecutionEnvironment>();
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public int AzureDevOpsId { get; set; }
        public int ReleasePipelineId { get; set; }
        public int Rank { get; set; }
        public string Name { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual ReleasePipeline ReleasePipeline { get; set; }
        public virtual ICollection<ReleaseEjecutionEnvironment> ReleaseEjecutionEnvironments { get; set; }
        #endregion
    }
}
