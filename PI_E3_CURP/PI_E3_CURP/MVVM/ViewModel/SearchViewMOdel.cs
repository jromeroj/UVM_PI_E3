using PI_E3_CURP.MVVM.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PI_E3_CURP.MVVM.ViewModel
{
    public class SearchViewMOdel:VMBase
    {
        public SearchViewMOdel() {

            getLista();
        }

        CURPModel curp = new CURPModel();
        public CURPModel CURP { 
        get => curp;
            set { curp = value;
                OnPropertyChanged(nameof(CURP));
            }
        }


        async Task getLista()
        {
            CURPLoB cURPLoB = new CURPLoB();
            LstCURP = await cURPLoB.getAll();
        }

        List<CURPModel> lstCURP = new List<CURPModel>();
        public List<CURPModel> LstCURP
        {
            get => lstCURP;
            set
            {
                lstCURP = value;
                OnPropertyChanged(nameof(LstCURP));
                ItemCURP = (LstCURP.Count >= 1? LstCURP.FirstOrDefault(): new CURPModel());

            }
        }
        CURPModel itemcurp = new CURPModel();
        public CURPModel ItemCURP
        {
            get => itemcurp;
            set
            {
                itemcurp = value;
                OnPropertyChanged(nameof(ItemCURP));
            }
        }
        CURPModel updcurp = new CURPModel();
        public CURPModel UpdCURP
        {
            get => updcurp;
            set
            {
                updcurp = value;
                OnPropertyChanged(nameof(UpdCURP));
            }
        }

        bool visible = false;
        public bool isVisible
        { 
        get => visible;
            set { visible = value; OnPropertyChanged(nameof(isVisible)); }
        }

        bool isNew = false;
        public bool ISNwe
        {
            get => isNew;
            set { isNew = value; OnPropertyChanged(nameof(ISNwe)); }
        }

        public ICommand closeCommand => new Command(async () =>
        {
            isVisible = false;
        });
        public ICommand addCommand => new Command(async () =>
        {
            ISNwe = true;
            isVisible = true;            
            ItemCURP = new CURPModel();
        });
        public ICommand updCommand => new Command(async () =>
        {
            ISNwe = false;            
            isVisible = true;            
        });


        public ICommand deleteCommand => new Command(async () =>
        {
            CURPModel curpmodel = new CURPModel();
            curpmodel.Id = ItemCURP.Id;
            CURPLoB crud = new CURPLoB();
            await crud.Delete(curpmodel);
        });

        public ICommand refreshCommand => new Command(async () =>
        {
            LstCURP = new List<CURPModel>();
            await getLista();
        });

        public ICommand BtnfINDCommand => new Command(async () =>
        {

            Random aleatorio = new Random();
                    int intNumero = aleatorio.Next();
            CURPModel curpmodel = new CURPModel();
            curpmodel = ItemCURP;
            string tipo = "";
            
            if ((intNumero % 2) == 0)
            {
                tipo = "par";
                curpmodel.isValid = "true";
                
            }
            else
            {
                tipo = "inpar";
                curpmodel.isValid = "false";
                
            }
            CURPLoB lob = new CURPLoB();
            await lob.updateORinsert(curpmodel, ISNwe); 
            isVisible = false;
            
            //var navigationParameter = new Dictionary<string, object> { { "Accion", tipo } };
            //await Shell.Current.GoToAsync(state: "//ResultFindPage", navigationParameter);
            //await Shell.Current.GoToAsync(state: "//ResultFindPage");
        });
    }
}
