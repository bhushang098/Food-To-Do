using FoodToDo.Core;
using FoodToDo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodToDo.Pages.Restorants
{
    public class DetaillsModel : PageModel
    {
        [TempData]
        public String Message { get;set; }
        public Restorant Restorant { get; set; }
        public IRestorantData RestorantData { get; }

        public DetaillsModel(IRestorantData restorantData)
        {
            RestorantData = restorantData;
        }

        public IActionResult OnGet(int restorantID)
        {
            Restorant = RestorantData.getRestorantById(restorantID);

            if (Restorant == null)
            {
                return RedirectToPage("/Restorants/NotFound");
            }
            else
            {
                return Page();
            }
         

        }
    }
}
