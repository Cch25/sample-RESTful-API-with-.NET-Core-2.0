using System.Linq;
using AutoMapper;
using MoviesRESTfulAPI.Dtos;
using MoviesRESTfulAPI.Models;

namespace MoviesRESTfulAPI.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            //Domain to DTO
            CreateMap<Movies, MoviesDto>()
                .ForMember(ma => ma.Actors, opt => opt.MapFrom(m => m.Actors.Select(mm => mm.Actors.Id).ToList()));


            //DTO to domain
            CreateMap<MoviesDto, Movies>()
                .ForMember(m => m.Actors, opt => opt.Ignore())
                .AfterMap((md, m) =>
                {
                    //remove Actor bug here! - fixed => ToList in order to modify the collection.
                    var removeActors = m.Actors.Where(mm => !md.Actors.Contains(mm.ActorsId)).ToList();
                    foreach (var actor in removeActors)
                        m.Actors.Remove(actor);

                    // Add Actor
                    var addActor = md.Actors.Where(id => m.Actors.All(a => a.ActorsId!= id)).Select(id => new MovieActors() { ActorsId= id });
                    foreach (var actor in addActor)
                        m.Actors.Add(actor);
                });
        }
    }
}
