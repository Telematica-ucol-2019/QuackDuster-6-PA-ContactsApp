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
    public partial class ContactoDetalle : ContentPage
    {
        public ContactoDetalle(Models.Contacto contacto, ContactoViewModel vm)
        {
            InitializeComponent();
            vm.Contacto = new Models.Contacto();
            vm.Contacto = contacto;
            this.BindingContext = vm;
        }
    }
}