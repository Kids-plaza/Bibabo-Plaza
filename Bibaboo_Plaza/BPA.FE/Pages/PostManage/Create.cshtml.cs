using BPA.BusinessObject.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BPA.FE.Pages.PostManage
{
    public class CreateModel : PageModel
    {
        [BindProperty]
        public Post Post { get; set; } = default!;

        public async Task<IActionResult> OnPostAsync()
        {
            Post.id = Guid.NewGuid();
            Post.created_on = DateTime.Now;
            Post.staff_id = Guid.Parse("58834E90-493E-44B7-BF8D-8CE0DCAD0662");
            var updateURL = $"{Common.BaseURL}/api/Posts/Create";
            var response = await Common.SendRequestWithBody(Post, updateURL, HttpContext.Session.GetString("accessToken"), "Post");
            return RedirectToPage("./Index");
        }
    }
}
