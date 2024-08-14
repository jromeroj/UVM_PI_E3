using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using PI_E3_CURP.Utilidades;
using PI_E3_CURP.MVVM.Model;

namespace PI_E3_CURP.MVVM.ViewModel
{
    public class CURPLoB
    {
        public async Task<List<CURPModel>> getAll()
        {
            RestServices<CURPModel> crud = new RestServices<CURPModel>();
            var response = await crud.Get("CURP/Get");
            return response.ToList();
        }
        public async Task<CURPModel> getById(CURPModel Entity)
        {
            RestServices<CURPModel> crud = new RestServices<CURPModel>();
            var response = await crud.Post(Entity,"CURP/Get/ById");
            return response;
        }

        public async Task<CURPModel> Delete(CURPModel Entity)
        {
            RestServices<CURPModel> crud = new RestServices<CURPModel>();
            var response = await crud.Post(Entity, "CURP/Delete");
            return response;
        }
        public async Task updateORinsert(CURPModel Entity,bool isNew)
        {
            string route = "";
            if (isNew)
            {
                route = "CURP/Post";
            }
            else
            {
                route = "CURP/Update";
            }
            RestServices<CURPModel> crud = new RestServices<CURPModel>();
            await crud.PutOrPost(Entity, route,isNew);            
        }
    }
}
