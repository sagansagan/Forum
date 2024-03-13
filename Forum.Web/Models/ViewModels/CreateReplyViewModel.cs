using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace Forum.Web.Models.ViewModels
{
    public class CreateReplyViewModel
    {
        [AllowNull]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Content is required")]
        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int ThreadId { get; set; }
    }
}
