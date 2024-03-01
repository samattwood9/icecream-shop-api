using System.Collections.Generic;
using api.DTOs;

namespace api.Domains.Interfaces
{
    public interface ITopping
    {
        List<ToppingDTO> ReadToppings();
        ToppingDTO ReadTopping(int id);
        ToppingDTO CreateTopping(ToppingDTO newTopping);
        ToppingDTO UpdateTopping(ToppingDTO updatedTopping);
        void DeleteTopping(int id);
    }
}
