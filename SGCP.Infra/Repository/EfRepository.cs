using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using SystèmeGestionConsultationPrescriptions.SharedKernel.Interfaces;
using SystèmeGestionConsultationPrescriptions.SharedKernel;
using SystèmeGestionConsultationPrescriptions.Infrastructure.Specifications;

namespace SystèmeGestionConsultationPrescriptions.Infrastructure.Repository
{
    public class EfRepository<T> : IAsyncRepository<T>, IRepository<T> where T : BaseEntity, IAggregateRoot
    {
        protected readonly SystèmeGestionConsultationPrescriptionsDBContext _SystèmeGestionConsultationPrescriptionsContext;

        public EfRepository(SystèmeGestionConsultationPrescriptionsDBContext systèmeGestionConsultationPrescriptionsContext)
        {
            _SystèmeGestionConsultationPrescriptionsContext = systèmeGestionConsultationPrescriptionsContext;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _SystèmeGestionConsultationPrescriptionsContext.Set<T>().AddAsync(entity);
            await _SystèmeGestionConsultationPrescriptionsContext.SaveChangesAsync();
            return entity;

        }

        public T Add(T entity)
        {
            _SystèmeGestionConsultationPrescriptionsContext.Set<T>().Add(entity);
            _SystèmeGestionConsultationPrescriptionsContext.SaveChanges();
            return entity;

        }

        public async Task UpdateAsync(T entity)
        {
            _SystèmeGestionConsultationPrescriptionsContext.Entry(entity).State = EntityState.Modified;
            await _SystèmeGestionConsultationPrescriptionsContext.SaveChangesAsync();
        }

        public int Update(T entity)
        {
            _SystèmeGestionConsultationPrescriptionsContext.Entry(entity).State = EntityState.Modified;
            return _SystèmeGestionConsultationPrescriptionsContext.SaveChanges();
        }

        public async Task DeleteAsync(T entity)
        {
            _SystèmeGestionConsultationPrescriptionsContext.Set<T>().Remove(entity);
            await _SystèmeGestionConsultationPrescriptionsContext.SaveChangesAsync();
        }

        public int Delete(T entity)
        {
            _SystèmeGestionConsultationPrescriptionsContext.Set<T>().Remove(entity);
            return _SystèmeGestionConsultationPrescriptionsContext.SaveChanges();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Set<T>().FindAsync(id);
        }

        public T GetById(int id)
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Set<T>().Find(id);
        }

        public async Task<IReadOnlyList<T>> ListAllAsync()
        {
            return await _SystèmeGestionConsultationPrescriptionsContext.Set<T>().ToListAsync();
        }

        public IReadOnlyList<T> ListAll()
        {
            return _SystèmeGestionConsultationPrescriptionsContext.Set<T>().ToList();
        }

        public async Task<IReadOnlyList<T>> ListAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).ToListAsync();
        }

        public IReadOnlyList<T> List(ISpecification<T> spec)
        {
            return ApplySpecification(spec).ToList();
        }


        private IQueryable<T> ApplySpecification(ISpecification<T> spec)
        {
            return SpecificationEvaluator<T>.GetQuery(_SystèmeGestionConsultationPrescriptionsContext.Set<T>().AsQueryable(), spec);
        }

        public async Task<int> CountAsync(ISpecification<T> spec)
        {
            return await ApplySpecification(spec).CountAsync();
        }

        public int Count(ISpecification<T> spec)
        {
            return ApplySpecification(spec).Count();
        }

    }
}
