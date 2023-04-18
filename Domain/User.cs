using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{

    public enum TipoUsuario
    {
            Admin = 1,
            Normal = 0
    }
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Pass { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string UrlImagenPerfil { get; set; }
        public bool Admin { get; set; }

       // public User(string email, string pass, string nombre, string apellido, string imagen, bool admin)
       // {
           // Email = email;
          //  Pass = pass;
          //  Nombre = nombre;
          //  Apellido = apellido;
          //  UrlImagenPerfil = imagen;
           // TipoUsuario = admin ? TipoUsuario.Admin : TipoUsuario.Normal;

       // }
    }
}
