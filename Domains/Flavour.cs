using api.Domains.Interfaces;
using api.DTOs;
using api.Models;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Extensions.Configuration;

namespace api.Domains
{
    public class Flavour : IFlavour
    {
        private readonly string domain;

        private readonly Context context;

        private readonly ILogger logger;

        public Flavour(Context _context, ILogger<Flavour> _logger)
        {
            context = _context;
            logger = _logger;
        }

        public IConfiguration Configuration { get; }

        public List<FlavourDTO> ReadFlavours()
        {
            List<FlavourDTO> flavours = new List<FlavourDTO>();

            foreach (Models.Flavour flavour in context.Flavours)
            {
                flavours.Add(new FlavourDTO
                {
                    Id = flavour.Id,
                    CreatedAt = flavour.CreatedAt,
                    Name = flavour.Name
                });
            }

            return flavours;
        }

        public FlavourDTO ReadFlavour(int id)
        {
            Models.Flavour flavour = context.Flavours.Where(s=> s.Id == id).SingleOrDefault();

            return new FlavourDTO
            {
                Id = flavour.Id,
                CreatedAt = flavour.CreatedAt,
                Name = flavour.Name
            };
        }

        public FlavourDTO UpdateFlavour(FlavourDTO updatedFlavour)
        {
            Models.Flavour flavour = context.Flavours.Where(s=> s.Id == updatedFlavour.Id).FirstOrDefault();

            flavour.Id = flavour.Id;
            flavour.CreatedAt = flavour.CreatedAt;
            flavour.Name = flavour.Name;
            
            context.SaveChanges();

            return new FlavourDTO
            {
                Id = flavour.Id,
                CreatedAt = flavour.CreatedAt,
                Name = flavour.Name
            };

        }

        public FlavourDTO CreateFlavour(FlavourDTO newFlavour)
        {
            Models.Flavour flavour = new Models.Flavour{ Name = newFlavour.Name };
            
            context.Flavours.Add(flavour);

            context.SaveChanges();

            return new FlavourDTO
            {
                Id = flavour.Id,
                CreatedAt = flavour.CreatedAt,
                Name = flavour.Name
            };
        }

        public void DeleteFlavour(int id)
        {

            Models.Flavour flavour = context.Flavours.Where(s => s.Id == id).FirstOrDefault();
            context.Flavours.Remove(flavour);
            context.SaveChanges();
        } 

    }

}
