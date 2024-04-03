using CleanArchitecture.Application.Behaviors;
using CleanArchitecture.Application.Mapper;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace CleanArchitecture.Application.DependencyInjection.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddConfigureMediatR(this IServiceCollection services)
            => services.AddMediatR(cgf => cgf.RegisterServicesFromAssembly(AssemblyReference.Assembly))
                       .AddScoped(typeof(IPipelineBehavior<,>), typeof(ValidationPipelineBehavior<,>))
                       .AddValidatorsFromAssembly(Contract.AssemblyReference.Assembly, includeInternalTypes: true);
        public static IServiceCollection AddConfigurationAutoMapper(this IServiceCollection services)
            => services.AddAutoMapper(typeof(ServiceProfile));
    }
    
}
