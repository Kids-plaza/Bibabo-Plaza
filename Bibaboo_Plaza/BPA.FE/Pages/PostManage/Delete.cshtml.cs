using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace BPA.FE.Pages.PostManage
{
    public class DeleteModel : PageModel
    {

        [BindProperty]
        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            //var role = HttpContext.Session.GetString("role");
            //if (role != "1" && role != "2") return Forbid();

            var getURL = $"{Common.BaseURL}/api/Posts/GetById?id={id}";
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

        public async Task<IActionResult> OnPostAsync(string id)
        {
            var deleteURL = $"{Common.BaseURL}/api/Posts/Delete/{Post.id}";
            await Common.SendRequestWithBody<object>(null, deleteURL, HttpContext.Session.GetString("accessToken"), "Delete");
            return RedirectToPage("./Index");
        }
    }
}
