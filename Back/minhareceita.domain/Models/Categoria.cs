using System;
using System.Collections.Generic;
using System.Text;

namespace minhareceita.domain.Models
{
    public class Categoria
    {
        public Categoria(string descricao)
        {
            Descricao = descricao;
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }

        // Propriedades de navegação
        public Guid ReceitaId { get; private set; }
        public virtual Receita Receita { get; private set; }

    }
}
