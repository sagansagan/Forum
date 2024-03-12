using System.ComponentModel.DataAnnotations;

namespace Forum.Web.Models.Domain
{
    public class TopicModel
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }

        public ICollection<ThreadModel> Threads { get; set; }

    }
}
