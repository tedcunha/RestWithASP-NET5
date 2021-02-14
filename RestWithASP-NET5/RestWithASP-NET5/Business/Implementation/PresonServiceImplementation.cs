using RestWithASP_NET5.Model;
using RestWithASP_NET5.Model.Context;
using RestWithASP_NET5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Business.Implementation
{
    public class PresonBusinessImplementation : IUsuarioBusiness
    {

        private readonly IUsuarioRepository _usuarioRepository;

        public PresonBusinessImplementation(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public UsuarioModel Create(UsuarioModel usuarioModel)
        {
            return _usuarioRepository.Create(usuarioModel);
        }

        public bool Delete(int Id)
        {
            return _usuarioRepository.Delete(Id);
        }

        public List<UsuarioModel> FindAll()
        {
            return _usuarioRepository.FindAll();
        }

        public UsuarioModel FindByID(int Id)
        {
            return _usuarioRepository.FindByID(Id);
        }

        public UsuarioModel Update(UsuarioModel usuarioModel)
        {
            if (!_usuarioRepository.Exists(usuarioModel.Id))
            {
                return new UsuarioModel();
            }
            return _usuarioRepository.Update(usuarioModel);
        }
    }
}
