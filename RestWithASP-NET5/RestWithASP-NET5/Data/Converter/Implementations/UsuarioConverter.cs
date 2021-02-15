using RestWithASP_NET5.Data.Converter.Contract;
using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Data.Converter.Implementations
{
    public class UsuarioConverter : IParser<UsuarioVO, UsuarioModel>, IParser<UsuarioModel, UsuarioVO>
    {
        public UsuarioModel Parse(UsuarioVO origem)
        {
            if (origem == null) return null;
            return new UsuarioModel 
            { Id = origem.Id,
              Nome = origem.Nome,
              SobreNome = origem.SobreNome,
              Endereco = origem.Endereco,
              Genero = origem.Genero
            };
        }

        public UsuarioVO Parse(UsuarioModel origem)
        {
            if (origem == null) return null;
            return new UsuarioVO
            {
                Id = origem.Id,
                Nome = origem.Nome,
                SobreNome = origem.SobreNome,
                Endereco = origem.Endereco,
                Genero = origem.Genero
            };
        }


        public List<UsuarioModel> Parse(List<UsuarioVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<UsuarioVO> Parse(List<UsuarioModel> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
