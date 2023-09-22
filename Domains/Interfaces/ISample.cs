using api.DTOs;
using System.Collections.Generic;

namespace api.Domains.Interfaces
{
    public interface ISample
    {
        List<SampleDTO> ReadItems();
        SampleDTO ReadItem(string id);
        SampleDTO AddItem(SampleDTO item);
        SampleDTO EditItem(SampleDTO item);
        void DeleteItem(string id);
    }
}
