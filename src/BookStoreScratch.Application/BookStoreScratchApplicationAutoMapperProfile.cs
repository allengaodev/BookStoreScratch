using AutoMapper;
using BookStoreScratch.Books;

namespace BookStoreScratch;

public class BookStoreScratchApplicationAutoMapperProfile : Profile
{
    public BookStoreScratchApplicationAutoMapperProfile()
    {
        CreateMap<Book, BookDto>();
        CreateMap<CreateUpdateBookDto, Book>();
    }
}