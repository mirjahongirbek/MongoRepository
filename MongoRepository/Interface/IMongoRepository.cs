using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace MongoRepository.Interface
{
    public interface IMongoRepository<TEntity> where TEntity : class, IMongoEntity
    {
        Task<TEntity> DeleteAsync(string id);
        Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicat);
        Task<TEntity> FindFirstAsync(string id);
        Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> predicat);
        Task<ICollection<TEntity>> GetAllAsync();
        Task<TEntity> GetByIdAsync(string id);
        Task<string> InserOneAsync(TEntity entity);
        Task<TEntity> SaveAsync(TEntity entity);
        Task<bool> UpdateOneAsync<TKey>(TEntity documentToModify, UpdateDefinition<TEntity> update);
        Task<bool> UpdateOneAsync<TKey>(TEntity modifiedDocument);
        Task<bool> UpdateOneAsync(TEntity documentToModify, UpdateDefinition<TEntity> update);
        Task<bool> UpdateOneAsync(TEntity modifiedDocument);
        Task<bool> UpdateOneAsync<TField>(TEntity documentToModify, Expression<Func<TEntity, TField>> field, TField value);
        Task<bool> UpdateOneAsync<TField>(FilterDefinition<TEntity> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null);
        Task<bool> UpdateOneAsync<TKey, TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null);
        Task<bool> UpdateOneAsync<TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null);
        Task<bool> UpdateOneAsync<TKey, TField>(TEntity documentToModify, Expression<Func<TEntity, TField>> field, TField value);
    }
}
