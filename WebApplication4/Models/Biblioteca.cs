using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    //HERDADA NO MAPEAMENTO DO JSON FILE... CONTEM APENAS A UM LISTA PRA A MODEL LIVRO
    public class Biblioteca
    {        
        public List<Livro> Livros { get; set; }
    }
}