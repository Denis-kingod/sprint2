using WebApplication1.Properties.Domains;

namespace senai.inLock.webAPI.Interfaces
{
    interface IUsuariosRepository
    {
        UsuariosDomain Login(string email, string senha);
    }
}
