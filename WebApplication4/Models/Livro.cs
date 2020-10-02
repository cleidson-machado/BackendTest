using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApplication4.Models
{
    /// <summary>
    /// PRA FUNCIONAR ESSE PROJETO QUE UTILIZA O JASON FILE COMO "BANCO DE DADOS" TIVE QUE:
    /// ADD UMA REFERÊNCIA / DEPENDÊNCIA DO System.Runtime.Serialization
    /// ADD AINDA USO DE NEWTON JASON... FRAME P/ MANIPULAR FILES JSON..
    /// AVISO1: A CONTROLLER NA CLASSE: SimpleBookController.cs ESTÁ UTILIZANDO APENAS O MÉTODO DE CONSULTA SEM O USO DO FRAMEWORK NEWTON..
    /// </summary>
    public class Livro
    {
        public string id { get; set; }//SIMULANDO A PK DE UM DATA BASE RELACIONAL...

        public string isbnCode { get; set; }
        public string titulo { get; set; }
        public string subTitulo { get; set; }
        public string autorNome { get; set; }
        public string dataPublicacao { get; set; }//DATA COMO STRING POIS DO CONTRÁRIO DEU RUIM AO USAR CONSULTA LIST SEM O FRAMEWORK.. VER DEPOIS!
        public string editoraNome { get; set; }
        public int quantidadePaginas { get; set; }
        public string descricaoResumida { get; set; }
        public string webSiteLink { get; set; }

        public Livro()
        {
        }
    }
}