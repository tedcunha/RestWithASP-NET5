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
            try
            {
                _context.Add(usuarioModel);
                _context.SaveChanges();
            }
            catch (Exception ex)
            {

                throw new Exception(ex.Message);
            }

            return usuarioModel;
        }

        public bool Delete(int Id)
        {
            bool valido = false;
            var result = _context.UsuarioModels.SingleOrDefault(p => p.Id == Id);
            if (result != null)
            {
                try
                {
                    _context.UsuarioModels.Remove(result);
                    _context.SaveChanges();
                    valido = true;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return valido;
        }

        public List<UsuarioModel> FindAll()
        {
            return _context.UsuarioModels.ToList();
        }

        public UsuarioModel FindByID(int Id)
        {
            return _context.UsuarioModels.SingleOrDefault(p => p.Id == Id);
        }

        public UsuarioModel Update(UsuarioModel usuarioModel)
        {
            if (!Exists(usuarioModel.Id))
            {
                return new UsuarioModel();
            }

            var result = _context.UsuarioModels.SingleOrDefault(p => p.Id == usuarioModel.Id);

            if (result != null)
            {
                try
                {
                    _context.Entry(result).CurrentValues.SetValues(usuarioModel);
                    _context.SaveChanges();
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
            return usuarioModel;
        }

        private bool Exists(int Id)
        {
            return _context.UsuarioModels.Any(p => p.Id == Id);
        }
    }
}
