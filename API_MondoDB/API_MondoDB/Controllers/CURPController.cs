using API_MondoDB.CNNMongo;
using API_MondoDB.Models;

using Google.Cloud.Storage.V1;

using Kasai.Storage;

using Microsoft.AspNetCore.Mvc;

using System.Threading.Tasks.Dataflow;

namespace API_MondoDB.Controllers
{
    [Route("[controller]")]
    public class CURPController : Controller
    {

        [HttpGet("Get")]
        public async Task<List<CURPModel>> GetAll()
        {
            Kasai.Firestore.ManageFirestore<CURPModel> firestore = new Kasai.Firestore.ManageFirestore<CURPModel>();
            return await firestore.getAll();
        }
        [HttpPost("Get/ById")]
        public async Task<CURPModel> GetById([FromBody] CURPModel Entity)//Task<List<CURPModel>> GetAllCURP()
        {
            Kasai.Firestore.ManageFirestore<CURPModel> firestore = new Kasai.Firestore.ManageFirestore<CURPModel>();
            return await firestore.getByID(Entity);
        }
        [HttpPost("Post")]
        public ActionResult PostCURP([FromBody] CURPModel Entity)//Task<List<CURPModel>> GetAllCURP()
        {
            Kasai.Firestore.ManageFirestore<CURPModel> firestore = new Kasai.Firestore.ManageFirestore<CURPModel>();
            return Ok(firestore.setEntity(Entity));
        }
        [HttpPost("Delete")]
        public ActionResult DeleteCURP([FromBody] CURPModel Entity)
        {
            var mongoCnn = new MongoConeccion<CURPModel>();
            return Ok(mongoCnn.DeleteOne(Entity));
        }
        [HttpPut("Update")]
        public ActionResult UpdateCURP([FromBody] CURPModel Entity)
        {
            Kasai.Firestore.ManageFirestore<CURPModel> firestore = new Kasai.Firestore.ManageFirestore<CURPModel>();
            return Ok(firestore.updateEntity(Entity));
        }


        [HttpPost("UploadFile")]
        public ActionResult UploadCURP([FromBody] string file)
        {
            Kasai.Storage.StorageManage storage = new StorageManage();
            StorageParams storageParams = new StorageParams();
            Guid isd = Guid.NewGuid();
            storageParams.bucketName = "uvmdemo-34db5.appspot.com";
            storageParams.nameFile = "contrato.txt";
            storageParams.fileType = "text/plain";
            using (var fileStream = new FileStream(file, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                storageParams.fileManage = fileStream;                
                return Ok(storage.UploadFile(storageParams));
            }
            
        }

    }
}
