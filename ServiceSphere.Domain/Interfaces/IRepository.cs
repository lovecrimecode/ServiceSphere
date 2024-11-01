using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using ServiceSphere.Domain.Entities;

namespace ServiceSphere.Domain.Interfaces
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetByIdAsync(int id);
        Task<IEnumerable<T>> GetAllAsync();
        Task AddAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(int id);
    }

    //Creacion de una interfaz para cada clase
    public interface IEventRepository : IRepository<Event> { }
    public interface IGuestRepository : IRepository<Guest> { }
    public interface IServiceRepository : IRepository<Service> { }
    public interface ISupplierRepository : IRepository<Supplier> { }

}
