using PI_E3_CURP.MVVM.ViewModel;

namespace PI_E3_CURP.MVVM.View;

public partial class ResultPage : ContentPage
{
	ResultViewmodel _viewmodel;
	public ResultPage()
	{
		InitializeComponent();
		_viewmodel = new ResultViewmodel();
		BindingContext = _viewmodel;
	}
}