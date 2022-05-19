using FoodToDo.Core;
using FoodToDo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodToDo.Pages.Restorants
{
    public class DeleteModel : PageModel
    {
        private readonly IRestorantData restorantData;

        public Restorant restorat { get; set; }
        public DeleteModel(IRestorantData restorantData)
        {
            this.restorantData = restorantData;
        }

        public IActionResult OnGet(int restorantId)
        {
            restorat = restorantData.getRestorantById(restorantId);
            return Page();
        }

        public IActionResult OnPost(int restorantId)
        {
            restorat = restorantData.delete(restorantId);
            restorantData.commit();
            return RedirectToPage("./List");
        }
    }
}
