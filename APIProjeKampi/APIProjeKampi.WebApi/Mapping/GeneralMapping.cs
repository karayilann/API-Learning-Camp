using APIProjeKampi.WebApi.Dtos.FeatureDtos;
using APIProjeKampi.WebApi.Dtos.MessageDtos;
using APIProjeKampi.WebApi.Dtos.ProductDtos;
using APIProjeKampi.WebApi.Entities;
using AutoMapper;

namespace APIProjeKampi.WebApi.Mapping
{
    public class GeneralMapping: Profile
    {




        /*
            Sık kullanılan AutoMapper fonksiyonları ve işlevleri

           
        1. CreateMap\<TSource, TDestination>() :
                Bu fonksiyon, bir kaynak nesne (TSource) ile hedef nesne (TDestination) arasında bir haritalama (mapping) oluşturur.

           var config = new MapperConfiguration(cfg => cfg.CreateMap<User, UserDto>());
           Bu sayede `User` nesnesi `UserDto` nesnesine dönüştürülebilir.
          
        ----------------------------------------------------------------------------------------------------------

        2. ForMember(destinationMember, opt => opt.MapFrom(sourceMember))
           
           Belirli bir hedef nesne özelliğine özel bir eşleme yapmak için kullanılır.

           cfg.CreateMap<User, UserDto>().ForMember(dest => dest.FullName, opt => opt.MapFrom(src => src.FirstName + " " + src.LastName));

           Bu kullanım, `FullName` özelliğini `FirstName` ve `LastName` alanlarının birleşimi olarak belirler.
          
        ----------------------------------------------------------------------------------------------------------------------------- 
        
        3. ReverseMap()
           
           Kaynak nesne ile hedef nesne arasındaki dönüşümü çift yönlü yapmak için kullanılır.
           
           cfg.CreateMap<User, UserDto>().ReverseMap();
           
           Böylece hem `User` → `UserDto` hem de `UserDto` → `User` dönüşümü yapılabilir.

         -----------------------------------------------------------------------------------------------------------------------

        4. Ignore()
           
           Belirli bir özelliği eşlemeye dahil etmemek için kullanılır.
           
           cfg.CreateMap<User, UserDto>().ForMember(dest => dest.Password, opt => opt.Ignore());
           
           Bu, `Password` özelliğinin eşlenmemesini sağlar.

        ----------------------------------------------------------------------------------------------------------------------------
           
        5. ConstructUsing()
           
           Hedef nesnenin belirli bir mantık ile oluşturulmasını sağlamak için kullanılır.

           cfg.CreateMap<Order, OrderDto>().ConstructUsing(src => new OrderDto { Id = src.OrderId, CreatedDate = DateTime.UtcNow });

           Burada `OrderDto` nesnesi `OrderId` ve şimdiki zaman bilgisiyle oluşturuluyor.
           
        -----------------------------------------------------------------------------------------------------------------------------

        6. ConvertUsing()
           
           Özel bir dönüşüm mantığı tanımlamak için kullanılır.

           cfg.CreateMap<DateTime, string>().ConvertUsing(date => date.ToString("yyyy-MM-dd"));
           
           Bu sayede `DateTime` nesneleri string formatına dönüştürülmüş olur.

        -------------------------------------------------------------------------------------------------------------------------
           
         7. AfterMap()
           
           Eşleme işlemi tamamlandıktan sonra belirli işlemleri yapmak için kullanılır.

           cfg.CreateMap<User, UserDto>().AfterMap((src, dest) => dest.LastUpdated = DateTime.UtcNow);

           Bu sayede `UserDto` nesnesinin `LastUpdated` alanı eşleme sonrası güncellenir.

         */

        public GeneralMapping()
        {
            CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            CreateMap<Feature, UpdateResultFeatureDto>().ReverseMap();

            CreateMap<Message, ResultMessageDto>().ReverseMap();
            CreateMap<Message, CreateMessageDto>().ReverseMap();
            CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            CreateMap<Message, UpdateMessageDto>().ReverseMap();

            CreateMap<Product, CreateProductDto>().ReverseMap();

            //var config = new MapperConfiguration(cfg =>
            //{
            //    cfg.CreateMap<Feature, ResultFeatureDto>().ReverseMap();
            //    cfg.CreateMap<Feature, CreateFeatureDto>().ReverseMap();
            //    cfg.CreateMap<Feature, GetByIdFeatureDto>().ReverseMap();
            //    cfg.CreateMap<Feature, UpdateResultFeatureDto>().ReverseMap();

            //    cfg.CreateMap<Message, ResultMessageDto>().ReverseMap();
            //    cfg.CreateMap<Message, CreateMessageDto>().ReverseMap();
            //    cfg.CreateMap<Message, GetByIdMessageDto>().ReverseMap();
            //    cfg.CreateMap<Message, UpdateMessageDto>().ReverseMap();
            //});

        }

    }
}
