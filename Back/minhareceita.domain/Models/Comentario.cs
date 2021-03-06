﻿using System;
using System.Collections.Generic;
using System.Text;

namespace minhareceita.domain.Models
{
    public class Comentario
    {
        public Comentario(string descricao)
        {
            Descricao = descricao;
        }

        public Guid Id { get; private set; }
        public string Descricao { get; private set; }


        // Propriedades de navegação
        public int PerfilId { get; private set; }
        public virtual Perfil Perfil { get; private set; }

        public Guid ReceitaId { get; private set; }
        public virtual Receita Receita { get; private set; }
    }
}
