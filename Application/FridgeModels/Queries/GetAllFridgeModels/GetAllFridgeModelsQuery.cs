using Domain.DTOs;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.FridgeModels.Queries.GetAllFridgeModels
{
    public class GetAllFridgeModelsQuery : IRequest<IEnumerable<FridgeModelDto>>
    {
    }
}
