namespace Ticket.Utility.Messages
{
    public class ErrorMessage
    {
        public ErrorMessage()
        {
            Success = false;
        }

        public int Code { get; set; }
        public string Message { get; set; }
        /// <summary>
        ///  是否成功
        /// </summary>
        public bool Success { get; set; }
    }
}
