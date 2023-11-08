using AutoMapper;
using BusinessModel.Requests;
using Repository.Entity;

namespace Repository
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            ClassMapping();
        }

        private void ClassMapping()
        {
            CreateMap<OrderEntity, OrderModel>();
            CreateMap<OrderModel, OrderEntity>();
        }
    }
}