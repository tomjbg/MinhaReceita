using System;
using System.Collections.Generic;
using System.Text;

namespace minhareceita.domain.Models
{
    public class Receita
    {
        public Guid Id { get; private set; }
        public string Nome { get; private set; }
        public int Avaliacao { get; private set; }
        public string Video { get; private set; }
        public int Curtidas { get; private set; }
        public int TempoPreparoMinutos { get; private set; }
        public int QtdPorcoes { get; private set; }
        public int QtdFavoritados { get; private set; }
        public string Imagens { get; private set; }
        public virtual string Ingredientes { get; private set; }

        // Propriedades de navegação
        public int PerfilId { get; private set; }
        public virtual Perfil Perfil { get; private set; }
        public virtual Categoria Categoria { get; private set; }
        public virtual ICollection<Comentario> Comentarios { get; private set; }
        public virtual ICollection<ModoPreparoEtapa> ModoPreparoEtapas { get; private set; }

    }
}
