using Desafio2.Data;
using Xamarin.Forms;

namespace Desafio2
{
    public partial class App : Application
    {
        static DBConnection database;

        public App()
        {
            InitializeComponent();

            MainPage = new NavigationPage(new Desafio2Page());
        }

        public static DBConnection Database
        {
            get
            {
                if(database == null)
                {
                    database = new DBConnection(DependencyService.Get<IFileHelper>().GetLocalFilePath("database.db3"));
                }

                return database;
            }
        }

        protected override void OnStart()
        {
            // Handle when your app starts
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
