using RestWithASP_NET5.Data.Converter.Implementations;
using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Model;
using RestWithASP_NET5.Repository;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business.Implementation
{
    public class LivrosBusinessImplementation : ILivrosBusiness
    {
        private readonly IRepository<LivrosModel> _livrosRepository;
        private readonly LivrosConverter _livrosConverter;

        public LivrosBusinessImplementation(IRepository<LivrosModel> livrosRepository)
        {
            _livrosRepository = livrosRepository;
            _livrosConverter = new LivrosConverter();
        }
        public LivrosVO Create(LivrosVO livrosModel)
        {
            var livrosEntity = _livrosConverter.Parse(livrosModel);
            livrosEntity = _livrosRepository.Create(livrosEntity);
            return _livrosConverter.Parse(livrosEntity);
        }

        public bool Delete(int Id)
        {
            return _livrosRepository.Delete(Id);
        }

        public List<LivrosVO> FindAll()
        {
            return _livrosConverter.Parse(_livrosRepository.FindAll());
        }

        public LivrosVO FindByID(int Id)
        {
            return _livrosConverter.Parse(_livrosRepository.FindByID(Id));
        }

        public LivrosVO Update(LivrosVO livrosModel)
        {
            var livrosEntity = _livrosConverter.Parse(livrosModel);
            livrosEntity = _livrosRepository.Update(livrosEntity);
            return _livrosConverter.Parse(livrosEntity);
        }
    }
}
