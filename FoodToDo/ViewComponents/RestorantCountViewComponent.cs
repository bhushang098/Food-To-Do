using FoodToDo.Data;
using Microsoft.AspNetCore.Mvc;

namespace FoodToDo.ViewComponents
{
    public class RestorantCountViewComponent : ViewComponent
    {
        private readonly IRestorantData restorantData;

        public RestorantCountViewComponent(IRestorantData restorantData)
        {
            this.restorantData = restorantData;
        }

        public IViewComponentResult Invoke()
        {
            var count = restorantData.getCountOfRestorats();

            return View(count);
        }
    }
}
