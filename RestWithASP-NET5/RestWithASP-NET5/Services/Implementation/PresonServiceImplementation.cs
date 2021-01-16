using RestWithASP_NET5.Model;
using RestWithASP_NET5.Model.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Services.Implementation
{
    public class PresonServiceImplementation : IUsuarioService
    {
        private MySqlContext _context;

        public PresonServiceImplementation(MySqlContext context)
        {
            _context = context;
        }

        public UsuarioModel Create(UsuarioModel usuarioModel)
        {
            return new UsuarioModel
            {
                Id = 1,
                Nome = usuarioModel.Nome,
                SobreNome = usuarioModel.SobreNome,
                Endereco = usuarioModel.Endereco,
                Genero = usuarioModel.Genero
            };
        }

        public void Delete(int Id)
        {
            
        }

        public List<UsuarioModel> FindAll()
        {
            return _context.UsuarioModels.ToList();
        }

        public UsuarioModel FindByID(int Id)
        {
            return new UsuarioModel
            {
                Id = Id,
                Nome = "Ricardo",
                SobreNome = "Cunha",
                Endereco = "Rua Tiradentes, 1837 - Bloco 11 / Apto 71, Dta Terezinha, SBC",
                Genero = "Masculino"
            };
        }

        public UsuarioModel Update(UsuarioModel usuarioModel)
        {
            return new UsuarioModel
            {
                Id = 1,
                Nome = usuarioModel.Nome,
                SobreNome = usuarioModel.SobreNome,
                Endereco = usuarioModel.Endereco,
                Genero = usuarioModel.Genero
            };
        }
    }
}
