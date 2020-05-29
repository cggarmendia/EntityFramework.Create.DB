using CreateDB.Common;
using System;
using System.Collections.Generic;

namespace CreateDB.ADOD.Entities
{
    public class Organization : IEntity
    {
        #region Ctor.
        public Organization()
        {
            CreatedOn = DateTime.Now;
            Projects = new HashSet<Project>();
        }
        #endregion

        #region Properties.
        public int Id { get; set; }
        public string Name { get; set; }
        public string AzureDevOpsName { get; set; }
        public string Description { get; set; }
        public DateTime CreatedOn { get; set; }
        public string CreatedBy { get; set; }
        #endregion

        #region Navigation_Properties.
        public virtual ICollection<Project> Projects { get; set; }
        #endregion
    }
}
