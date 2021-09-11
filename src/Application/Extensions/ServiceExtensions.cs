using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;
using AutoMapper;
using PE.Application.Interfaces;
using PE.Application.Behaviour;
using PE.Domain.Promotions.Engine;
using PE.Application.Features.Promotion.Engine;

namespace PE.Application.Extensions
{
    public static class ServiceExtensions
    {
        public static void AddApplicationLayer(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddTransient<IPromotionBehaviour, CartBehaviour>();
            services.AddTransient<IPromotionEngine, PromotionEngine>();

        }
    }
}
