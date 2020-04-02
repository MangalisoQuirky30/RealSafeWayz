using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace realSafewayz.ViewModels
{
    public class IncidentReportPageViewModel : BindableBase, INavigationAware
    {

        private string _address;
        public string Address 
        {
            get { return _address; }
            set { SetProperty(ref _address, value); }
        }
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }
        public IncidentReportPageViewModel()
        {
        }

        public void OnNavigatedFrom(INavigationParameters parameters)
        {
            throw new NotImplementedException();
        }

        public void OnNavigatedTo(INavigationParameters parameters)
        {
            Address = parameters.GetValue<string>("Address");
            Title = parameters.GetValue<string>("Address");
        }
    }
}
