using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using TradeIt__.Data;
using TradeIt__.Models;
using System.Net.Mime;

namespace TradeIt__.Controllers
{
    public class AccountController : Controller
    {
        private readonly ApplicationDbContext db;
        private readonly IWebHostEnvironment env;
        public AccountController(ApplicationDbContext db,
            IWebHostEnvironment env)
        {
            this.db = db;
            this.env = env;
        }

        public FileContentResult Photo(string userName)
        {

            var user = db.Users.FirstOrDefault(x => x.UserName == userName);
            if(user.ProfilePicture == null)
            {
                return null;
            }
            return new FileContentResult(user.ProfilePicture, "image/jpeg");
        }

        [HttpGet]
        public ActionResult Profile()
        {
            ViewBag.Message = "Update your profile";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Profile(IFormFile Profile)
        {
  

            var userName = User.Identity.Name;
            var user = db.Users.Where(x => x.UserName == userName).FirstOrDefault();


            byte[] image = new byte[Profile.Length];
            var resultInBytes = ConvertToBytes(Profile);
            Array.Copy(resultInBytes, image, resultInBytes.Length);
            user.ProfilePicture = image;

            db.SaveChanges();

            return RedirectToAction("Index", "Home");
        }


        private byte[] ConvertToBytes(IFormFile image)
        {
            using (var memoryStream = new MemoryStream())
            {
                image.OpenReadStream().CopyTo(memoryStream);
                return memoryStream.ToArray();
            }
        }

        public IFormFile ReturnFormFile(FileStreamResult result)
        {
            var ms = new MemoryStream();
            try
            {
                result.FileStream.CopyTo(ms);
                return new FormFile(ms, 0, ms.Length, null, null);
            }
            catch (Exception e)
            {
                ms.Dispose();
                throw;
            }
            finally
            {
                ms.Dispose();
            }
        }
    }
}
