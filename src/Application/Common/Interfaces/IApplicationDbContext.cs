using Application.Locations.Queries.GetLocations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.Common.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<LocationDto> LocationDtos { get; set; }
    }
}
