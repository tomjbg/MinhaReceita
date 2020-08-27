using System;

namespace minhareceita.api.Dtos
{
    public class PerfilDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public DateTime DataNascimento { get; set; }
        public DateTime DataInscricao { get; set; }
        public string Foto { get; set; }
        public int QtdComentarios { get; set; }
        public int QtdReceitas { get; set; }
    }
}