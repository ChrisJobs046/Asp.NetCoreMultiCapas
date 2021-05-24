using System.Collections.Generic;
using System.Threading.Tasks;
using Aplicacion.Cursos;
using Dominio;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace WebApiCore.Controllers
{
    //este es el endpoint
    //http://localhost:5000/api/Cursos
    [Route("api/[controller]")]
    [ApiController]
    public class CursosController: ControllerBase
    {
        private readonly IMediator _mediator;

        public CursosController(IMediator mediator){

            _mediator = mediator;
        }

        /*Como es un metodo que obtiene datos le ponemos la nomenclatura [HttpGet]
        esto es un metodo asincrono que tiene un ActionResult y le pasamos que devuelve una lista de Curso
        que se encuentra en dominio luego retornamos de mediator pasandole un metodo send y dentro entonces le indicamos
        que cree un nuevo objeto de Consulta que es la clase que esta dentro de aplicacion y le pasamos la
        cabecera consultaList que tiene dentro.
        */

        [HttpGet]
        public async Task<ActionResult<List<Curso>>> Get(){

            return await _mediator.Send(new Consulta.ConsultaList());
        }


        /*le pasamos el parametro id Indicandole que el id que pase el usuario sera igual al Id de la propiedad 
        dentro de cursoUnico y esto lo ponemos detro del return donde devolvemos una respuesta de _mediator de la
        clase consultaId que es la que tiene dentro CursoUnico*/

        //http://localhost:5000/api/Cursos/{id}
        [HttpGet("{id}")]
        public async Task<ActionResult<Curso>> Detalle(int id){
            
            return await _mediator.Send(new ConsultaId.CursoUnico{Id = id});  
        }
    }
}