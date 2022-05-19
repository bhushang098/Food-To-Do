using FoodToDo.Core;
using FoodToDo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace FoodToDo.Pages.Restorants
{
    public class EditModel : PageModel
    {
        [BindProperty]
        public Restorant restorant { get; set; }

        public IEnumerable<SelectListItem> cuisines { get; set; }

        public IRestorantData RestorantData { get; }
        public IHtmlHelper HtmlHelper { get; }


        public EditModel(IRestorantData restorantData, IHtmlHelper htmlHelper)
        {
            RestorantData = restorantData;
            HtmlHelper = htmlHelper;
        }

        public IActionResult OnGet(int? restorantID)
        {
            cuisines = HtmlHelper.GetEnumSelectList<CuisiineType>();

            if (restorantID.HasValue)
            {
                restorant = RestorantData.getRestorantById(restorantID.Value);
            }
            else
            {
                restorant = new Restorant();

            }


            if (restorant == null)
            {
                return RedirectToPage("./NotFound");
            }
            else
            {
                return Page();
            }
        }

        public IActionResult OnPost()
        {

            cuisines = HtmlHelper.GetEnumSelectList<CuisiineType>();

            if (ModelState.IsValid)
            {
                if (restorant.Id > 0)
                {
                    TempData["Message"] = " Restorant Updated Successfully";
                    restorant = RestorantData.Update(restorant);

                }
                else
                {

                    TempData["Message"] = "New Restorant Added";
                    restorant = RestorantData.add(restorant);

                }

                RestorantData.commit();
                return RedirectToPage("./Detaills", new { restorantID = restorant.Id });
            }

            return Page();
        }
    }
}
