using Microsoft.Extensions.Options;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB_CRUD.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;
using SharpCompress.Common;

namespace MongoDB_CRUD.Repository
{
    public class Abc
    {
        public int Id { get; set; }
        public string Email { get; set; }
    }
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly DbConfiguration _settings;
        private readonly IMongoDatabase _database;
        private readonly MongoClient _mongoClient;
        public Repository(IOptions<DbConfiguration> settings)
        {
            _settings = settings.Value;
            _mongoClient = new MongoClient(_settings.ConnectionString);
            _database = _mongoClient.GetDatabase(_settings.DatabaseName);
        }

        public async Task AddAsync(T entity)
        {
            var _collection = _database.GetCollection<T>(entity.GetType().Name);
            await _collection.InsertOneAsync(entity).ConfigureAwait(false);
        }

        public void AddRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(int id)
        {
            //var _collection = _database.GetCollection<T>("User");
            //return _collection.DeleteOneAsync(c => c.Id == id);
        }

        public IEnumerable<T> Find(Expression<Func<T, bool>> expression)
        {
            throw new NotImplementedException();
        }

        public async Task<List<T>> GetAll(string table)
        {
            var _collection = _database.GetCollection<T>(table);
            return await _collection.Find(c => true).ToListAsync();
        }

        public T GetById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<T> GetByIdAsync(int id)
        {
            throw new NotImplementedException();
        }

        public void Remove(T entity)
        {
            throw new NotImplementedException();
        }

        public void RemoveRange(IEnumerable<T> entities)
        {
            throw new NotImplementedException();
        }

        public void Update(T entity)
        {
            throw new NotImplementedException();
        }
    }
}
