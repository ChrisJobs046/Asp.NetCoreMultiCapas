using System.Threading;
using System.Threading.Tasks;
using Dominio;
using MediatR;
using Persistencia;

namespace Aplicacion.Cursos
{
    public class ConsultaId
    {
        //Curso unico se comunicara con los controladores de WebApi
        public class CursoUnico: IRequest<Curso>{

            public int Id { get; set; }
        }

        public class Manejador : IRequestHandler<CursoUnico, Curso>
        {
            private readonly ReactMasterContext _context;
            public Manejador(ReactMasterContext context)
            {
                _context = context;
            }

            public async Task<Curso> Handle(CursoUnico request, CancellationToken cancellationToken)
            {
                var curso = _context.Curso.FindAsync(request.Id);
                return await curso;
            }
        }
    }
}