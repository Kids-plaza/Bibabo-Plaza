using System.Text.Json;
using System.Text.Json.Nodes;
using BPA.BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BPA.FE.Pages.PostManage
{
    public class DetailsModel : PageModel
    {
        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(Guid? Id)
        {
            //var role = HttpContext.Session.GetString("role");
            //if (role != "1" && role != "2") return Forbid();

            var getURL = $"{Common.BaseURL}/api/Posts/GetById?id={Id}";
            var response = await Common.SendGetRequest(getURL, HttpContext.Session.GetString("accessToken"));
            var resJson = JsonNode.Parse(await response.Content.ReadAsStringAsync());
            try
            {
                Post = JsonSerializer.Deserialize<Post>(resJson["value"]) ?? new Post();
                Account account = await getAccountAsync(Post.staff_id);
                Post.staff = account;
                return Page();
            }
            catch (Exception ex)
            {
                return Page();
            }
        }

        public async Task<Account> getAccountAsync(Guid Id)
        {
            var getAccountUrl = $"{Common.BaseURL}/api/Accounts/GetById?id={Id}";
            var response = await Common.SendGetRequest(getAccountUrl, HttpContext.Session.GetString("accessToken"));
            var resJson = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Account>(resJson);
        }
    }
}
