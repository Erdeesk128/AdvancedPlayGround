using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace TestPlayGround.Pages
{
    public class IndexModel : PageModel
    {
        public string? MyCustomHeaderValue {  get; set; }
        public void OnGet()
        {
            MyCustomHeaderValue = HttpContext.Response.Headers["My-Custom-Header"];
        }
    }
}
