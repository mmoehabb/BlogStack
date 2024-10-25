using Microsoft.AspNetCore.Mvc;
using BlogStack.Models;
using BlogStack.DTOs;

[ApiController]
[Route("/api/bookmarks")]
public class BookmarksController : ControllerBase
{
  private readonly BloggingContext _ctx;

  public BookmarksController(BloggingContext context) 
  {
    this._ctx = context;
  }

  [HttpGet]
  [Route("{id}")]
  public IActionResult Get(int id) 
  {
    var query = 
      from b in _ctx.Bookmarks 
      join p in _ctx.Posts on b.PostId equals p.Id
      where b.Id == id
      select new GetBookmarkDTO { Id = id, PostTitle = p.Title };
    return Ok(query.First());
  }

  [HttpGet]
  [Route("of/{username}")]
  public IActionResult GetOfWriter(string username) 
  {
    var query = 
      from b in _ctx.Bookmarks
      join p in _ctx.Posts on b.PostId equals p.Id
      where b.WriterUsername == username
      select new GetBookmarkDTO { Id = b.Id, PostTitle = p.Title };
    return Ok(query.ToList());
  }

  [HttpPost]
  [Route("add")]
  public async Task<IActionResult> Add(AddBookmarkDTO dto) 
  {
    var writer = await _ctx.Writers.FindAsync(dto.Writer.Username);
    if (writer == null || !writer.Password.Equals(Hasher.HmacSHA256(dto.Writer.Password))) {
      return Unauthorized();
    }
    var post = await _ctx.Posts.FindAsync(dto.PostId);
    if (post == null) {
      return NotFound();
    }

    IEnumerable<Bookmark> bookmarkQuery =
    from b in _ctx.Bookmarks
    where b.WriterUsername == writer.Username &&
    b.PostId == post.Id
    select b;

    if (bookmarkQuery.Any()) {
      return Conflict();
    }

    var newBookmark = new Bookmark {
      Writer = writer,
      Post = post
    };
    await _ctx.Bookmarks.AddAsync(newBookmark);
    _ctx.SaveChanges();
    return Ok();
  }

  [HttpDelete]
  [Route("delete")]
  public async Task<IActionResult> Remove(RmvBookmarkDTO dto) 
  {
    var writer = await _ctx.Writers.FindAsync(dto.Writer.Username);
    if (writer == null || !writer.Password.Equals(Hasher.HmacSHA256(dto.Writer.Password))) {
      return Unauthorized();
    }
    var b = await _ctx.Bookmarks.FindAsync(dto.Id);
    if (b == null) {
      return NotFound();
    }
    _ctx.Bookmarks.Remove(b);
    await _ctx.SaveChangesAsync();
    return Ok();
  }
}
