namespace MemberService.Controllers;

[ApiController]
[Route("[controller]")]
public class VersionController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        return Ok(Assembly.GetExecutingAssembly().GetName().Version);
    }
}