using Application.Interfaces;
using Application.Interfaces.Services;
using Application.Wrappers;
using Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.Features.CardRequestFeature.Queries.GetAllCardRequestQuery
{
    public class GetAllCardRequestQuery : IRequest<bool>
    {
    

        public class GetAllCardRequestQueryHandler : IRequestHandler<GetAllCardRequestQuery,bool>
        {
            private readonly ICardRequestRepository _repository;
            private readonly ITramarService _workerservice;
            private readonly ITramaPosition _tramaPosition;

            public GetAllCardRequestQueryHandler(ICardRequestRepository repository, ITramarService workerservice, ITramaPosition tramaPosition)
            {
                _repository = repository;
                _workerservice = workerservice;
                _tramaPosition = tramaPosition;
            }

            public async Task<bool> Handle(GetAllCardRequestQuery request, CancellationToken cancellationToken)
            {
                var requestsList = await _repository.GetAllCardRequest();
                var tramaList = await _tramaPosition.GetTramaPosition();
                 _workerservice.Worker(requestsList, tramaList);

                return true;
            }
        }

    }
}
