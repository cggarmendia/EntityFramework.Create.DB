using CreateDB.Common;
using System;

namespace CreateDB.ADOD.Entities
{
    public class BuildChange : IEntity
    {
        #region Ctor.
        public BuildChange()
        {
            Message = string.Empty;
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public int BuildEjecutionId { get; set; }
        public string AzureDevOpsId { get; set; }
        public string Message { get; set; }
        public string Author { get; set; }
        public DateTime CreatedOn { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual BuildEjecution BuildEjecution { get; set; }
        #endregion
    }
}
