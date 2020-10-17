using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;


namespace Desafio_CRUD.Shared
{
    public class Genero
    {
        [Required (ErrorMessage = "ID é obrigatório")]
        public int ID { get; set; }
        [Required (ErrorMessage = "Nome é obrigatório")]
        public string Nome { get; set; }
        public int Jogo_ID { get; set; }
        public Jogo Jogo { get; set; }
    }
}