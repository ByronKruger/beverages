using AutoMapper;
using Coffeeg.Dtos;
using Coffeeg.Dtos.BeverageCustomisation;
using Coffeeg.Dtos.User;
using Coffeeg.Entities;

namespace Coffeeg.Helpers.AutoMapperProfiles
{
    public class BeverageCustomisationProfiles : Profile
    {
        public BeverageCustomisationProfiles()
        {
            CreateMap<BeverageCustomisation, UserBeverageCustomisationResult>()
                .ForMember(dest => dest.IngredientAmounts,
                    opt => opt.MapFrom(src => src.IngredientAmounts))
                .ForMember(dest => dest.ComplexIngredientAmounts,
                    opt => opt.MapFrom(src => src.ComplexIngredientAmounts));

            CreateMap<BeverageType, BeverageTypeDto>()
                // Explicitly map only the ingredients we loaded
                .ForMember(dest => dest.Ingredients,
                    opt => opt.MapFrom(src => src.Ingredients));

            CreateMap<Ingredient, IngredientDto>()
                .ForMember(dest => dest.ComplexIngredients,
                    opt => opt.MapFrom(src => src.ComplexIngredients));
            //.ForMember(dest => dest.IngredientAmounts,
            //opt => opt.MapFrom(src => src.IngredientAmounts));

            CreateMap<User, UserDto>();

            CreateMap<ComplexIngredient, ComplexIngredientDto>();

            CreateMap<Entities.IngredientAmount, IngredientAmountDto>();

            CreateMap<Entities.ComplexIngredientAmount, ComplexIngredientAmountDto>();

            //CreateMap<CreateCustomisationResult, BeverageCustomisaton>()
            //    .ForPath(dest => dest.BeverageType.Descr,
            //        opt => opt.MapFrom(src => src.Descr));
            //    //.ForMember(dest => dest.BeverageType.Descr,
            //    //    opt => opt.MapFrom(src => src.Descr));

            CreateMap<CreateBeverageCustomisation, BeverageCustomisation>();
            //.ForMember(dest => dest.BeverageType.Descr,
            //    opt => opt.MapFrom(src => src.desc)

            CreateMap<Dtos.IngredientAmount, Entities.IngredientAmount>();
            CreateMap<Dtos.ComplexIngredientAmount, Entities.ComplexIngredientAmount>();

            CreateMap<BeverageCustomisation, CreateCustomisationResult>()
                .ForMember(dest => dest.Id,
                    opt => opt.MapFrom(src => src.BeverageType.Id));

            CreateMap<BeverageCustomisation, CreateCustomisationResult>()
                .ForCtorParam(nameof(CreateCustomisationResult.Id),               // must match parameter name exactly
                    opt => opt.MapFrom(src => src.BeverageType.Id))


                .ForCtorParam(nameof(CreateCustomisationResult.ComplexIngredientAmounts),
                    opt => opt.MapFrom(src => src.ComplexIngredientAmounts
                        .Select(cia => new CreateCustomisationComplexIngredient(
                            //cia.ComplexIngredient.Descr,   // assuming it has Descr
                            cia.ComplexIngredientId,
                            cia.Amount))
                        .ToList()))

                .ForCtorParam(nameof(CreateCustomisationResult.IngredientAmounts),
                        opt => opt.MapFrom(src => src.IngredientAmounts
                            .Select(cia => new CreateCustomisationIngredient(
                                //cia.ComplexIngredient.Descr,   // assuming it has Descr
                                cia.IngredientId,
                                cia.Amount))
                            .ToList()));

            CreateMap<UpdateBeverageCustomisation, BeverageCustomisation>()
    // No .ForCtorParam or .ConstructUsing needed
    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
    // The collections will be mapped automatically if you have maps for IngredientAmount / ComplexIngredientAmount
    // But to be explicit / safe:
    //.ForMember(dest => dest.IngredientAmounts, opt => opt.MapFrom(src =>
        //src.IngredientAmounts.Select(i => new Entities.IngredientAmount { Id = i.Id, Amount = i.Amount, BeverageCustomisationId = i.BeverageCustomisationId, IngredientId = i.IngredientId }).ToList()))
    .ForMember(dest => dest.ComplexIngredientAmounts, opt => opt.MapFrom(src =>
        src.ComplexIngredientAmounts.Select(i => new Entities.ComplexIngredientAmount { Id = i.Id, Amount = i.Amount, BeverageCustomisationId = i.BeverageCustomisationId, ComplexIngredientId = i.ComplexIngredientId }).ToList()));
    // Ignore navigation properties that shouldn't be overwritten
    //.ForMember(dest => dest.User, opt => opt.Ignore())
    //.ForMember(dest => dest.BeverageType, opt => opt.Ignore())
    //.ForMember(dest => dest.UserId, opt => opt.Ignore());
    //.ForMember(dest => dest.BeverageTypeId, opt => opt.Ignore());

            CreateMap<BeverageCustomisation, UserBeverageCustomisationResult>();
            //.DisableCtorValidation();


            //.ForCtorParam(nameof(UpdateBeverageCustomisation.ComplexIngredientAmounts));


            CreateMap<BeverageType, GetBeverageType>()
                .ForMember(dest => dest.Ingredients, opt => opt.MapFrom(src => src.Ingredients))
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descr, opt => opt.MapFrom(src => src.Descr));
            CreateMap<GetBeverageType, BeverageType>();

            CreateMap<Ingredient, GetIngredient>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descr, opt => opt.MapFrom(src => src.Descr))
                .ForMember(dest => dest.ComplexIngredients, opt => opt.MapFrom(src => src.ComplexIngredients));
            CreateMap<GetIngredient, Ingredient>();

            CreateMap<ComplexIngredient, GetComplexIngredient>()
                .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                .ForMember(dest => dest.Descr, opt => opt.MapFrom(src => src.Descr));
            CreateMap<GetComplexIngredient, ComplexIngredient>();

            CreateMap<User, SearchUserResult>();

        }
    }
}
