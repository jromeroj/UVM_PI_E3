using PI_E3_CURP.MVVM.ViewModel;

namespace PI_E3_CURP.MVVM.View;

public partial class SearchPage : ContentPage
{
	SearchViewMOdel _viewmodel;
	public SearchPage()
	{
		InitializeComponent();
		_viewmodel = new SearchViewMOdel();
		BindingContext = _viewmodel;
	}
}