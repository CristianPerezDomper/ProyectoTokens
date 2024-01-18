namespace Proyecto01.Models
{
    public class Usuario
    {

        public string idUsuario { get; set; }
        public string usuario { get; set; }
        public string password { get; set; }
        public string rol { get; set; }


        //Base de dato temporal
        public static List<Usuario> DB()
        {
            var list = new List<Usuario>()
            {
                new Usuario
                {
                    idUsuario= "1",
                    usuario= "Mateo",
                    password = "123.",
                    rol = "empleado"
                },
                new Usuario
                {
                    idUsuario= "2",
                    usuario= "Lucas",
                    password = "123.",
                    rol = "asesor"
                },
                new Usuario
                {
                    idUsuario= "3",
                    usuario= "Juan",
                    password = "123.",
                    rol = "administrador"
                },
                new Usuario
                {
                    idUsuario= "4",
                    usuario= "Juan",
                    password = "123.",
                    rol = "empleado"
                },
            };

            return list;
        }
    }
}
