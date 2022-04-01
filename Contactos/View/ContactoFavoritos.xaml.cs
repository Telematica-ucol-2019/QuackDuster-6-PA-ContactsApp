using Contactos.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Contactos.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ContactoFavoritos : ContentPage
    {
        public ContactoFavoritos(ContactoViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            Title = "Contactos Favoritos";

        }
    }
}