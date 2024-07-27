using System.Text.Json;
using System.Text.Json.Nodes;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Test.Models;

namespace BPA.FE.Pages.PostManage
{
    public class IndexModel : PageModel
    {

        public IList<Post> Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync()
        {
            //var role = HttpContext.Session.GetString("role");
            //if (role != "1" && role != "2") return Forbid();

            var getURL = $"{Common.BaseURL}/api/Posts/GetAll";
            var response = await Common.SendGetRequest(getURL, HttpContext.Session.GetString("accessToken"));
            var resJson = JsonNode.Parse(await response.Content.ReadAsStringAsync());
            Post = JsonSerializer.Deserialize<List<Post>>(resJson) ?? new List<Post>();
            return Page();
        }
    }
}
