using Modelo.Tabelas;
using Persistencia.Contexts;
using System;
using System.Linq;

namespace Persistencia.DAL.Tabelas
{
    public class CategoriaDAL
    {
        private EFContext context = new EFContext();

        public IQueryable<Categoria> ObterCategoriasClassificadasPorNome()
        {
            return context.Categorias.OrderBy(b => b.Nome);
        }

        public void GravarCategoria(Categoria categoria)
        {
            if(categoria.CategoriaId == Convert.ToInt64(null))
            {
                context.Categorias.Add(categoria);
            }
            else
            {
                context.Entry(categoria).State = System.Data.Entity.EntityState.Modified;
            }
            context.SaveChanges();
        }

        public Categoria ObterCategoriaPorId(long id)
        {
            return context.Categorias.Find(id);
        }

        public Categoria EliminarCategoriaPorId(long id)
        {
            Categoria categoria = ObterCategoriaPorId(id);
            context.Categorias.Remove(categoria);
            context.SaveChanges();
            return categoria;
        }
    }
}
