using System;
using System.Collections.Generic;
using Dominio;
using Microsoft.AspNetCore.Mvc;
using Persistencia;
using System.Linq;

namespace WebApiCore.Controllers
{

    [ApiController]
    [Route("Datos")]
    public class DatosController: ControllerBase
    {

        /*Aqui necesitamos uasar injeccion de dependencias para injectar el objeto del contexto de nuestra base de datos
        dentro de nuestro controlador y eso lo hacemos con un contructor y 
        una variable privada que instancie de nuestro objeto de la base de datos e indicarle que lo vamos a sobreescribir,
        con readonly indicamos que la vamos a sobreescribir */

        //this tiene acceso a todos los elementos de la clase.
        private readonly ReactMasterContext _context;

        public DatosController(ReactMasterContext Context){
            
            this._context = Context;
        }

        [HttpGet]
        public IEnumerable<Curso> Get(){
            
            /*ToList() es un método de Extension para toda clase que implementa 
            la interface IEnumerable y se encuentra en Linq.*/
            return _context.Curso.ToList();
        }
    }
}