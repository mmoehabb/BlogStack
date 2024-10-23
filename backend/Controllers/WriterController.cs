using Microsoft.AspNetCore.Mvc;
using BlogStack.Models;

[ApiController]
[Route("/api/writers")]
public class WriterController : ControllerBase
{
  private readonly BloggingContext _ctx;

  public WriterController(BloggingContext context) 
  {
    this._ctx = context;
  }

  [HttpGet]
  [Route("{username}")]
  public async Task<IActionResult> Get(string username) 
  {
    var writer = await _ctx.Writers.FindAsync(username);
    return Ok(writer);
  }

  [HttpGet]
  [Route("all")]
  public IActionResult GetAll() 
  {
    var writers = _ctx.Writers.ToList();
    return Ok(writers);
  }

  [HttpPost]
  [Route("auth")]
  public async Task<IActionResult> Auth(Writer w) 
  {
    var writer = await _ctx.Writers.FindAsync(w.Username);
    if (writer == null) {
      return NotFound();
    }
    var db_password = writer.Password;
    if (db_password.Equals(Hasher.HmacSHA256(w.Password))) {
      return Ok();
    }
    return Unauthorized();
  }

  [HttpPost]
  [Route("register")]
  public async Task<IActionResult> Add(Writer w) 
  {
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
  public async Task<IActionResult> Remove(Writer w) 
  {
    _ctx.Writers.Remove(w);
    await _ctx.SaveChangesAsync();
    return Ok();
  }
}
