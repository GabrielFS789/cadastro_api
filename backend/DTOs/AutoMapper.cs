using AutoMapper;
using backend.Model;

namespace backend.DTOs
{
    public class AutoMapper : Profile
    {
        public AutoMapper()
        {
            CreateMap<EntidadeDTO, Entidade>().ReverseMap();
        }
    }
}
