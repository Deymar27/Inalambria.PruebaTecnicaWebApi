using Inalambria.PruebaTecnica.Model;

namespace Inalambria.PruebaTecnica.Constant
{
    public class UsuarioConstante
    {
        //Declaramos una constante, lista de los usuarios que pueden autenticarse
        public static List<UsuarioModel> usuario = new List<UsuarioModel>() {
            //creamos la lista con las propiedades del objeto Usuario Model
            new UsuarioModel() { usuario = "Dromero" , contrasena = "admin123"}

        };
                
    }
}
