using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Test.Models;

namespace BPA.FE.Pages.PostManage
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(string id)
        {
            //var role = HttpContext.Session.GetString("Role");
            //if (role != "1") return Forbid();
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

            //var getClub = $"{Common.BaseURL}/api/FootballClub";
            //var clubs = await (await Common.SendGetRequest(getClub, HttpContext.Session.GetString("accessToken"))).Content.ReadFromJsonAsync<List<FootballClub>>();

            //ViewData["PostID"] = new SelectList(clubs, "FootballClubID", "ClubName");

        }

        public async Task<Account> getAccountAsync(Guid Id)
        {
            var getAccountUrl = $"{Common.BaseURL}/api/Accounts/GetById?id={Id}";
            var response = await Common.SendGetRequest(getAccountUrl, HttpContext.Session.GetString("accessToken"));
            var resJson = await response.Content.ReadAsStringAsync();

            return JsonSerializer.Deserialize<Account>(resJson);
        }

        public async Task<IActionResult> OnPostAsync()
        {
            var updateURL = $"{Common.BaseURL}/api/Posts/Update/{Post.id}";
            var response = await Common.SendRequestWithBody(Post, updateURL, HttpContext.Session.GetString("accessToken"), "Put");
            return RedirectToPage("./Index");
        }
    }
}
