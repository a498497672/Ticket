namespace Ticket.Model.WeiXin
{
    public class BannerDto
    {
        public int Id { get; set; }
        public int EnterpriseId { get; set; }
        public int ScenicId { get; set; }
        public string Title { get; set; }
        public string ImgPath { get; set; }
        public string ImgPathUrl { get; set; }
        public string Url { get; set; }
        public bool IsEnable { get; set; }
    }
}
