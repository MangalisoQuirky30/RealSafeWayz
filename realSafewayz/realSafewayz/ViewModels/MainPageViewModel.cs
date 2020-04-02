using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace realSafewayz.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        //PRIVATE PROPERTIES COME HERE
        ///////////////////////////////////////////////////////////////////////////////
        private DelegateCommand _navigateToMapPage;
        private DelegateCommand _navigateToSettingsPage;
        private DelegateCommand _navigateToLoginFormPage;
        private DelegateCommand _navigateToViewProfilePage;
        private DelegateCommand _navigateToEditProfilePage;
        private DelegateCommand _navigateToOnboarding1Page;
        private DelegateCommand _navigateToOnboarding2Page;
        private DelegateCommand _navigateToOnboarding3Page;
        private DelegateCommand _navigateToRegistrationPage;
        private DelegateCommand _navigateToCommunityFeedPage;
        private DelegateCommand _navigateToIncidentDetailPage;
        private DelegateCommand _navigateToIncidentReportPage;




        //PUBLIC PROPERTIES COME HERE
        ///////////////////////////////////////////////////////////////////////////////
        public DelegateCommand NavigateToMapPage =>
            _navigateToMapPage ?? (_navigateToMapPage = new DelegateCommand(ExecuteNavigateToMapPage));

        public DelegateCommand NavigateToSettingsPage =>
            _navigateToSettingsPage ?? (_navigateToSettingsPage = new DelegateCommand(ExecuteNavigateToSettingsPage));

        public DelegateCommand NavigateToLoginFormPage =>
            _navigateToLoginFormPage ?? (_navigateToLoginFormPage = new DelegateCommand(ExecuteNavigateToLoginFormPage));

        public DelegateCommand NavigateToEditProfilePage =>
            _navigateToEditProfilePage ?? (_navigateToEditProfilePage = new DelegateCommand(ExecuteNavigateToEditProfilePage));

        public DelegateCommand NavigateToOnboarding1Page =>
            _navigateToOnboarding1Page ?? (_navigateToOnboarding1Page = new DelegateCommand(ExecuteNavigateToOnboarding1Page));

        public DelegateCommand NavigateToOnboarding2Page =>
            _navigateToOnboarding2Page ?? (_navigateToOnboarding2Page = new DelegateCommand(ExecuteNavigateToOnboarding2Page));

        public DelegateCommand NavigateToOnboarding3Page =>
            _navigateToOnboarding3Page ?? (_navigateToOnboarding3Page = new DelegateCommand(ExecuteNavigateToOnboarding3Page));

        public DelegateCommand NavigateToViewProfilePage =>
            _navigateToViewProfilePage ?? (_navigateToViewProfilePage = new DelegateCommand(ExecuteNavigateToViewProfilePageCommand));

        public DelegateCommand NavigateToRegistrationPage =>
            _navigateToRegistrationPage ?? (_navigateToRegistrationPage = new DelegateCommand(ExecuteNavigateToRegistrationPage));

        public DelegateCommand NavigateToCommunityFeedPage =>
            _navigateToCommunityFeedPage ?? (_navigateToCommunityFeedPage = new DelegateCommand(ExecuteNavigateToCommunityFeedPage));

        public DelegateCommand NavigateToIncidentDetailPage =>
            _navigateToIncidentDetailPage ?? (_navigateToIncidentDetailPage = new DelegateCommand(ExecuteNavigateToIncidentDetailPage));

        public DelegateCommand NavigateToIncidentReportPage =>
            _navigateToIncidentReportPage ?? (_navigateToIncidentReportPage = new DelegateCommand(ExecuteNavigateToIncidentReportPage));




        //METHODS COME HERE
        ///////////////////////////////////////////////////////////////////////////////
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";
        }

        private async void ExecuteNavigateToMapPage()
        {
            await NavigationService.NavigateAsync("NavigationPage/MapPage");
        }

        private async void ExecuteNavigateToOnboarding2Page()
        {
            await NavigationService.NavigateAsync("NavigationPage/OnboardingPage2");
        }

        private async void ExecuteNavigateToOnboarding3Page()
        {
            await NavigationService.NavigateAsync("NavigationPage/OnboardingPage3");
        }

        private async void ExecuteNavigateToSettingsPage()
        {
            await NavigationService.NavigateAsync("NavigationPage/SettingPage");
        }

        private async void ExecuteNavigateToLoginFormPage()
        {
            await NavigationService.NavigateAsync("NavigationPage/LoginForm");
        }

        private async void ExecuteNavigateToEditProfilePage()
        {
            await NavigationService.NavigateAsync("NavigationPage/EditProfilePage");
        }

        private async void ExecuteNavigateToIncidentDetailPage()
        {
            await NavigationService.NavigateAsync("NavigationPage/IncidentDetailPage");
        }

        private async void ExecuteNavigateToCommunityFeedPage()
        {
            await NavigationService.NavigateAsync("NavigationPage/CommunityFeedPage");
        }

        private async void ExecuteNavigateToRegistrationPage()
        {
            await NavigationService.NavigateAsync("NavigationPage/RegistrationForm");
        }

        private async void ExecuteNavigateToOnboarding1Page()
        {
            await NavigationService.NavigateAsync("NavigationPage/OnboardingPage1");
        }

        private async void ExecuteNavigateToViewProfilePageCommand()
        {
            await NavigationService.NavigateAsync("NavigationPage/ViewProfilePage");
        }

        private async void ExecuteNavigateToIncidentReportPage()
        {
            await NavigationService.NavigateAsync("NavigationPage/IncidentReportPage");
        }
    }
}
