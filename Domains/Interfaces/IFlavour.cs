using api.DTOs;
using System.Collections.Generic;

namespace api.Domains.Interfaces
{
    public interface IFlavour
    {
        List<FlavourDTO> ReadFlavours();
        FlavourDTO ReadFlavour(int id);
        FlavourDTO CreateFlavour(FlavourDTO flavour);
        FlavourDTO UpdateFlavour(FlavourDTO flavour);
        void DeleteFlavour(int id);
    }
}
