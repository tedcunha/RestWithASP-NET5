using RestWithASP_NET5.Data.Converter.Contract;
using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Model;
using System.Collections.Generic;
using System.Linq;

namespace RestWithASP_NET5.Data.Converter.Implementations
{
    public class LivrosConverter : IParser<LivrosVO, LivrosModel>, IParser<LivrosModel, LivrosVO>
    {
        public LivrosModel Parse(LivrosVO origem)
        {
            if (origem == null) return null;
            return new LivrosModel
            {
                Id = origem.Id,
                Author = origem.Author,
                Data_Cadastro = origem.Data_Cadastro,
                Preco = origem.Preco,
                Titulo = origem.Titulo
            };
        }

        public LivrosVO Parse(LivrosModel origem)
        {
            if (origem == null) return null;
            return new LivrosVO
            {
                Id = origem.Id,
                Author = origem.Author,
                Data_Cadastro = origem.Data_Cadastro,
                Preco = origem.Preco,
                Titulo = origem.Titulo
            };
        }

        public List<LivrosModel> Parse(List<LivrosVO> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }

        public List<LivrosVO> Parse(List<LivrosModel> origem)
        {
            if (origem == null) return null;
            return origem.Select(item => Parse(item)).ToList();
        }
    }
}
