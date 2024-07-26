using AutoMapper;
using System.Reflection;

namespace CarRental.Application.Mappers;

public class MapperConfiguration : Profile
{

    public MapperConfiguration()
    {
        var mappers = GetStandartMaps();

        foreach (var item in mappers)
        {
            CreateMap(item.Source, item.Destination).ReverseMap();
        }
    }
    private static IEnumerable<MapModel> GetStandartMaps()
    {
        var types = Assembly.GetExecutingAssembly().GetTypes();

        return types
            .SelectMany(type => type.GetInterfaces()
                .Where(i => i.IsGenericType && i.GetGenericTypeDefinition() == typeof(IMapTo<>))
                .Select(i => new MapModel
                {
                    Source = type,
                    Destination = i.GenericTypeArguments[0]
                }))
            .ToList();
}
}
