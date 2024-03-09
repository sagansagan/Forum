using System.ComponentModel.DataAnnotations.Schema;

namespace Forum.Web.Models.Domain
{
    public class ReplyModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }

        public DateTime Created { get; set; }

        public int ThreadId { get; set; }
        public ThreadModel Thread { get; set; }
    }
}
