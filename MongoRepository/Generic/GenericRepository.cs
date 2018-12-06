using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoRepository.Interface;
namespace MongoRepository.Generic
{
    public class GenericRepository<TEntity> : IMongoRepository<TEntity> where TEntity:class, IMongoEntity
    {
       protected IMongoCollection<TEntity> _db;

        public GenericRepository(IMongoDatabase db)
        {
            _db = db.GetCollection<TEntity>(typeof(TEntity).Name);
        }
        public string InserOne(TEntity entity)
        {
            if (entity.Id is string)
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
                var id = entity.Id as string;
                if (string.IsNullOrEmpty(id))
                {
                    id = ObjectId.GenerateNewId().ToString();
                    entity.Id = id;
                }
            }
            _db.InsertOne(entity);
            return entity.Id;


        }
        public async Task<TEntity> DeleteAsync(string id)
        {
            return await _db.FindOneAndDeleteAsync(mbox => mbox.Id.Equals(id));

        }
        public TEntity FindFirst(Expression<Func<TEntity, bool>> predicat)
        {
            return _db.Find(predicat).FirstOrDefault();
        }
        public async Task<ICollection<TEntity>> FindAllAsync(Expression<Func<TEntity, bool>> predicat)
        {
            return await _db.Find(predicat).ToListAsync();
        }
        public async Task<ICollection<TEntity>> GetAll()
        {
            return await _db.Find(m => true).ToListAsync();
        }
        public async Task<TEntity> GetByIdAsync(string id)
        {
            return await _db.Find(mbox => mbox.Id.Equals(id)).FirstOrDefaultAsync();

        }
        public async Task<TEntity> SaveAsync(TEntity entity)
        {
            try
            {
                await _db.ReplaceOneAsync(mbox => mbox.Id.Equals(entity.Id), entity, new UpdateOptions { IsUpsert = true });
            }
            catch (Exception ex)
            {

            }

            return entity;
        }
        public TEntity FindFirst(string id)
        {
            return _db.Find(m => m.Id == id).FirstOrDefault();
        }
        public virtual async Task<bool> UpdateOneAsync(TEntity documentToModify, UpdateDefinition<TEntity> update)
        {

            var filter = Builders<TEntity>.Filter.Eq("Id", documentToModify.Id);
            var updateRes = await _db.UpdateOneAsync(filter, update);
            return updateRes.ModifiedCount == 1;
        }
        public bool UpdateOne(TEntity modifiedDocument)
        {
            var updateRes = _db.ReplaceOne(mbox => mbox.Id == modifiedDocument.Id, modifiedDocument);
            return updateRes.ModifiedCount == 1;
        }
        public bool UpdateOne<TField>(FilterDefinition<TEntity> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null)
        {
            var updateRes = _db.UpdateOne(filter, Builders<TEntity>.Update.Set(field, value));
            return updateRes.ModifiedCount == 1;
        }
        public bool UpdateOne<TField>(TEntity documentToModify, Expression<Func<TEntity, TField>> field, TField value)
        {
            var filter = Builders<TEntity>.Filter.Eq("Id", documentToModify.Id);
            var updateRes = _db.UpdateOne(filter, Builders<TEntity>.Update.Set(field, value));
            return updateRes.ModifiedCount == 1;
        }
        public bool UpdateOne<TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null)
        {
            var updateRes = _db.UpdateOne(Builders<TEntity>.Filter.Where(filter), Builders<TEntity>.Update.Set(field, value));
            return updateRes.ModifiedCount == 1;
        }
        public bool UpdateOne(TEntity documentToModify, UpdateDefinition<TEntity> update)
        {
            var filter = Builders<TEntity>.Filter.Eq(m => m.Id, documentToModify.Id);
            var updateRes = _db.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
            return updateRes.ModifiedCount == 1;
        }
        public bool UpdateOne<TKey>(TEntity modifiedDocument)
        {
            var filter = Builders<TEntity>.Filter.Eq(m => m.Id, modifiedDocument.Id);
            var updateRes = _db.ReplaceOne(filter, modifiedDocument);
            return updateRes.ModifiedCount == 1;
        }
        public bool UpdateOne<TKey>(TEntity documentToModify, UpdateDefinition<TEntity> update)
        {
            var filter = Builders<TEntity>.Filter.Eq(m => m.Id, documentToModify.Id);
            var updateRes = _db.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
            return updateRes.ModifiedCount == 1;
        }
        public bool UpdateOne<TKey, TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null)
        {

            var updateRes = _db.UpdateOne(filter, Builders<TEntity>.Update.Set(field, value));
            return updateRes.ModifiedCount == 1;
        }
        public bool UpdateOne<TKey, TField>(TEntity documentToModify, Expression<Func<TEntity, TField>> field, TField value)
        {
            var filter = Builders<TEntity>.Filter.Eq(m => m.Id, documentToModify.Id);
            var updateRes = _db.UpdateOne(filter, Builders<TEntity>.Update.Set(field, value));
            return updateRes.ModifiedCount == 1;
        }
        public  Task<TEntity> FindFirstAsync(string id)
        {
            return _db.Find(m => m.Id == id).FirstOrDefaultAsync();
        }
        public Task<TEntity> FindFirstAsync(Expression<Func<TEntity, bool>> predicat)
        {
            return _db.Find(predicat).FirstOrDefaultAsync();
        }
        public async Task<ICollection<TEntity>> GetAllAsync()
        {
            return await _db.Find(m => true).ToListAsync();
        }
        public async Task<string> InserOneAsync(TEntity entity)
        {
            if (entity.Id is string)
            {
                entity.Id = ObjectId.GenerateNewId().ToString();
                var id = entity.Id as string;
                if (string.IsNullOrEmpty(id))
                {
                    id = ObjectId.GenerateNewId().ToString();
                    entity.Id = id;
                }
            }
            _db.InsertOne(entity);
            return  entity.Id;
        }
        public async Task<bool> UpdateOneAsync<TKey>(TEntity documentToModify, UpdateDefinition<TEntity> update)
        {
            var filter = Builders<TEntity>.Filter.Eq(m => m.Id, documentToModify.Id);
            var updateRes = _db.UpdateOne(filter, update, new UpdateOptions { IsUpsert = true });
            return updateRes.ModifiedCount == 1;
        }
        public async Task<bool> UpdateOneAsync<TKey>(TEntity modifiedDocument)
        {
            var filter = Builders<TEntity>.Filter.Eq(m => m.Id, modifiedDocument.Id);
            var updateRes = _db.ReplaceOne(filter, modifiedDocument);
            return updateRes.ModifiedCount == 1;
        }
        public async Task<bool> UpdateOneAsync<TField>(TEntity documentToModify, Expression<Func<TEntity, TField>> field, TField value)
        {
            var filter = Builders<TEntity>.Filter.Eq(m => m.Id, documentToModify.Id);
            var updateRes = _db.UpdateOne(filter, Builders<TEntity>.Update.Set(field, value));
            return updateRes.ModifiedCount == 1;
        }
        public async Task<bool> UpdateOneAsync<TField>(FilterDefinition<TEntity> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null)
        {
            var updateRes = _db.UpdateOne(filter, Builders<TEntity>.Update.Set(field, value));
            return updateRes.ModifiedCount == 1;
        }
        public async Task<bool> UpdateOneAsync<TKey, TField>(Expression<Func<TEntity, bool>> filter, Expression<Func<TEntity, TField>> field, TField value, string partitionKey = null)
        {
            var updateRes = _db.UpdateOne(filter, Builders<TEntity>.Update.Set(field, value));
            return updateRes.ModifiedCount == 1;
        }
      
    }
}
