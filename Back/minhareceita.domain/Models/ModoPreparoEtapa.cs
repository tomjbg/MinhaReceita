using System;
using System.Collections.Generic;
using System.Text;

namespace minhareceita.domain.Models
{
    public class ModoPreparoEtapa
    {
        public ModoPreparoEtapa(int etapa, string descricao)
        {
            Etapa = etapa;
            Descricao = descricao;
        }

        public Guid Id { get; private set; }
        public int Etapa { get; private set; }
        public string Descricao { get; private set; }

        // Propriedades de navegação
        public Guid ReceitaId { get; private set; }
        public virtual Receita Receita { get; private set; }

    }
}
