using CreateDB.Common;

namespace CreateDB.ADOD.Entities
{
    public class Artifact : IEntity
    {
        #region Ctor.
        public Artifact()
        {
            Type = string.Empty;
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public int ReleaseEjecutionId { get; set; }
        public string AzureDevOpsId { get; set; }
        public string Type { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual ReleaseEjecution ReleaseEjecution { get; set; }
        #endregion
    }
}
