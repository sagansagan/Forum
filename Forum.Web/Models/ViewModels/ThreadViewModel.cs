using Forum.Web.Models.Domain;

namespace Forum.Web.Models.ViewModels
{
    public class ThreadViewModel
    {
        public ThreadModel Thread { get; set; }
        public List<ReplyModel> Replies { get; set; }
    }
}
