using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Services
{
    //Aqui se especializa las interfaz. Serviran cuando alguna clase implemente alguno de los comportamientos.
    public interface IDataService<T>
    {
        // Esto es el patron CRUD
        List<ValidationResult> ValidateModel(T model);
        //En include model es donde se puede incluir el producto de un artista para que traiga los productos de los artistas.
        List<T> Get(Expression<Func<T, bool>> whereExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunction = null, string includeModels = "");
        T GetById(int id);
        T Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Delete(int id);


    }
}
