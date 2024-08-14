using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Bson;
using Google.Cloud.Firestore;

namespace API_MondoDB.Models
{
    [FirestoreData]
    public class CURPModel
    {
        //[BsonId]
        //[BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        //[BsonElement("nombres")]
        [FirestoreProperty]
        public string nombres { get; set; }
        //[BsonElement("app")]
        [FirestoreProperty]
        public string app { get; set; }
        //[BsonElement("apm")]
        [FirestoreProperty]
        public string apm { get; set; }
        //[BsonElement("curp")]
        [FirestoreProperty]
        public string curp { get; set; }
        //[BsonElement("isValid")]
        [FirestoreProperty]
        public string isvalid { get; set; }
    }
}
