using Domain;
using MediatR;
using Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Activities
{
    public class Create
    {
        public class Command : IRequest
        {
            //what we are receiving as a parameter from our API
            public Activity Activity { get; set; }
        }

        public class Handler : IRequestHandler<Command>
        {
            private readonly DataContext _context;

            //inject datacontext to persist our changes
            public Handler(DataContext context)
            {
                _context = context;
            }
            public async Task<Unit> Handle(Command request, CancellationToken cancellationToken)
            {
                _context.Activities.Add(request.Activity); //not touching the db just adding the activity in memory

                await _context.SaveChangesAsync(); //save changes to the db

                return Unit.Value; //a way of letting our api controller know we are finished with the create.
            }
        }
    }
}
