using FMS.DAL;
using FMS.Web.Shared.Features.Product;
using FMS.Web.Shared.Features.Shared;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace FMS.Application.Features.Product.ProductPrices
{
    public static class GetProductPricesDropdowns
    {
        public record Query : IRequest<ProductPricesDropdowns>;

        public class Handler : IRequestHandler<Query, ProductPricesDropdowns>
        {
            private readonly FMSContext _context;

            public Handler(FMSContext context)
            {
                _context = context;
            }

            public async Task<ProductPricesDropdowns> Handle(Query request, CancellationToken cancellationToken)
            {
                return new ProductPricesDropdowns
                {
                    PriceLists = await _context.PriceLists
                        .AsNoTracking()
                        .Select(p => new DropdownDto
                        {
                            Id = p.Id,
                            Name = p.Name
                        })
                        .ToListAsync()
                };
            }
        }
    }
}
