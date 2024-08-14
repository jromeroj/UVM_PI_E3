using Google.Apis.Auth.OAuth2;
using Google.Cloud.Firestore;
using Google.Cloud.Storage.V1;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using static Google.Cloud.Firestore.V1.StructuredQuery.Types;

namespace Kasai
{
    public class FirebaseConnection
    {
        string filepath = "D:\\UVM\\Cuatrimestres\\09\\Solución de programación móvil\\Actividades\\API_MondoDB\\API_MondoDB\\uvmdemo-34db5-firebase-adminsdk-dqm07-a42f20174b.json";
        public FirestoreDb FirestoreCnn()
        {            
            Environment.SetEnvironmentVariable("GOOGLE_APPLICATION_CREDENTIALS", filepath);
            string projectId = "uvmdemo-34db5";
            FirestoreDb db = FirestoreDb.Create(projectId);
            return db;
        }


        public StorageClient FireStorageClte()
        {
            GoogleCredential credential = null;
            using (var jsonStream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                credential = GoogleCredential.FromStream(jsonStream);
            }
            var storageClient = StorageClient.Create(credential);
            return storageClient;
        }
    }
}
