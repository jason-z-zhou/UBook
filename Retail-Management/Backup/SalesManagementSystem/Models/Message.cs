using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SalesManagementSystem.Models
{
    public enum SenderStatus
    {
        Undeleted = 0,
        Deleted
    }

    public enum ReceiverStatus
    {
        Unread = 0,
        Read,
        Deleted
    }

    public class Message
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public int MessageID { get; set; }

        [Display(Name = "发件人")]
        public virtual User Sender { get; set; }
        [Required]
        public int SenderID { get; set; }

        [Display(Name = "收件人")]
        public virtual User Receiver { get; set; }
        [Required]
        public int ReceiverID { get; set; }

        [Display(Name = "内容")]
        [Required]
        [MaxLength(500)]
        public string Content { get; set; }

        [Display(Name = "发件人状态")]
        [Required]
        private int senderStatus { get; set; }

        public SenderStatus SenderStatus
        {
            get { return (SenderStatus)senderStatus; }
            set { senderStatus = (int)value; }
        }

        [Display(Name = "收件人状态")]
        [Required]
        private int receiverStatus { get; set; }

        public ReceiverStatus ReceiverStatus
        {
            get { return (ReceiverStatus)receiverStatus; }
            set { receiverStatus = (int)value; }
        }

        [Display(Name = "发送时间")]
        [Required]
        public DateTime SendTime { get; set; }

        public bool DeleteFromOutbox()
        {
            SenderStatus = Models.SenderStatus.Deleted;
            return ((SenderStatus == Models.SenderStatus.Deleted) && (ReceiverStatus == Models.ReceiverStatus.Deleted));
        }

        public bool DeleteFromInbox()
        {
            ReceiverStatus = Models.ReceiverStatus.Deleted;
            return ((SenderStatus == Models.SenderStatus.Deleted) && (ReceiverStatus == Models.ReceiverStatus.Deleted));
        }
    }
}          