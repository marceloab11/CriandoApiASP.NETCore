using ScreenSound.Modelos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ScreenSound.Banco
{
    internal class Dal<T> where T : class
    {
        protected readonly ScreenSoundContext context;
        public Dal(ScreenSoundContext context)
        {
            this.context = context;
        }
        public  IEnumerable<T> Listar()
        {
            return context.Set<T>().ToList();
        }

        public void Adicionar(T obejeto)
        {
            context.Set<T>().Add(obejeto);
            context.SaveChanges();
        }

        public void Atualizar(T objeto)
        {
            context.Set<T>().Update(objeto);
            context.SaveChanges();
        }

        public void Delete(T objeto)
        {
            context.Set<T>().Remove(objeto);
            context.SaveChanges();
        }

        public T? RecuperarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().FirstOrDefault(condicao);
        }

        public IEnumerable<T> ListarPor(Func<T, bool> condicao)
        {
            return context.Set<T>().Where(condicao);
        }
    }
}
