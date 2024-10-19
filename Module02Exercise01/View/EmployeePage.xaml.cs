using Module02Exercise01.ViewModel;
using Microsoft.Maui.Controls;

namespace Module02Exercise01.View
{
    public partial class EmployeePage : ContentPage
    {
        public EmployeePage()
        {
            InitializeComponent();


            BindingContext = new EmployeeViewModel();
        }
    }
}
