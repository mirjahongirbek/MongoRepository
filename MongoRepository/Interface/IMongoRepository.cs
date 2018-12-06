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
        string InserOne(TEntity entity);
        Task<ICollection<TEntity>> GetAll();
        TEntity FindFirst(string id);
        TEntity FindFirst(Expression<Func<TEntity, bool>> predicat);
        Task<TEntity> SaveAsync(TEntity entity);
        bool UpdateOne(TEntity modifiedDocument);
        bool UpdateOne<TField>(FilterDefinition<TEntity> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null);
        bool UpdateOne<TField>(TEntity documentToModify, Expression<Func<TEntity, TField>> field, TField value);
        bool UpdateOne<TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null);
        bool UpdateOne(TEntity documentToModify, UpdateDefinition<TEntity> update);
        bool UpdateOne<TKey>(TEntity modifiedDocument);
        bool UpdateOne<TKey>(TEntity documentToModify, UpdateDefinition<TEntity> update);
        bool UpdateOne<TKey, TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null);
        bool UpdateOne<TKey, TField>(TEntity documentToModify, Expression<Func<TEntity, TField>> field, TField value);
        Task<bool> UpdateOneAsync<TKey>(TEntity modifiedDocument);
        Task<bool> UpdateOneAsync(TEntity documentToModify, UpdateDefinition<TEntity> update);
        Task<bool> UpdateOneAsync<TField>(TEntity documentToModify, Expression<Func<TEntity, TField>> field, TField value);
        Task<bool> UpdateOneAsync<TField>(FilterDefinition<TEntity> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null);
        Task<bool> UpdateOneAsync<TKey, TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null);
    }
}
