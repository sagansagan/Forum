using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;

namespace Forum.Web.Models.ViewModels
{
    public class CreateThreadViewModel
    {
        [Required(ErrorMessage = "Title is required")]
        public string Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string Text { get; set; }

        public DateTime Created { get; set;}

        public int SelectedTopicId { get; set; }
    }
}
