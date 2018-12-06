using System.Threading.Tasks;
using MongoRepository.Interface;
namespace MongoRepository.Generic
{
    public class GenericRepository<TEntity> : IMongoRepository<TEntity> where TEntity:class, IMongoEntity
    {
        Task<TEntity> IMongoRepository<TEntity>.DeleteAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        Task<System.Collections.Generic.ICollection<TEntity>> IMongoRepository<TEntity>.FindAllAsync(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicat)
        {
            throw new System.NotImplementedException();
        }

        Task<TEntity> IMongoRepository<TEntity>.FindFirstAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        Task<TEntity> IMongoRepository<TEntity>.FindFirstAsync(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> predicat)
        {
            throw new System.NotImplementedException();
        }

        Task<System.Collections.Generic.ICollection<TEntity>> IMongoRepository<TEntity>.GetAllAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<TEntity> IMongoRepository<TEntity>.GetByIdAsync(string id)
        {
            throw new System.NotImplementedException();
        }

        Task<string> IMongoRepository<TEntity>.InserOneAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        Task<TEntity> IMongoRepository<TEntity>.SaveAsync(TEntity entity)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IMongoRepository<TEntity>.UpdateOneAsync<TKey>(TEntity documentToModify, MongoDB.Driver.UpdateDefinition<TEntity> update)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IMongoRepository<TEntity>.UpdateOneAsync<TKey>(TEntity modifiedDocument)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IMongoRepository<TEntity>.UpdateOneAsync(TEntity documentToModify, MongoDB.Driver.UpdateDefinition<TEntity> update)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IMongoRepository<TEntity>.UpdateOneAsync(TEntity modifiedDocument)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IMongoRepository<TEntity>.UpdateOneAsync<TField>(TEntity documentToModify, System.Linq.Expressions.Expression<System.Func<TEntity, TField>> field, TField value)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IMongoRepository<TEntity>.UpdateOneAsync<TField>(MongoDB.Driver.FilterDefinition<TEntity> filter, System.Linq.Expressions.Expression<System.Func<TEntity, TField>> field, TField value, string partitionKey)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IMongoRepository<TEntity>.UpdateOneAsync<TKey, TField>(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> filter, System.Linq.Expressions.Expression<System.Func<TEntity, TField>> field, TField value, string partitionKey)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IMongoRepository<TEntity>.UpdateOneAsync<TField>(System.Linq.Expressions.Expression<System.Func<TEntity, bool>> filter, System.Linq.Expressions.Expression<System.Func<TEntity, TField>> field, TField value, string partitionKey)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IMongoRepository<TEntity>.UpdateOneAsync<TKey, TField>(TEntity documentToModify, System.Linq.Expressions.Expression<System.Func<TEntity, TField>> field, TField value)
        {
            throw new System.NotImplementedException();
        }
    }
}
