using System;

namespace RentXpress.Models
{
    // One row from inquiry_replies. Each reply belongs to one inquiry conversation.
    public class InquiryReply
    {
        public int Id { get; set; }
        public int InquiryId { get; set; }
        public int SenderId { get; set; }
        public string SenderName { get; set; }
        public string Message { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
