using AutoMapper;
using BookStore.Domain.Models;
using BookStore1.API.DTOs.Book;
using BookStore1.API.DTOs.Category;

namespace BookStore1.API.Configurations
{
    public class AutoMapperConfig: Profile
    {
        public AutoMapperConfig() {
            CreateMap<Category, CategoryAddDtos>().ReverseMap();
            CreateMap<Category, CategoryEditDtos>().ReverseMap();
            CreateMap<Category, CategoryResultDtos>().ReverseMap();
            CreateMap<Book, BookAddDtos>().ReverseMap();
            CreateMap<Book, BookEditDtos>().ReverseMap();
            CreateMap<Book, BookResultDtos>().ReverseMap();
        }
    }
}
