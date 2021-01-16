using RestWithASP_NET5.Model;
using System.Collections.Generic;

namespace RestWithASP_NET5.Services
{
    public interface IUsuarioService
    {
        UsuarioModel Create(UsuarioModel usuarioModel);
        UsuarioModel FindByID(int Id);
        List<UsuarioModel> FindAll();
        UsuarioModel Update(UsuarioModel usuarioModel);
        void Delete(int Id);
    }
}
