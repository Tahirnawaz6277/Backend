using System.ComponentModel.DataAnnotations;

namespace KeepNotice.Models.Domin
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; }
     
        public string title { get; set; }
        
        public string description { get; set; }
    }
}
