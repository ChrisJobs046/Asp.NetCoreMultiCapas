using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class Consulta
    {
        /*Esta clase representa lo que va a devolver consulta de nuestra base de datos
        entonces le decimos que IRequest devolvera una Lista de tipo Curso.
        Entonces consultaList devolvera una lista de objetos de tipo irequest envolviendo una lista de clases curso
        */
        public class ConsultaList : IRequest<List<Curso>> {}

        /*Le decimos que la clase Manejador Proviene de IRequestHandler
        Entonces Aqui nos obliga a implementar un metodo de la interfaz que seria Handle
        Entonces manejador esta implemetando la interfaz IRequest. Dentro del metodo
        tenemos que consumir la base de datos para implementar la logica.
        Handle
        */
        public class Manejador : IRequestHandler<ConsultaList, List<Curso>>
        {
            /*Aqui injectamos el contexto de nuestra base de datos dentro de la clase Manejador*/
            private readonly ReactMasterContext _context;
            public Manejador(ReactMasterContext context){

                _context = context;
            }

            public async Task<List<Curso>> Handle(ConsultaList request, CancellationToken cancellationToken)
            {
                //tenemos que aprender a trabajar con procesos asincronos osea que trae y devuelve
                var cursos = await _context.Curso.ToListAsync();
                return cursos;
            }
        }
    }
}