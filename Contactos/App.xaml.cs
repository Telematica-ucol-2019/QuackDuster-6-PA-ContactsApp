using Contactos.View;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contactos
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();
            MainPage = new NavigationPage( new Contacto() );  
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
