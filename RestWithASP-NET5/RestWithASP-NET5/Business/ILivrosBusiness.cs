using RestWithASP_NET5.Data.VO;
using RestWithASP_NET5.Model;
using System.Collections.Generic;

namespace RestWithASP_NET5.Business
{
    public interface ILivrosBusiness
    {
        LivrosVO Create(LivrosVO livrosModel);
        LivrosVO FindByID(int Id);
        List<LivrosVO> FindAll();
        LivrosVO Update(LivrosVO livrosModel);
        bool Delete(int Id);
    }
}
