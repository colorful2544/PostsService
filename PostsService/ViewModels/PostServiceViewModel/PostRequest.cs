using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace PostsService.ViewModels.PostServiceViewModel
{
    public class PostRequest
    {
        [Display(Name = "Username : ")]
        [Required(ErrorMessage = "Please enter your username")]
        public string Name { get; set; }
        [Required(ErrorMessage = "Please upload your images")]
        [Display(Name = "Upload Images : ")]
        public List<IFormFile> imagesList { get; set; }
        [Display(Name = "Detail : ")]
        [Required(ErrorMessage = "Please enter your detail")]
        public string detail {  get; set; }
    }
}
