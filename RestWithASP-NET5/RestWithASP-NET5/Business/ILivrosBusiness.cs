using RestWithASP_NET5.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RestWithASP_NET5.Business
{
    public interface ILivrosBusiness
    {
        LivrosModel Create(LivrosModel livrosModel);
        LivrosModel FindByID(int Id);
        List<LivrosModel> FindAll();
        LivrosModel Update(LivrosModel livrosModel);
        bool Delete(int Id);
    }
}
