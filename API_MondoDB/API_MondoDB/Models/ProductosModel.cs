using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace API_MondoDB.Models
{
    public class ProductosModel
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string Id { get; set; }
        [BsonElement("cveProd")]
        public string cveProd { get; set; }
        [BsonElement("descProd")]
        public string descProd { get; set; }
        [BsonElement("cveProveedor")]
        public string cveProveedor { get; set; }
        [BsonElement("descProveedor")]
        public string descProveedor { get; set; }
        [BsonElement("costo")]
        public decimal costo { get; set; }
        [BsonElement("unidades")]
        public int unidades { get; set; }
    }
}
