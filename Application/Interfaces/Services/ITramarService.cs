using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces.Services
{
    public interface ITramarService
    {
        public void  Worker(List<CardRequest> requestList,List<TramaPosition> tramaList);

    }
}
