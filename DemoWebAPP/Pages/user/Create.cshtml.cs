using DemoWebAPP.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Xml.Serialization;

namespace DemoWebAPP.Pages.user
{
    public class CreateModel : PageModel
    {

        public Users user = new Users();
        public string successMessage = String.Empty;
        public string errorMessage = String.Empty;

        private readonly IConfiguration configuration;

        public CreateModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {
        }


        public void OnPost()
        {
         
            user.FirstName = Request.Form["FirstName"];
            user.LastName = Request.Form["LastName"];

            if (user.FirstName.Length == 0 || user.LastName.Length == 0)
            {
                errorMessage = "Bu Alanlar Boþ Geçilemez!.";
                return;

            }

            try
            {
                DAL dal = new DAL();
                int i = dal.AddUser(user, configuration);

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            user.FirstName = "";
            user.LastName = "";
            successMessage = "Kullanýcý Eklendi.";
            Response.Redirect("/User/Index");



        }
    }
}
