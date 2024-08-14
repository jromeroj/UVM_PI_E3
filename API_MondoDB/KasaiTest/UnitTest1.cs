using API_MondoDB.Models;

namespace KasaiTest
{
    public class Tests
    {
        Kasai.Firestore.ManageFirestore<API_MondoDB.Models.CURPModel> firestore;
        [SetUp]
        public void Setup()
        {
            firestore = new Kasai.Firestore.ManageFirestore<API_MondoDB.Models.CURPModel> ();
        }
        
        [Test]
        public async Task ConultaCompleta()
        {
            var lst = await firestore.getAll();
            Assert.IsTrue(lst.Count >= 1);            
        }

        [Test]
        public async Task Insert()
        {
            CURPModel cURPModel = new CURPModel ();
            cURPModel.nombres = "Manolo Omar";
            cURPModel.app = "Cruz";
            cURPModel.apm = "Guzman";
            cURPModel.curp = "CRGM000000HDFMNN05";

            var response = await firestore.setEntity(cURPModel);
            Assert.IsTrue(response);
        
        }

        [Test]
        public async Task Update()
        {
           
            var lst = await firestore.getAll();
            CURPModel item=  lst.SingleOrDefault(x => x.curp == "CRGM000000HDFMNN05");
            CURPModel cURPModel = new CURPModel();
            cURPModel = item;
            cURPModel.nombres = "Manolo";
            var response = await firestore.updateEntity(cURPModel);
            Assert.IsTrue(response);
        }
        [Test]
        public async Task Delete()
        {
            var lst = await firestore.getAll();
            CURPModel item = lst.SingleOrDefault(x => x.curp == "CRGM000000HDFMNN05");
            CURPModel cURPModel = new CURPModel();
            cURPModel.Id = item.Id;
            var response = await firestore.deleteEntity(cURPModel);
            Assert.IsTrue(response);
        }

    }
}