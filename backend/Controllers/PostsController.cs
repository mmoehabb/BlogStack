using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BlogStack.Models;
using BlogStack.DTOs;

[ApiController]
[Route("/api/posts")]
public class PostsController : ControllerBase
{
  private readonly BloggingContext _ctx;
  private readonly Mapper _mapper;

  public PostsController(BloggingContext context) 
  {
    this._ctx = context;
    var cfg = new MapperConfiguration(cfg => cfg.CreateMap<Post, GetPostDTO>());
    this._mapper = new Mapper(cfg);
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<IActionResult> Get(int id) 
  {
    var post = await _ctx.Posts.FindAsync(id);
    return Ok(_mapper.Map<GetPostDTO>(post));
  }

  [HttpGet]
  [Route("all")]
  public IActionResult GetAll() 
  {
    var posts = _ctx.Posts.ToList();
    return Ok(_mapper.Map<List<GetPostDTO>>(posts));
  }

  [HttpGet]
  [Route("of/{username}")]
  public IActionResult GetOfWriter(string username) 
  {
    var posts = _ctx.Posts.Where(p => p.Writer.Username == username);
    return Ok(_mapper.Map<List<GetPostDTO>>(posts));
  }

  [HttpGet]
  [Route("{index}/{limit}")]
  public IActionResult GetLimit(int index, int limit) 
  {
    if (index < 0 || limit > 20) {
      return BadRequest("index should be at least 0, and limit at most 20.");
    }
    var posts = _ctx.Posts.Skip(index).Take(limit);
    return Ok(_mapper.Map<List<GetPostDTO>>(posts));
  }

  [HttpPost]
  [Route("add")]
  public async Task<IActionResult> Add(AddPostDTO dto) 
  {
    var writer = await _ctx.Writers.FindAsync(dto.Writer.Username);
    if (writer == null || !writer.AccessToken.Equals(dto.Writer.AccessToken)) {
      return Unauthorized();
    }
    var newPost = new Post {
      Writer = writer,
      Title = dto.Title,
      Content = dto.Content
    };
    var errors = PostValidator.Validate(newPost);
    if (errors.Any()) {
      return BadRequest(errors);
    }
    await _ctx.Posts.AddAsync(newPost);
    _ctx.SaveChanges();
    return Ok();
  }

  [HttpDelete]
  [Route("delete")]
  public async Task<IActionResult> Remove(RmvPostDTO dto) 
  {
    var writer = await _ctx.Writers.FindAsync(dto.Writer.Username);
    if (writer == null || !writer.AccessToken.Equals(dto.Writer.AccessToken)) {
      return Unauthorized();
    }
    var post = await _ctx.Posts.FindAsync(dto.Id);
    if (post == null) {
      return NotFound();
    }
    _ctx.Posts.Remove(post);
    await _ctx.SaveChangesAsync();
    return Ok();
  }
}
