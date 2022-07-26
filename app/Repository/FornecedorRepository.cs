using SistemaPedidos.Context;
using SistemaPedidos.Dto;
using SistemaPedidos.Interfaces;
using SistemaPedidos.Models;

namespace SistemaPedidos.Repository
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly MovieContext _context;

        public FornecedorRepository(MovieContext context)
        {
            _context = context;
        }

        public ICollection<Fornecedor> getALL()
        {
            return _context.Fornecedores.OrderBy(f => f.Id).ToList();
        }

        public Fornecedor get(int Id)
        {   

            var fornecedor = _context.Fornecedores.Find(Id);
           _context
                .Entry(fornecedor)
                .Collection("Pedidos")
                .Load();

            return fornecedor;
        }
        
        public bool Create(Fornecedor fornecedor)
        {
            _context.Add(fornecedor);
            return Save();
        }
        public bool Update(Fornecedor fornecedor)
        {
           _context.Update(fornecedor);
            return Save();
        }
        public bool Delete(int Id)
        {   
            var fornecedor = _context.Fornecedores.Find(Id);
            _context.Remove(fornecedor);
            return Save();
        }
        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }

        public bool Exists(int Id)
        {
            return _context.Fornecedores.Any(p => p.Id == Id);
        }
    }
}