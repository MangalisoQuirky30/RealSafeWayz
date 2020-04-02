using realSafewayz.ViewModels;
using Xamarin.Forms;

namespace realSafewayz.Views
{
    public partial class IncidentReportPage : ContentPage
    {
        public IncidentReportPage()
        {
            InitializeComponent();
            BindingContext = new IncidentReportPageViewModel();
        }
    }
}
