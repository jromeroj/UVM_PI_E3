using PI_E3_CURP.MVVM.ViewModel;

namespace PI_E3_CURP.MVVM.View;

public partial class FilePage : ContentPage
{
    FileViewModel _viewModel;
    public FilePage()
    {
        InitializeComponent();
        _viewModel = new FileViewModel();
        BindingContext = _viewModel;
    }
}