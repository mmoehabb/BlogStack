using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BlogStack.Models;
using BlogStack.DTOs;

[ApiController]
[Route("/api/posts")]
public class PostsController : ControllerBase
{
  private readonly BloggingContext _ctx;

  public PostsController(BloggingContext context) 
  {
    this._ctx = context;
  }

  [HttpGet]
  [Route("{id}")]
  public async Task<IActionResult> Get(int id) 
  {
    var post = await _ctx.Posts.FindAsync(id);
    var config = new MapperConfiguration(cfg => cfg.CreateMap<Post, GetPostDTO>());
    var dto = (new Mapper(config)).Map<GetPostDTO>(post);
    return Ok(dto);
  }

  [HttpGet]
  [Route("all")]
  public IActionResult GetAll() 
  {
    var posts = _ctx.Posts.ToList();
    var config = new MapperConfiguration(cfg => cfg.CreateMap<Post[], GetPostDTO[]>());
    var dto = (new Mapper(config)).Map<GetPostDTO[]>(posts);
    return Ok(dto);
  }

  [HttpGet]
  [Route("of/{username}")]
  public IActionResult GetOfWriter(string username) 
  {
    var posts = _ctx.Posts.Where(p => p.Writer.Username == username);
    var config = new MapperConfiguration(cfg => cfg.CreateMap<Post[], GetPostDTO[]>());
    var dto = (new Mapper(config)).Map<GetPostDTO[]>(posts);
    return Ok(dto);
  }

  [HttpGet]
  [Route("{index}/{limit}")]
  public IActionResult GetOfWriter(int index, int limit) 
  {
    if (index < 0 || limit > 20) {
      return BadRequest("index should be at least 0, and limit at most 20.");
    }
    var posts = _ctx.Posts.Skip(index).Take(limit);
    var config = new MapperConfiguration(cfg => cfg.CreateMap<Post[], GetPostDTO[]>());
    var dto = (new Mapper(config)).Map<GetPostDTO[]>(posts);
    return Ok(dto);
  }

  [HttpPost]
  [Route("add")]
  public async Task<IActionResult> Add(AddPostDTO dto) 
  {
    var writer = await _ctx.Writers.FindAsync(dto.Writer.Username);
    if (writer == null || !writer.Password.Equals(Hasher.HmacSHA256(dto.Writer.Password))) {
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
  [Route("delete/{id}")]
  public async Task<IActionResult> Remove(RmvPostDTO dto) 
  {
    var writer = await _ctx.Writers.FindAsync(dto.Writer.Username);
    if (writer == null || !writer.Password.Equals(Hasher.HmacSHA256(dto.Writer.Password))) {
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
