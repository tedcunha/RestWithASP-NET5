using RestWithASP_NET5.Model;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface IUsuarioBusiness
    {
        UsuarioModel Create(UsuarioModel usuarioModel);
        UsuarioModel FindByID(int Id);
        List<UsuarioModel> FindAll();
        UsuarioModel Update(UsuarioModel usuarioModel);
        bool Delete(int Id);
    }
}
