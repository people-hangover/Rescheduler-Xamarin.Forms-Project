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

            AppCenter.Start("android=53d19803-461e-44b4-b198-fae98da11a00;" + 
                "uwp=21f810e3-9927-42a0-b83a-25bb4a6c81cd;" + 
                "ios=36fdb15b-db67-461b-af11-661d43da68bc;",
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
