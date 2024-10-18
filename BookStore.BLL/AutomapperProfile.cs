using AutoMapper;
using BookStore.DAL.Entitites;
using BookStore.Dtos;

namespace BookStore.BLL;

public class AutomapperProfile : Profile
{
    public AutomapperProfile()
    {
        // BookDtos
        CreateMap<Book, BookDto>().ReverseMap();
        CreateMap<Book, BookListDto>().ReverseMap();
        CreateMap<Book, BookCreateDto>()
            .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.PublisherId))
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(x => x.AuthorId)))
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.GenreId)))
            .ReverseMap()
            .ForPath(dest => dest.PublisherId, opt => opt.MapFrom(src => src.Publisher))
            .ForPath(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(id => new BookAuthor { AuthorId = id })))
            .ForPath(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(id => new BookGenre { GenreId = id })))
            .ForPath(dest => dest.Publisher, opt => opt.Ignore());
        CreateMap<Book, BookUpdateDto>()
            .ForMember(dest => dest.Book, opt => opt.MapFrom(src => src))
            .ForMember(dest => dest.Publisher, opt => opt.MapFrom(src => src.PublisherId))
            .ForMember(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(x => x.AuthorId)))
            .ForMember(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(x => x.GenreId)))
            .ReverseMap()
            .ForPath(dest => dest.PublisherId, opt => opt.MapFrom(src => src.Publisher))
            .ForPath(dest => dest.Authors, opt => opt.MapFrom(src => src.Authors.Select(id => new BookAuthor { AuthorId = id })))
            .ForPath(dest => dest.Genres, opt => opt.MapFrom(src => src.Genres.Select(id => new BookGenre { GenreId = id })))
            .ForPath(dest => dest.Publisher, opt => opt.Ignore());

        // Author Dtos
        CreateMap<Author, AuthorDto>().ReverseMap();
        CreateMap<Author, AuthorListDto>().ReverseMap();
        CreateMap<Author, AuthorCreateDto>()
            .ForMember(dest => dest.Author, opt => opt.MapFrom(src => src))
            .ReverseMap();

        // Publisher Dtos
        CreateMap<Genre, GenreDto>().ReverseMap();
        CreateMap<Genre, GenreListDto>().ReverseMap();
        CreateMap<Genre, GenreCreateDto>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src))
            .ReverseMap();
        CreateMap<Genre, GenreUpdateDto>()
            .ForMember(dest => dest.Genre, opt => opt.MapFrom(src => src))
            .ReverseMap();
    }
}
