using Google.Cloud.Firestore;

using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

using static Grpc.Core.Metadata;

namespace Kasai.Firestore
{
    public class ManageFirestore<TEntity> where TEntity : class, new()
    {
        FirebaseConnection cnnFB;
        CollectionReference collection;
        public ManageFirestore()
        {
            getCollection();
        }
        void getCollection()
        {
            cnnFB = new FirebaseConnection();
            TEntity entity = new TEntity();
            collection = cnnFB.FirestoreCnn().Collection(entity.GetType().Name);
        }    
        public async Task<TEntity> getByID(TEntity Entity)
        {
            DocumentSnapshot snapshot = await collection.Document(await getIdDocument(Entity)).GetSnapshotAsync();
            TEntity e = snapshot.ConvertTo<TEntity>();            
            return e;
        }
        public async Task<List<TEntity>> getAll() {                   
            List<TEntity> lstEntity = new List<TEntity>();
            QuerySnapshot snapshot = await collection.GetSnapshotAsync();
            foreach (DocumentSnapshot docSnap in snapshot.Documents)
            {
                
                TEntity item = docSnap.ConvertTo<TEntity>();
                item = await complmentEntity(item,docSnap.Id);
                lstEntity.Add(item);                
            }
            return lstEntity;
        }        
        async Task<Dictionary<string, object>> getParametres(TEntity Entity)
        {
            Dictionary<string, object> paramsEntity = new Dictionary<string, object>();
            foreach (var item in Entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic))
            {
                var nameObject = item.Name;
                var valueObject = item.GetValue(Entity, null);
                paramsEntity.Add(nameObject, valueObject);
            }
            return paramsEntity;
        }       
        public async Task<bool> setEntity(TEntity Entity)
        {
            bool exito = false;
            var postElements = await collection.AddAsync(Entity);

            if (string.IsNullOrEmpty(postElements.Id))
            {
                exito = true;
            }
            return exito;
        }
        public async Task<bool> updateEntity(TEntity Entity)
        {

            bool exito = false;
            try
            {
                DocumentReference docRef = collection.Document(await getIdDocument(Entity));
                docRef.SetAsync(Entity, SetOptions.Overwrite);
                exito = true; 
            }
            catch (Exception)
            {

                throw;
            }
            return exito;
        }
        public async Task<bool> deleteEntity(TEntity Entity)
        {
            bool exito = false;
            try
            {
                await collection.Document(await getIdDocument(Entity)).DeleteAsync();
                exito = true;
            }
            catch (Exception)
            {
                throw;
            }                                    
            return exito;
        }
        async Task<TEntity> complmentEntity(TEntity Entity, string Id)
        {
            TEntity e = new TEntity();
            foreach (var item in e.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Instance))
            {
                var nameObject = item.Name;
                if (nameObject == "Id")
                {
                    item.SetValue(Entity, Id);
                }
            }
            return Entity;
        }
        async Task<DocumentSnapshot> findDocument(TEntity Entity)
        {
            var docRef = collection.Document("123456789");

            foreach (var item in Entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic))
            {
                var valueObject = item.GetValue(Entity, null);
                if (item.Name == "Id")
                {
                    docRef = collection.Document(valueObject.ToString());
                }
            }
            DocumentSnapshot snap = await docRef.GetSnapshotAsync();
            return snap;
        }
        async Task<string> getIdDocument(TEntity Entity)
        {
            string idValue = string.Empty;

            foreach (var item in Entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic))
            {
               
                if (item.Name == "Id")
                {
                    idValue = item.GetValue(Entity, null).ToString(); ;
                }
            }
            return idValue;
        }
        async Task<Dictionary<string, object>> getData(TEntity Entity)
        {

            Dictionary<string, object> data = new Dictionary<string, object>();
            foreach (var item in Entity.GetType().GetProperties(System.Reflection.BindingFlags.Public | System.Reflection.BindingFlags.Instance | System.Reflection.BindingFlags.NonPublic))
            {
                var valueObject = item.GetValue(Entity, null);
                if (item.Name != "Id")
                {
                    data.Add(item.Name, valueObject.ToString());
                }
            }
            return data;
        }
    }
}
