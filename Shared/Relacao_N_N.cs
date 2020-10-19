using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Desafio_CRUD.Shared
{
    public class JogoGenero
    {
        public int JogoID { get; set; }
        public int GeneroID { get; set; }
        public List<Jogo> Jogos{ get; set; }
        public List<Genero> Generos{ get; set; }
        public Jogo Jogo {get;set;}
        public Genero Genero {get;set;}
    }
}