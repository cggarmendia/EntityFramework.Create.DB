﻿using System.Data.Entity.ModelConfiguration;

namespace CreateDB.Common
{
    public abstract class DbContextBaseConfiguration<T> : EntityTypeConfiguration<T>
        where T : class, IEntity
    {
        #region Public Constructors

        //ToDo: Todas las entidades pudieran tener un atributo GuidStamp y ser configurado desde aquí para manejar la concurrencia
        /*
        public DbContextBaseConfiguration()
        {
            Property(e => e.GuidStamp).IsConcurrencyToken();
        }
        */
        #endregion Public Constructors
    }
}
