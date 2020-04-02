using Prism;
using Prism.Ioc;
using realSafewayz.ViewModels;
using realSafewayz.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace realSafewayz
{
    public partial class App
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            InitializeComponent();

            await NavigationService.NavigateAsync("NavigationPage/MainPage");
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();

            containerRegistry.RegisterForNavigation<MapPage, MapPageViewModel>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<LoginForm, LoginFormViewModel>();
            containerRegistry.RegisterForNavigation<SettingPage, SettingPageViewModel>();
            containerRegistry.RegisterForNavigation<OnboardingPage1, OnboardingPage1ViewModel>();
            containerRegistry.RegisterForNavigation<OnboardingPage2, OnboardingPage2ViewModel>();
            containerRegistry.RegisterForNavigation<OnboardingPage3, OnboardingPage3ViewModel>();
            containerRegistry.RegisterForNavigation<ViewProfilePage, ViewProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<EditProfilePage, EditProfilePageViewModel>();
            containerRegistry.RegisterForNavigation<RegistrationForm, RegistrationFormViewModel>();
            containerRegistry.RegisterForNavigation<CommunityFeedPage, CommunityFeedPageViewModel>();
            containerRegistry.RegisterForNavigation<IncidentReportPage, IncidentReportPageViewModel>();
            containerRegistry.RegisterForNavigation<IncidentDetailPage, IncidentDetailPageViewModel>();
        }
    }
}
