﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace _1_AppCore.Base
{
    public interface IServis<TEntity,TModel> where TEntity:class,new() where TModel: class,new()
    {
        // Repository üzerinden opsiyonel parametre alarak gönderilen lambda expression'a göre (predicate) sonuç query'sini döner
        IQueryable<TModel> Listele(Expression<Func<TModel, bool>> predicate = null);

        // Repository üzerinden primary key'e göre (id) tek bir sonuç döner
        TModel IdyeGoreListele(int id);

        // Parametre olarak gönderilen kaydı repository'e ekler ve saveChanges true ise unit of work üzerinden veritabanına kaydetme işlemini gerçekleştirir
        void Ekle(TModel model, bool saveChanges = true);

        // Parametre olarak gönderilen kaydı repository'de günceller ve saveChanges true ise unit of work üzerinden veritabanına kaydetme işlemini gerçekleştirir
        void Guncelle(TModel model, bool saveChanges = true);

        // Parametre olarak gönderilen primary key'e göre (id) repository'den silme işlemi yapar ve saveChanges true ise unit of work üzerinden veritabanına kaydetme işlemini gerçekleştirir
        void Sil(int id, bool saveChanges = true);

        // Repository üzerinde yapılan toplu değişikliklerin veritabanına unit of work ile tek seferde kaydedilmesini sağlar
        int Kaydet();
    }
}
