using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace _1_AppCore.Base
{
    public class Repository<TEntity>: RepositoryBase<TEntity> where TEntity : class,new()
    {
        public Repository(DbContext dbParameter) :base(dbParameter)
        {

        }
    }
}