using Microsoft.Extensions.Configuration;
using MongoDb.Events;
using MongoDb.Interfaces;
using MongoDb.Setting;
using MongoDB.Driver;
using System.Collections.Generic;

namespace MongoDb.Services
{
    public class BaseService<T> : IBaseService<T> where T : TEntity
    {
        public readonly IMongoCollection<T> _mongoCollection;

        public BaseService(IConfiguration configuration)
        {
            var getSection = configuration.GetSection("MongoDb").Get<DatabaseSetting>();

            var client = new MongoClient(getSection.ConnectionString);
            var database = client.GetDatabase(getSection.DatabaseName);

            _mongoCollection = database.GetCollection<T>(getSection.CollectionName);
        }

        public List<T> Get() =>
            _mongoCollection.Find(entity => true).ToList();

        public T Get(string id) =>
            _mongoCollection.Find<T>(entity => entity.Id == id).FirstOrDefault();

        public T Create(T entity)
        {
            _mongoCollection.InsertOne(entity);
            return entity;
        }

        public void Update(string id, T entityIn) =>
            _mongoCollection.ReplaceOne(entity => entity.Id == id, entityIn);

        public void Remove(T entityIn) =>
            _mongoCollection.DeleteOne(entity => entity.Id == entityIn.Id);

        public void Remove(string id) =>
            _mongoCollection.DeleteOne(entity => entity.Id == id);
    }
}
