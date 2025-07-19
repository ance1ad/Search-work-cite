using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace FindWorkApp.Models
{
    public class Worker
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("JobResume")]
        public int? JobResumeId { get; set; }

    }
}
