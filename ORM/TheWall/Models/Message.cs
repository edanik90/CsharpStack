using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace TheWall.Models
{
    public class Message
    {
        [Key]
        public int MessageId {get;set;}
        
        [Required(ErrorMessage="Message is required")]
        public string Content {get;set;}
        public int UserId {get;set;}
        public User Creator {get;set;}
        public List<Comment> Comments {get;set;}
        public DateTime CreatedAt {get;set;} = DateTime.Now;
        public DateTime UpdatedAt {get;set;} = DateTime.Now;
    }
}