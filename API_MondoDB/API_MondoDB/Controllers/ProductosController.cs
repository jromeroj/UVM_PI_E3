using API_MondoDB.CNNMongo;
using API_MondoDB.Models;

using Microsoft.AspNetCore.Mvc;

using SharpCompress.Common;

namespace API_MondoDB.Controllers
{
    [Route("api/[controller]")]
    public class ProductosController : ControllerBase
    {
        [HttpGet]
        public Task<List<ProductosModel>> GetAllProducts()
        {
            var mongoCnn = new MongoConeccion<ProductosModel>();
            return mongoCnn.GetAll();
        }
        [HttpPost]
        public void InsertProdduct([FromBody] ProductosModel Entity)
        {
           var mongoCnn = new MongoConeccion<ProductosModel>();
           mongoCnn.InsertOne(Entity);
        }

        [HttpDelete]
        public ActionResult DeleteProdduct([FromBody] ProductosModel Entity)
        {
            var mongoCnn = new MongoConeccion<ProductosModel>();
            return Ok(mongoCnn.DeleteOne(Entity));
        }
        [HttpPut]
        public ActionResult UpdateProdduct([FromBody] ProductosModel Entity)
        {
            var mongoCnn = new MongoConeccion<ProductosModel>();
            return Ok(mongoCnn.UpdateOne(Entity));
        }
    }
}
