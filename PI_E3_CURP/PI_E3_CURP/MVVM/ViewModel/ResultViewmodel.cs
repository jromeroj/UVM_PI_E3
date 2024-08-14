using PI_E3_CURP.MVVM.Model;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PI_E3_CURP.MVVM.ViewModel
{
    [QueryProperty(nameof(Accion), "Accion")]
    internal class ResultViewmodel : VMBase
    { 
        
        
        public ResultViewmodel() {
            getLista();
        
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
            }
        }
        CURPModel curp = new CURPModel();
        public CURPModel CURP
        {
            get => curp;
            set
            {
                curp = value;
                OnPropertyChanged(nameof(CURP));
            }
        }

        string accion = "";
        public string Accion
        {
            get => accion;
            set
            {
                accion = value;
                OnPropertyChanged(nameof(Accion));
                cambiarImagen(accion);
            }
        }


        ConfigResonseModel cResponse = new ConfigResonseModel();
        public ConfigResonseModel CResponse
        {
            get => cResponse;
            set
            {
                cResponse = value;
                OnPropertyChanged(nameof(CResponse));
            }
        }

        void cambiarImagen(string action)
        {
            ConfigResonseModel res = new ConfigResonseModel();
            switch (action)
            {
                case "par":
                    res.sourceImage = "aprobar.png";
                    res.testDescrip = "En hora buena la identidad es CORRECTA puedes continuar";
                    res.btnColor = "#28cd0e";
                    res.txtButon = "Continuar";
                    break;
                case "inpar":
                    res.sourceImage = "usuario.png";
                    res.testDescrip = "Lo sentimos el CURP NO es invalido y no corresponde al nombre de  la persona que proporcionaste";
                    res.btnColor = "#737a82";
                    res.txtButon = "Regresar";
                    break;
            }

            CResponse = res;
        }

        public ICommand BtnNextCommand => new Command(async () =>
        {
            switch (Accion)
            {
                case "par":
                    await Shell.Current.GoToAsync(state: "//FCurpPage");
                    break;
                case "inpar":
                    await Shell.Current.GoToAsync(state: "//Inicio");
                    break;
            }

        });

    }




}