using Microsoft.Ajax.Utilities;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Runtime.Serialization.Json;
using System.Text;
using System.Web.Http;
using WebApplication4.DaoAccess;
using WebApplication4.Models;

namespace WebApplication4.Controllers
{
    //CONTROLLER QUE ((NÃO UTILIZA)) O FRAMEWORK DE MANIPULAÇÃO PARA JSON FILES
    public class SimpleBookController : ApiController
    {
        // GET: api/SimpleBook
        public Biblioteca Get()
        {
            LivroDaoDefault consulta = new LivroDaoDefault();            
            return consulta.listAllNoFrameworksJsonFile();
        }

        // GET: api/SimpleBook/5
        public Object Get(int id)
        {
            //AQUI USO OS DOIS TIPOS COM E SEM O FRAMEWORK
            LivroDaoDefault consulta = new LivroDaoDefault();
            return consulta.selectById(id);
        }

        //AQUI UM TESTES DE CONSULTA INACABADO NO MOMENTO
        // GET: api/Book/5?nome=
        public Object GetNew(int id, string nome)
        {
            LivroDaoDefault consulta = new LivroDaoDefault();
            return consulta.selectByIdAndName(id, nome);
        }

        // POST: api/SimpleBook
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/SimpleBook/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/SimpleBook/5
        public void Delete(int id)
        {
        }
    }
}
