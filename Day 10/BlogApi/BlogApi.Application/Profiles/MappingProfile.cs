using AutoMapper;
using BlogApi.Application.DTOs.CommentDtos;
using BlogApi.Application.DTOs.PostDtos;
using BlogApi.Domain;

namespace BlogApi.Application.Profiles;

public class MappingProfile : Profile 
{
    public MappingProfile()
    {
        // Comment Mappers 
        CreateMap<Comment, CreateCommentDto>().ReverseMap();
        CreateMap<Comment, CommentDto>().ReverseMap();
        CreateMap<Comment, CommentListDto>().ReverseMap();
        CreateMap<Comment, UpdateCommentDto>().ReverseMap();
        
        // Post Mappers
        CreateMap<Post, PostListDto>().ReverseMap();
        CreateMap<Post, CreatePostDto>().ReverseMap();
        CreateMap<Post, PostDto>().ReverseMap();
        CreateMap<Post, UpdatePostDto>().ReverseMap();
    }
}