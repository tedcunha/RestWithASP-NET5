using RestWithASP_NET5.Data.Converter.Implementations;
using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Model;
using RestWithASP_NET5.Repository;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business.Implementation
{
    public class PresonBusinessImplementation : IUsuarioBusiness
    {

        private readonly IRepository<UsuarioModel> _usuarioRepository;
        private readonly UsuarioConverter _usuarioConverter;

        public PresonBusinessImplementation(IRepository<UsuarioModel> usuariorepository)
        {
            _usuarioRepository = usuariorepository;
            _usuarioConverter = new UsuarioConverter();
        }

        public UsuarioVO Create(UsuarioVO usuarioModel)
        {
            var usuarioEntity = _usuarioConverter.Parse(usuarioModel);
            usuarioEntity = _usuarioRepository.Create(usuarioEntity);
            return _usuarioConverter.Parse(usuarioEntity);
        }

        public bool Delete(int Id)
        {
            return _usuarioRepository.Delete(Id);
        }

        public List<UsuarioVO> FindAll()
        {
            return _usuarioConverter.Parse(_usuarioRepository.FindAll());
        }

        public UsuarioVO FindByID(int Id)
        {
            return _usuarioConverter.Parse(_usuarioRepository.FindByID(Id));
        }

        public UsuarioVO Update(UsuarioVO usuarioModel)
        {
            var usuarioEntity = _usuarioConverter.Parse(usuarioModel);
            usuarioEntity = _usuarioRepository.Update(usuarioEntity);
            return _usuarioConverter.Parse(usuarioEntity);
        }
    }
}
