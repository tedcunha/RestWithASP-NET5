using RestWithASP_NET5.Model;
using RestWithASP_NET5.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Business.Implementation
{
    public class LivrosBusinessImplementation : ILivrosBusiness
    {
        private readonly IRepository<LivrosModel> _livrosRepository;

        public LivrosBusinessImplementation(IRepository<LivrosModel> livrosRepository)
        {
            _livrosRepository = livrosRepository;
        }
        public LivrosModel Create(LivrosModel livrosModel)
        {
            return _livrosRepository.Create(livrosModel);
        }

        public bool Delete(int Id)
        {
            return _livrosRepository.Delete(Id);
        }

        public List<LivrosModel> FindAll()
        {
            return _livrosRepository.FindAll();
        }

        public LivrosModel FindByID(int Id)
        {
            return _livrosRepository.FindByID(Id);
        }

        public LivrosModel Update(LivrosModel livrosModel)
        {
            if (!_livrosRepository.Exists(livrosModel.Id))
            {
                return new LivrosModel();
            }
            return _livrosRepository.Update(livrosModel);
        }
    }
}
