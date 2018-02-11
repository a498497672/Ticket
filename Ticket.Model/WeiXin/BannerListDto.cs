namespace Ticket.Model.WeiXin
{
    public class BannerListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string ImgPath { get; set; }
        public int Order { get; set; }
        public bool IsEnable { get; set; }
        public string IsEnableName
        {
            get
            {
                return IsEnable ? "上架" : "下架";
            }
        }
    }
}
