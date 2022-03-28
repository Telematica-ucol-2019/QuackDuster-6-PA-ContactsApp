using Contactos.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace Contactos.ViewModel
{
    public class ContactoViewModel : BaseViewModel
    {
        #region Propiedades
        public ObservableCollection<Contacto> Contactos { get; set; }
        #endregion

        private Contacto contacto;
        public Contacto Contacto
        {
            get { return contacto; }
            set { contacto = value; OnPropertyChanged(); }
        }

        public ICommand cmdContactoDetalle { get; set; }
        public ICommand cmdContactoElimina { get; set; }
        public ICommand cmdContactoEdita { get; set; }
        public ICommand cmdContactoCancelar { get; set; }
        public ICommand cmdContactoGuardar { get; set; }
        public ContactoViewModel()
        {
            Contactos = new ObservableCollection<Contacto>();
            Contactos.Add(new Contacto()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = "Alberto",
                ApellidoPaterno = "Osorio",
                ApellidoMaterno = "Rodriguez",
                Organizacion = "Facultad de Telematica",
                Telefonos = new ObservableCollection<Telefono> { new Telefono { Id = Guid.NewGuid().ToString(), Numero= "3123155562" },
                new Telefono {Id = Guid.NewGuid().ToString(), Numero= "312312245"} 
                }

            });

            Contactos.Add(new Contacto()
            {
                Id = Guid.NewGuid().ToString(),
                Nombre = "Roberto",
                ApellidoPaterno = "Martinez",
                ApellidoMaterno = "Gonzales",
                Organizacion = "Facultad de Telematica",
                Telefonos = new ObservableCollection<Telefono> { new Telefono { Id = Guid.NewGuid().ToString(), Numero= "312315567" },
                new Telefono {Id = Guid.NewGuid().ToString(), Numero= "312316789"}
                }

            });

            cmdContactoDetalle = new Command<Contacto>(async (x) => await PCmdContactoDetalle(x));
            cmdContactoElimina = new Command<Contacto>(async (x) => await PCmdContactoElimina(x));
            cmdContactoEdita = new Command<Contacto>(async (x) => await PCmdContactoEdita(x));
            cmdContactoCancelar = new Command(async () => await PCmdContactoCancelar());
            cmdContactoGuardar = new Command<Contacto>(async (x) => await PCmdContactoGuardar(x));

            async Task PCmdContactoDetalle(Models.Contacto _Contacto)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.ContactoDetalle(_Contacto, this));
            }

            async Task PCmdContactoElimina(Models.Contacto _Contacto)
            {
                int indice = Contactos.IndexOf(_Contacto);

                if(indice >= 0)
                {
                    Contactos.Remove(_Contacto);
                    OnPropertyChanged();
                }

                await Application.Current.MainPage.Navigation.PopAsync();
            }

            async Task PCmdContactoEdita(Models.Contacto _Contacto)
            {
                await Application.Current.MainPage.Navigation.PushAsync(new View.ContactoMatto(Contacto, this));
            }

            async Task PCmdContactoCancelar()
            {
                await Application.Current.MainPage.Navigation.PopAsync();
            }

            async Task PCmdContactoGuardar(Models.Contacto _Contacto)
            {
                int indice = -1;
                Contacto tmp = Contactos.FirstOrDefault(item => item.Id == _Contacto.Id);

                if(tmp != null)
                {
                    //Editando un contacto
                    indice = Contactos.IndexOf(tmp);
                    Contactos[indice] = _Contacto;
                }

                OnPropertyChanged();

                await Application.Current.MainPage.Navigation.PopAsync();
                await Application.Current.MainPage.Navigation.PopAsync();
            }



        }
    }
}
