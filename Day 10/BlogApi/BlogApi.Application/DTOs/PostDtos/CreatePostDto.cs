﻿
namespace BlogApi.Application.DTOs.PostDtos;

public class CreatePostDto 
{
    public string Title { get; set; } = null!;
    public string Content { get; set; } = null!;
}