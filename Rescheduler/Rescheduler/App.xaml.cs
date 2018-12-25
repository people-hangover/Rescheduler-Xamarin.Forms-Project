using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Rescheduler.Views;
using Microsoft.AppCenter;
using Microsoft.AppCenter.Analytics;
using Microsoft.AppCenter.Crashes;
using Microsoft.Identity.Client;
using ResSched;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace Rescheduler
{
    public partial class App : Application
    {
        //PCA is a pointer. this is a pointer that youre going to call and its going to direct to microsoft page
        public static PublicClientApplication PCA = null;
        public static string AuthClientID = Config.MSALClientId; //your azure id 
                                                                 // public static string[] AuthScopes = { "User.Read" };
        public static string[] AuthScopes = Config.MSALAuthScopes;
        public static string AuthUserName = string.Empty;
        public static string AuthUserEmail = string.Empty;
        public static UIParent UiParent { get; set; }
        public App()
        {
            InitializeComponent();

            PCA = new PublicClientApplication(AuthClientID)
            {
                RedirectUri = Config.MSALRedirectUri,
            };

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
            //instead of doing "shristi" +"Rajbhandari(concatenating two strings like this), you can add a '$' in front of the variable and then type the string in curly bracket
           //eg var myString1="a" + COnfig.AppCenterUWP;
           //var myString1 = $a{ Config.AppCenterUWP};
            
            // Handle when your app starts

            AppCenter.Start("android=8fb719da-2e9c-44b8-983b-a4fcc5390442;" +
                "uwp=e8445189-20cf-4d36-985a-7ce10e865b8e;" +
                "ios=54cad270-ec60-4579-be15-9fbe815efd6c;",
                typeof(Analytics), 
                typeof(Crashes));
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }

}
