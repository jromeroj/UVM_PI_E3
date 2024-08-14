using API_MondoDB.Models;

using Microsoft.Extensions.Hosting;

using MongoDB.Bson;
using MongoDB.Driver;
using MongoDB.Driver.Core.Configuration;

using SharpCompress.Common;

using System.Linq.Expressions;
using System.Reflection;

using static MongoDB.Driver.WriteConcern;

namespace API_MondoDB.CNNMongo
{
    public class MongoConeccion<T> where T : class, new()
    {
        enum typeOperation { Create, Retrive, Update, Delete }
        private IMongoDatabase GetDatabase()
        {
            //MongoClient client = new MongoClient("mongodb+srv://jonathanromerojimene:NOgZZ6fnYZ2aeMFx@demouvmcluster.cqes6dk.mongodb.net/");
            //MongoClient client = new MongoClient("mongodb+srv://jonathanromerojimene:R0m3r0Lun4@uvmcluster.xudjq6i.mongodb.net");
            MongoClient client = new MongoClient("mongodb+srv://jonathanromerojimene:R0m3r0Lun4@uvmcluster.xudjq6i.mongodb.net/?retryWrites=true&w=majority");
            
            //var database = client.GetDatabase("UVMDemoDB");
            var database = client.GetDatabase("UVMCluster");
            
            return database;
        }

        private IMongoCollection<T> CollectionsOfMongo(string CollectionMongo)
        {
            IMongoCollection<T> collectionMongo = GetDatabase().GetCollection<T>(CollectionMongo);
            return collectionMongo;
        }



        public async Task<bool> InsertOne(T Entity)
        {
            bool exito = false;
            try
            {
                //getFilters(Entity);
                await CollectionsOfMongo(Entity.GetType().Name).InsertOneAsync(Entity);
                exito = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public async Task<bool> DeleteOne(T Entity)
        {
            bool exito = false;
            try
            {
                var parameterExpression = Expression.Parameter(typeof(T), "x");
                var memberAccessExpression = Expression.MakeMemberAccess(parameterExpression, typeof(T).GetProperty("Id"));
                
                var valueData = typeof(T).GetProperty("Id").GetValue(Entity,null).ToString();


                var builder = Builders<T>.Filter;
                var filter = builder.Eq(memberAccessExpression.Member.Name, valueData);
                
                
                await CollectionsOfMongo(Entity.GetType().Name).DeleteOneAsync(filter);
                exito = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            return exito;
        }

        public async Task<bool> UpdateOne(T Entity)
        {
            bool exito = false;
            try
            {
                var parameterExpression = Expression.Parameter(typeof(T), "x");
                var memberAccessExpression = Expression.MakeMemberAccess(parameterExpression, typeof(T).GetProperty("Id"));

                var valueData = typeof(T).GetProperty("Id").GetValue(Entity, null).ToString();


                var builder = Builders<T>.Filter;
                var filter = builder.Eq(memberAccessExpression.Member.Name, valueData);
                var update = updateDef(Entity);

                await CollectionsOfMongo(Entity.GetType().Name).UpdateOneAsync(filter, update ); 
                exito = true;
            }
            catch (Exception ex)
            {
                throw ex;
            }

            

            return exito;
        }


        public async Task<List<T>> GetAll()
        {

            T Entity = new T();
            var response = await CollectionsOfMongo(Entity.GetType().Name).FindAsync(x => true);
            return response.ToList();
        }



        private UpdateDefinition<T> updateDef(T Entity) {


            UpdateDefinition<T> update = null;

            foreach (var item in Entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic))
            {
                var valueObject = item.GetValue(Entity, null);
                var typeObject = item.Name;
                if (valueObject != null && typeObject != "Id")
                {
                    //update.AddToSet(typeObject.ToString(), valueObject.ToString());
                    update = Builders<T>.Update.Set(typeObject.ToString(), valueObject.ToString());
                }
            }

            return update;
            
        
        }



            //private Builders<T> getFilters(T Entity)
            private FilterDefinition<T> getFilters(T Entity, typeOperation operation)
        {
            FilterDefinition<T>? Filters = null;
            foreach (var item in Entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic))
            {
                var valueObject = item.GetValue(Entity, null);
                var typeObject = item.Name;
                var parameterExpression = Expression.Parameter(typeof(T), "x");
                //var memberAccessExpression = Expression.MakeMemberAccess(parameterExpression, typeof(T).GetProperty("Id"));
                var memberAccessExpression = Expression.MakeMemberAccess(parameterExpression, typeof(T).GetProperty(typeObject));






                //var parameter = Expression.Parameter(typeof(T));
                //var left = Expression.Property(memberAccessExpression, typeof(T).GetProperty(typeObject).Name);

                //if (left.Type == typeof(string))
                //{
                //    var right = (Expression<Func<string>>)(() => (string)valueObject);
                //    var body = Expression.Equal(left, right.Body);
                //    var predicate = Expression.Lambda<Func<T, bool>>(body, new ParameterExpression[] { parameter });

                //    Filters = Builders<T>.Filter.Eq(right,)
                //}
                //else
                //{
                //    var right = Expression.Constant(valueObject);
                //    var body = Expression.Equal(left, right);
                //    var predicate = Expression.Lambda<Func<T, bool>>(body, new ParameterExpression[] { parameter });

                //    return query.Where(predicate); // propertyValue not  parametrized!
                //}







                if (typeObject == "Id" && operation == typeOperation.Delete)
                {
                    ObjectId id = (ObjectId)valueObject;
                    Filters = Builders<T>.Filter.Eq(x => memberAccessExpression, valueObject);                    
                }               
            }
            return Filters;
        }




    }
}
