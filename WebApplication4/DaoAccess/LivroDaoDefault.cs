using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Text;
using System.Runtime.Serialization.Json;
using WebApplication4.Models;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Security.Principal;
using System.Web.WebPages;

namespace WebApplication4.DaoAccess
{
    public class LivroDaoDefault
    {
        //STRING CENTRALIZADORA QUE RECEBE O PATH DO ARQUIVO JSON NO PROJETO!!!
        string json = File.ReadAllText(AppDomain.CurrentDomain.BaseDirectory + @"\DataJsonFiles\LivrosFileValidated.json");

        //MÉTODO LIST ALL ((COM)) O USO DO FRAMEWORK
        public Biblioteca listAllWithFrameworksJsonFile()
        {
            //USANDO O FRAME PARA "TRATAR" O JSON FILE E DEIXAR DISPONIVEL NO APP 
            Biblioteca livroData = JsonConvert.DeserializeObject<Biblioteca>(json); //AQUI A MODEL BIBLIOTECA TRAZ A LISTA DOS LIVROS
            return livroData;
        }


        //MÉTODO LIST ALL ((SEM)) USO DO FRAMEWORK
        public Biblioteca listAllNoFrameworksJsonFile ()
        {
            //VARIÁVEL CRIADA PARA RECEBER E "TRATAR" O JSON
            var js = new DataContractJsonSerializer(typeof(Biblioteca));

            //FILE JSON JÁ LIDO + ADD NA MEMORIA + PADRONIZA UM UTF8 
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

            //CLASSE MODEL LIVRO (VIA BIBLIOTECA) + JSON NA MEMORIA....
            var livroData = (Biblioteca)js.ReadObject(ms);//AQUI A MODEL BIBLIOTECA TRAZ A LISTA DOS LIVROS

            return livroData;
        }


        //SIMULAÇÃO DE SELECIONAR PELO ID RE-PASSADO NA URI DO END POINT
        public Livro selectById(int id)
        {
            Biblioteca fileJsonData = JsonConvert.DeserializeObject<Biblioteca>(json);
            string json_serializado = JsonConvert.SerializeObject(fileJsonData);
            JObject jsonConvertidoObjeto = JObject.Parse(json_serializado);

            //RANGE DE REGISTROS
            int qtdRegistros = contadorDeLivros(id);

            Livro livroPreenchido = new Livro();
            int posicao = id - 1;

            //SE O ID INFORMADO ESTIVER DENTRO DO RANGE UM OBJETO REPLETO É EXIBIDO NO END POINT
            if (id <= qtdRegistros && id > 0)
            {
                livroPreenchido.id = (string)jsonConvertidoObjeto["Livros"][posicao]["id"];
                livroPreenchido.isbnCode = (string)jsonConvertidoObjeto["Livros"][posicao]["isbnCode"];
                livroPreenchido.titulo = (string)jsonConvertidoObjeto["Livros"][posicao]["titulo"];
                livroPreenchido.subTitulo = (string)jsonConvertidoObjeto["Livros"][posicao]["subTitulo"];
                livroPreenchido.autorNome = (string)jsonConvertidoObjeto["Livros"][posicao]["autorNome"];
                livroPreenchido.dataPublicacao = (string)jsonConvertidoObjeto["Livros"][posicao]["dataPublicacao"];
                livroPreenchido.editoraNome = (string)jsonConvertidoObjeto["Livros"][posicao]["editoraNome"];
                livroPreenchido.quantidadePaginas = (int)jsonConvertidoObjeto["Livros"][posicao]["quantidadePaginas"];
                livroPreenchido.descricaoResumida = (string)jsonConvertidoObjeto["Livros"][posicao]["descricaoResumida"];
                livroPreenchido.webSiteLink = (string)jsonConvertidoObjeto["Livros"][posicao]["webSiteLink"];
            }
            else 
            {
                //SE O ID INFORMADO ESTIVER FORA DO RANGE...
                Livro livroVazio = new Livro();
                return livroVazio;
            }

            return livroPreenchido;
        }


        //FORMA TEMPORÁRIA ENCONTRADA PARA CASAR COM A DEMANDA DESSE PROJETO... 
        //E COM OS MEUS CONHECIMENTOS ATUAIS DAS BASES / FUNDAMENTOS DA LINGUAGEM c#...
        public int contadorDeLivros(int id)
        {
            var js = new DataContractJsonSerializer(typeof(Biblioteca));
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var livroData = (Biblioteca)js.ReadObject(ms);

            int quantidadeDeLivros = (int)livroData.Livros.Count;

            return quantidadeDeLivros;
        }


        //TESTE## "CONSULTANDO" PELO ID E NOME NA POSIÇÃO ESPECÍFICA...
        //FORMA TEMPORÁRIA ENCONTRADA PARA CASAR COM A DEMANDA DESSE PROJETO... 
        //E COM OS MEUS CONHECIMENTOS ATUAIS DAS BASES / FUNDAMENTOS DA LINGUAGEM c#...
        public Livro selectByIdAndName(int id, string mome)
        {
            string doNome = mome;

            Biblioteca fileJsonData = JsonConvert.DeserializeObject<Biblioteca>(json);
            string json_serializado = JsonConvert.SerializeObject(fileJsonData);
            JObject jsonConvertidoObjeto = JObject.Parse(json_serializado);

            //RANGE DE REGISTROS
            int qtdRegistros = contadorDeLivros(id);

            Livro livroPreenchido = new Livro();
            int posicao = id - 1;

            string nomeNaPosisao = (string)jsonConvertidoObjeto["Livros"][posicao]["autorNome"];

            //SE O ID INFORMADO ESTIVER DENTRO DO RANGE UM OBJETO REPLETO É EXIBIDO NO END POINT
            if (id <= qtdRegistros && id > 0)
            {
                if (!String.IsNullOrEmpty(doNome))//APENAS PARA SEPARAR CASO NÃO PASSE NENHUM VALOR!
                {
                    if (doNome == nomeNaPosisao)
                    {
                        livroPreenchido.id = (string)jsonConvertidoObjeto["Livros"][posicao]["id"];
                        livroPreenchido.isbnCode = (string)jsonConvertidoObjeto["Livros"][posicao]["isbnCode"];
                        livroPreenchido.titulo = (string)jsonConvertidoObjeto["Livros"][posicao]["titulo"];
                        livroPreenchido.subTitulo = (string)jsonConvertidoObjeto["Livros"][posicao]["subTitulo"];
                        livroPreenchido.autorNome = (string)jsonConvertidoObjeto["Livros"][posicao]["autorNome"];
                        livroPreenchido.dataPublicacao = (string)jsonConvertidoObjeto["Livros"][posicao]["dataPublicacao"];
                        livroPreenchido.editoraNome = (string)jsonConvertidoObjeto["Livros"][posicao]["editoraNome"];
                        livroPreenchido.quantidadePaginas = (int)jsonConvertidoObjeto["Livros"][posicao]["quantidadePaginas"];
                        livroPreenchido.descricaoResumida = (string)jsonConvertidoObjeto["Livros"][posicao]["descricaoResumida"];
                        livroPreenchido.webSiteLink = (string)jsonConvertidoObjeto["Livros"][posicao]["webSiteLink"];
                    }
                }
            }
            else
            {
                //SE O ID INFORMADO ESTIVER FORA DO RANGE...
                Livro livroVazio = new Livro();
                return livroVazio;
            }

            return livroPreenchido;
        }


        //TESTES##TESTES##TESTES##TESTES##TESTES##TESTES##TESTES##
        public Livro selectByAuthorName(string mome)
        {
            string doNome = mome;
            //Livro livro = new Livro();

            //IEnumerable<Livro> encontrados =
            //    from livro in livros
            //    where livro.autorNome = doNome
            //    orderby livro descending
            //    select livro;
            //Console.WriteLine(string.Join(" ", encontrados));


            //var scores = new[] { 90, 97, 78, 68, 85 };
            //IEnumerable<int> highScoresQuery =
            //    from score in scores
            //    where score > 80
            //    orderby score descending
            //    select score;
            //Console.WriteLine(string.Join(" ", highScoresQuery));


            return null;
        }


            //TESTES##TESTES##TESTES##TESTES##TESTES##TESTES##TESTES##
            public string Method1(int id)
        {
            //CLASSE CRIADA PARA RECEBER O JSON
            var js = new DataContractJsonSerializer(typeof(Biblioteca));

            //FILE JSON JÁ LIDO 
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

            //CLASSE + JSON NA MEMORIA....
            var livro = (Biblioteca)js.ReadObject(ms);

            //TESTE DE CONTADOR
            int qtdLivrosJson = (int)livro.Livros.Count;

            string resposta = "A QUANTIDADE DE LIVROS ENCONTRADOS É:" + " " + qtdLivrosJson;

            return resposta;
        }


        //TESTESTESTES##TESTES##TESTES##TESTES##TESTES##TESTES##TESTES##
        public string Method2(int id)
        {
            //CLASSE CRIADA PARA RECEBER O JSON
            var js = new DataContractJsonSerializer(typeof(Biblioteca));

            //FILE JSON JÁ LIDO 
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));

            //CLASSE + JSON NA MEMORIA....
            var livro = (Biblioteca)js.ReadObject(ms);

            //TESTE DE CONTADOR
            int qtdLivrosJson = (int)livro.Livros.Count;

            string resposta = "A QUANTIDADE DE LIVROS ENCONTRADOS É:" + " " + qtdLivrosJson;

            //string resposta = null;

            //int x = 0;
            //for (int i = 0; i < (int)livro.Livros.Count; ++i)
            //    if (id == 1)
            //    {
            //        x = x + 1;
            //    }

            int teste = qtdLivrosJson;

            while (teste <= 0)
            {
                teste--;
            }

            return resposta;
        }


        //TESTESTESTES##TESTES##TESTES##TESTES##TESTES##TESTES##TESTES##TESTES##
        public string Method3(int id)
        {
            var js = new DataContractJsonSerializer(typeof(Biblioteca));             
            var ms = new MemoryStream(Encoding.UTF8.GetBytes(json));
            var livroData = (Biblioteca)js.ReadObject(ms);
            
            int quantidadeDeLivros = (int)livroData.Livros.Count;

            Livro livro = new Livro();

            //ISSO PODE SER LEGAR DE USAR...!!?
            int posicao = id - 1;

            if (id <= quantidadeDeLivros)
            {
                string msn1 = "ENCONTRADO UM REGISTRO!";
                return msn1;
            }
            else
            {
                string msn2 = "NÃO ENCONTRADO!";
                return msn2;
            }

            //FIM.. DO MÉTODO.. AQUI FICARIA O RETURN DEFAULT DO MESMO!
        }


    }
}