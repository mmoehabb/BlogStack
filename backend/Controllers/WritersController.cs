using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using BlogStack.Models;
using BlogStack.DTOs;

[ApiController]
[Route("/api/writers")]
public class WritersController : ControllerBase
{
  private readonly BloggingContext _ctx;
  private readonly IMapper _mapper;

  public WritersController(BloggingContext context) 
  {
    this._ctx = context;
    var cfg = new MapperConfiguration(cfg => cfg.CreateMap<Writer, GetWriterDTO>());
    this._mapper = new Mapper(cfg);
  }

  [HttpGet]
  [Route("{username}")]
  public async Task<IActionResult> Get(string username) 
  {
    var writer = await _ctx.Writers.FindAsync(username);
    if (writer == null) {
      return NotFound();
    }
    return Ok(_mapper.Map<GetWriterDTO>(writer));
  }

  [HttpGet]
  [Route("all")]
  public IActionResult GetAll() 
  {
    var writers = _ctx.Writers.ToList();
    var config = new MapperConfiguration(cfg => cfg.CreateMap<Writer, GetWriterDTO>());
    return Ok(_mapper.Map<List<GetWriterDTO>>(writers));
  }

  [HttpPost]
  [Route("auth")]
  public async Task<IActionResult> Auth(AuthWriterDTO w) 
  {
    var writer = await _ctx.Writers.FindAsync(w.Username);
    if (writer == null) {
      return NotFound();
    }
    var db_token = writer.AccessToken;
    if (!db_token.Equals(w.AccessToken)) {
      return Unauthorized();
    }
    return Ok();
  }

  [HttpPost]
  [Route("login")]
  public async Task<IActionResult> login(LoginWriterDTO w) 
  {
    var writer = await _ctx.Writers.FindAsync(w.Username);
    if (writer == null) {
      return NotFound();
    }
    var db_password = writer.Password;
    if (!db_password.Equals(Hasher.HmacSHA256(w.Password))) {
      return Unauthorized();
    }
    writer.AccessToken = Hasher.GenRandomAccessToken();
    _ctx.Writers.Update(writer);
    _ctx.SaveChanges();
    return Ok(writer.AccessToken);
  }

  [HttpPost]
  [Route("register")]
  public async Task<IActionResult> Add(AddWriterDTO dto) 
  {
    var w = new Writer {
      Username = dto.Username,
      Password = Hasher.HmacSHA256(dto.Password),
      DisplayName = dto.DisplayName,
      AccessToken = Hasher.GenRandomAccessToken()
    };
    var errors = WriterValidator.Validate(w);
    if (errors.Any()) {
      return BadRequest(errors);
    }
    await _ctx.Writers.AddAsync(w);
    _ctx.SaveChanges();
    return Ok();
  }

  [HttpDelete]
  [Route("delete")]
  public async Task<IActionResult> Remove(AuthWriterDTO dto) 
  {
    var writer = await _ctx.Writers.FindAsync(dto.Username);
    if (writer == null) {
      return NotFound();
    }
    var db_token = writer.AccessToken;
    if (!db_token.Equals(dto.AccessToken)) {
      return Unauthorized();
    }
    _ctx.Writers.Remove(writer);
    _ctx.SaveChanges();
    return Ok();
  }
}
