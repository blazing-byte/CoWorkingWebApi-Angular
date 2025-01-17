﻿using Ardalis.Specification;

namespace CoWorking.Contracts.Data
{
    public interface IRepository<TEntity> where TEntity : class, IBaseEntity
    {
        Task<TEntity> AddAsync(TEntity entity);

        Task<IEnumerable<TEntity>> GetAllAsync();

        Task<TEntity> GetByKeyAsync<TKey>(TKey key);

        Task UpdateAsync(TEntity entity);

        Task DeleteAsync(TEntity entity);

        Task<int> SaveChangesAsync();

        Task AddRangeAsync(List<TEntity> entities);

        Task<TEntity> GetFirstBySpecAsync(ISpecification<TEntity> specification);

        Task<IEnumerable<TReturn>> GetListBySpecAsync<TReturn>(ISpecification<TEntity, TReturn> specification);

        Task<IEnumerable<TEntity>> GetListBySpecAsync(ISpecification<TEntity> specification);
    }
}
