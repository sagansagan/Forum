namespace Forum.Web.Models.Domain
{
    public class ThreadModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Text { get; set; }
        public DateTime Created { get; set; }

        public int TopicId { get; set; }
        public TopicModel Topic { get; set; }
        public ICollection<ReplyModel> Replies { get; set; }
    }
}
