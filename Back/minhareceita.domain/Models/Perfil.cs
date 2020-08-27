
using System;
using System.Collections.Generic;
using System.Text;
using minhareceita.domain.Models;


namespace minhareceita.domain.Models
{
    public class Perfil
    {
        public int Id { get; private set; }
        public string Username { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataInscricao { get; private set; }
        public string Foto { get; private set; }


        // Propriedades de navegação
        public int UsuarioId { get; private set; }
        public virtual ICollection<Comentario> Comentarios { get; private set; }
        public virtual ICollection<Receita> Receitas { get; private set; }

    }
}
