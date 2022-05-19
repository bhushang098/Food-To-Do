using FoodToDo.Core;
using FoodToDo.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace FoodToDo.Pages.Restorants
{
    public class ListModel : PageModel
    {
        private readonly IConfiguration configuration;
        private readonly IRestorantData restorantData;

        public String Message { get; set; }
        public IEnumerable<Restorant> restorants { get; set; }

        [BindProperty(SupportsGet = true)]
        public String SeartcTerm { get; set; }

        public ListModel(IConfiguration configuration,IRestorantData restorantData)
        {
            this.configuration = configuration;
            this.restorantData = restorantData;
        }
        public void OnGet()
        {
            // Message = "Hey There !";
            Message = configuration["test_message"];
            // restorants = restorantData.getAll();
            restorants = restorantData.getRestorantsByName(SeartcTerm);



        }
    }
}
