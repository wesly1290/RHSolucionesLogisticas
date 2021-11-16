using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace WebApp.Pages.Manual
{
    public class UserManualModel : PageModel
    {
        private IHostingEnvironment Environment;
        public UserManualModel(IHostingEnvironment _environment)
        {
            this.Environment = _environment;
        }

        public FileResult OnGetDownloadFile(string fileName)
        {
            //Build the File Path.
            fileName = "UserManual.pdf";
            string path = Path.Combine(this.Environment.WebRootPath, @"Assets\Manual\") + fileName;

            //Read the File data into Byte Array.
            byte[] bytes = System.IO.File.ReadAllBytes(path);

            //Send the File to Download.
            return File(bytes, "application/octet-stream", fileName);
        }
    }
}
