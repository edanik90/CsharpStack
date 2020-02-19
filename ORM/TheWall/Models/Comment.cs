using System;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class Comment
    {
        [Key]
        public int CommentId {get;set;}
        
        [Required(ErrorMessage="Comment is required")]
        public string Content {get;set;}
        public int UserId {get;set;}
        public int MessageId {get;set;}
        public User Creator {get;set;}
        public Message Message {get;set;}       
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}