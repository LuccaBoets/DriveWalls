using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Models
{
    public class Wallpaper
    {

        /// <summary>
        /// ID is the unique identifier for the wallpaper
        /// It's come from Google Drive
        /// </summary>
        public String Id { get; set; }
        public String Name { get; set; }
        public DateTime UploadDate { get; set; }
    }
}
