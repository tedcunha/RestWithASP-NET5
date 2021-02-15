using RestWithASP_NET5.Data.VO;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface IUsuarioBusiness
    {
        UsuarioVO Create(UsuarioVO usuarioModel);
        UsuarioVO FindByID(int Id);
        List<UsuarioVO> FindAll();
        UsuarioVO Update(UsuarioVO usuarioModel);
        bool Delete(int Id);
    }
}
