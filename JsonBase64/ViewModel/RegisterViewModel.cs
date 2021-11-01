using JsonBase64.Model;
using JsonBase64.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace JsonBase64.ViewModel
{
    public class RegisterViewModel : BaseViewModel<Model.Usuario>
    {
        private string _jsonResult;
        private Command _registerCommand;
        private UsuariosService usuariosService;

        public RegisterViewModel(Usuario model = null ) : base(model)
        {
            if(model == null)
            {
                Model = new Usuario();
            }

            usuariosService = new UsuariosService();
        }

        public string UserName
        {
            get => Model.UserName;
            set
            {
                if (string.Equals(value, Model.UserName)) return;
                Model.UserName = value;
                OnpropertyChanged();
            }
        }
        public string Password
        {
            get => Model.Password;
            set
            {
                if (string.Equals(value, Model.Password)) return;
                Model.Password = value;
                OnpropertyChanged();
            }
        }
        public string Name
        {
            get => Model.Name;
            set
            {
                if (string.Equals(value, Model.Name)) return;
                Model.Name = value;
                OnpropertyChanged();
            }
        }
        public string Ap1
        {
            get => Model.Ap1;
            set
            {
                if (string.Equals(value, Model.Ap1)) return;
                Model.Ap1 = value;
                OnpropertyChanged();
            }
        }
        public string Ap2
        {
            get => Model.Ap2;
            set
            {
                if (string.Equals(value, Model.Ap2)) return;
                Model.Ap2 = value;
                OnpropertyChanged();
            }
        }
        public Command RegisterCommand
        {
            get => _registerCommand ??
                (_registerCommand = new Command(RegisterActionAsync));
                
        }

        public string JsonResult
        {
            get => _jsonResult;
            set
            {
                if (string.Equals(_jsonResult, value)) return;
                _jsonResult = value;
                OnpropertyChanged();
            }
        }

        private async void RegisterActionAsync()
        {
            Usuario newObject = EncripOrDecriptData(true);
            //JsonResult = ModelToJson(newObject);

            JsonResult = await usuariosService?.RegisterAsync(newObject);
        }
    }
}
