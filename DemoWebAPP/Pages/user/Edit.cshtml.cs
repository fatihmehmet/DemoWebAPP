using DemoWebAPP.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace DemoWebAPP.Pages.user
{
    public class EditModel : PageModel
    {

        public Users user = new Users();
        public string successMessage = String.Empty;
        public string errorMessage = String.Empty;


        private readonly IConfiguration configuration;

        public EditModel(IConfiguration configuration)
        {
            this.configuration = configuration;
        }
        public void OnGet()
        {

            String id = Request.Query["id"];

            try
            {
                DAL dal = new DAL();
                user = dal.GetUser(id, configuration);


            }
            catch(Exception ex) {
                errorMessage = ex.Message; 
            }


        }

        public void OnPost()
        {
            user.ID = Request.Form["hiddenId"];
            user.FirstName = Request.Form["FirstName"];
            user.LastName = Request.Form["LastName"];

            if (user.FirstName.Length == 0 || user.LastName.Length == 0)
            {
                errorMessage = "Bu Alanlar Boþ Geçilemez!.þaoeýhgsþkldfjgnsþdklfldfjhskldfjbhsdfh";
                return;

            }

            try
            {
                DAL dal = new DAL();
                int i = dal.UpdateUser(user, configuration);

            }
            catch (Exception ex)
            {
                errorMessage = ex.Message;
                return;
            }

            user.FirstName = "";
            user.LastName = "";
            successMessage = "Kullanýcý Güncellendi!!.";
            Response.Redirect("/User/Index");



        }



    }
}
