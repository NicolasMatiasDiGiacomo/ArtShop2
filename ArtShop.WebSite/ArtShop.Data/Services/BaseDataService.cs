using ArtShop.Data.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ArtShop.Data.Services
{
    //Aqui se arma una clase Generica que es del tipo plantilla, que implementa la interfaz IDataServices que tambien envia una plantilla que servira para todos.
    //Se agrega una restriccion(where) indicando que la plantilla es del tipo identitybase , para que las entidades puedan implementar todas las propiedades de la interfaz Identitybase.
    //Y se permite que sea instanciado (new).
    public class BaseDataService<T> : IDataService<T> where T : IdentityBase, new()
    {
        //Creo unsolo contexto , no multiples contextos para cada operacion.
        protected ArtShopDbContext _db;

        public BaseDataService()
        {
            _db = new ArtShopDbContext();
        }


        public List<ValidationResult> ValidateModel(T model)
        {
            ValidationContext v = new ValidationContext(model);
            List<ValidationResult> r = new List<ValidationResult>();

            bool validate = Validator.TryValidateObject(model, v, r, true);

            if (validate)
            {
                return null;
            }
            else
            {
                return r;
            }
        }

        public virtual List<T> Get(Expression<Func<T, bool>> whereExpression = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderFunction = null, string includeEntities = "")
        {
            IQueryable<T> query = _db.Set<T>();

            if (whereExpression != null)
            {
                query = query.Where(whereExpression);
            }

            var entity = includeEntities.Split(new char[] { ',' }, StringSplitOptions.RemoveEmptyEntries);

            foreach (var model in entity)
            {
                query = query.Include(model);
            }

            if (orderFunction != null)
            {
                query = orderFunction(query);
            }

            return query.ToList();
        }

        public virtual T GetById(int id)
        {
            return _db.Set<T>().SingleOrDefault(x => x.Id == id);
        }

        public virtual void Update(T entity)
        {
            _db.Entry(entity).State = EntityState.Modified;
            _db.SaveChanges();
        }

        public virtual void Delete(T entity)
        {
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public virtual void Delete(int id)
        {
            var entity = _db.Set<T>().Find(id);
            _db.Set<T>().Remove(entity);
            _db.SaveChanges();
        }

        public virtual T Create(T entity)
        {
            _db.Set<T>().Add(entity);
            _db.SaveChanges();
            return entity;
        }
    }
}