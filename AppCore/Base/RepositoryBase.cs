using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Web;

namespace _1_AppCore.Base
{
    public abstract class RepositoryBase<TEntity> : IDisposable where TEntity : class, new()
    {

        #region DI

        private readonly DbContext db;

        protected RepositoryBase(DbContext dbParameter)
        {
            db = dbParameter;
        }

        #endregion

        #region Listele
        public virtual List<TEntity> TumunuListele()
        {
            try
            {
                return db.Set<TEntity>().ToList();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }

        public virtual List<TEntity> TumunuListele(Expression<Func<TEntity,bool>>predicate)
        {
            try
            {
                return db.Set<TEntity>().Where(predicate).ToList();
            }
            catch (Exception exc)
            {

                throw exc;
            }

        }
#endregion

        #region IDyeGoreListeleme
        public virtual TEntity IdyeGoreListele(int id)
        {
            try
            {
                return db.Set<TEntity>().Find(id);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        public virtual TEntity IdyeGoreListele(Expression<Func<TEntity, bool>> predicate)
        {
            try
            {
                return db.Set<TEntity>().SingleOrDefault(predicate);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
        #endregion

        #region Ekle
        public virtual void Ekle(TEntity entity)
        {
            try
            {
                 db.Set<TEntity>().Add(entity);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
#endregion

        #region Guncelle
        public virtual void Guncelle(TEntity entity)
        {
            try
            {
                db.Entry(entity).State=EntityState.Modified;
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
#endregion

        #region Sil
        public virtual void Sil(int id)
        {
            try
            {
                var entity = db.Set<TEntity>().Find(id);
                db.Set<TEntity>().Remove(entity);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }

        
        public virtual void Sil(TEntity entity)
        {
            try
            {
                db.Set<TEntity>().Remove(entity);
            }
            catch (Exception exc)
            {

                throw exc;
            }
        }
        #endregion

        #region Kaydet
        public virtual int Kaydet()
        {
            try
            {
                return db.SaveChanges();
            }
            catch (Exception exc)
            {
                throw exc;
            }
        }
        #endregion

        #region Dispose
        private bool disposed = false;
        protected virtual void Dispose(bool disposing)
        {
            db.Dispose();
            this.disposed = true;
        }
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}