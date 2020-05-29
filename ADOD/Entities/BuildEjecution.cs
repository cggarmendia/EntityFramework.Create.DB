using CreateDB.Common;
using System;
using System.Collections.Generic;

namespace CreateDB.ADOD.Entities
{
    public class BuildEjecution : IEntity
    {
        #region Ctor.
        public BuildEjecution()
        {
            RequestedBy = string.Empty;
            Url = string.Empty;
            Status = string.Empty;
            Result = string.Empty;
            RequestedFor = string.Empty;
            BuildChanges = new HashSet<BuildChange>();
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public string Number { get; set; }
        public int BuildPipelineId { get; set; }
        public int AzureDevOpsId { get; set; }
        public string Url { get; set; }
        public string Status { get; set; }
        public string Result { get; set; }
        public string RequestedFor { get; set; }
        public string RequestedBy { get; set; }
        public DateTime StartOn { get; set; }
        public DateTime FinishOn { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual BuildPipeline BuildPipeline { get; set; }
        public virtual ICollection<BuildChange> BuildChanges { get; set; }
        #endregion
    }
}
