using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BlogStack.Models;
using BlogStack.DTOs;

[ApiController]
[Route("/api/writers")]
public class WritersController : ControllerBase
{
  private readonly BloggingContext _ctx;

  public WritersController(BloggingContext context) 
  {
    this._ctx = context;
  }

  [HttpGet]
  [Route("{username}")]
  public async Task<IActionResult> Get(string username) 
  {
    var writer = await _ctx.Writers.FindAsync(username);
    if (writer == null) {
      return NotFound();
    }
    var config = new MapperConfiguration(cfg => cfg.CreateMap<Writer, GetWriterDTO>());
    var dto = (new Mapper(config)).Map<GetWriterDTO>(writer);
    return Ok(dto);
  }

  [HttpGet]
  [Route("all")]
  public IActionResult GetAll() 
  {
    var writers = _ctx.Writers.ToList();
    var config = new MapperConfiguration(cfg => cfg.CreateMap<List<Writer>, List<GetWriterDTO>>());
    var dto = (new Mapper(config)).Map<List<GetWriterDTO>>(writers);
    return Ok(dto);
  }

  [HttpPost]
  [Route("auth")]
  public async Task<IActionResult> Auth(AuthWriterDTO w) 
  {
    var writer = await _ctx.Writers.FindAsync(w.Username);
    if (writer == null) {
      return NotFound();
    }
    var db_password = writer.Password;
    if (!db_password.Equals(Hasher.HmacSHA256(w.Password))) {
      return Unauthorized();
    }
    return Ok();
  }

  [HttpPost]
  [Route("register")]
  public async Task<IActionResult> Add(AddWriterDTO dto) 
  {
    var w = new Writer {
      Username = dto.Username,
      Password = dto.Password,
      DisplayName = "",
    };
    var errors = WriterValidator.Validate(w);
    if (errors.Any()) {
      return BadRequest(errors);
    }
    w.Password = Hasher.HmacSHA256(w.Password);
    await _ctx.Writers.AddAsync(w);
    _ctx.SaveChanges();
    return Ok();
  }

  [HttpDelete]
  [Route("delete")]
  public async Task<IActionResult> Remove(AuthWriterDTO dto) 
  {
    var w = new Writer {
      Username = dto.Username,
      Password = dto.Password,
      DisplayName = "",
    };
    var writer = await _ctx.Writers.FindAsync(w.Username);
    if (writer == null) {
      return NotFound();
    }
    var db_password = writer.Password;
    if (!db_password.Equals(Hasher.HmacSHA256(w.Password))) {
      return Unauthorized();
    }
    _ctx.Writers.Remove(w);
    await _ctx.SaveChangesAsync();
    return Ok();
  }
}
