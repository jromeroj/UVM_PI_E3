using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PI_E3_CURP.MVVM.ViewModel
{
    public class VMBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand BtnfBackCommand => new Command(async () =>
        {
            await Shell.Current.GoToAsync(state: "//Inicio");
        });
    }
}
