using System.Collections.Generic;
using System.Threading.Tasks;

namespace SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces
{
    public interface IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        T GetById(int id);
        IReadOnlyList<T> ListAll();
        IReadOnlyList<T> List(ISpecification<T> spec);
        T Add(T entity);
        int Update(T entity);
        int Delete(T entity);
        int Count(ISpecification<T> spec);
    }
}
