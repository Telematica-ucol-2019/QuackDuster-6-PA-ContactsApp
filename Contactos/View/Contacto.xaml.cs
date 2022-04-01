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
    public partial class Contacto : ContentPage
    {
        public Contacto()
        {
            InitializeComponent();
        }


        public void CmbColor(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            if (btn.BackgroundColor.Equals(Color.AliceBlue))
            {
                btn.BackgroundColor = Color.LightGoldenrodYellow;
            }
            else
            {
                btn.BackgroundColor = Color.AliceBlue;
            }
        }


    }
}