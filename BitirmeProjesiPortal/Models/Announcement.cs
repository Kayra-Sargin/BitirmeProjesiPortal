using System.ComponentModel.DataAnnotations.Schema;

namespace BitirmeProjesiPortal.Models
{
    public class Announcement
    {
        public int Id { get; set; }
        public string? Header { get; set; }
        public string? Content { get; set; }
        [ForeignKey("ClassReferences")]
        public int ClassReferenceId { get; set; }
        public virtual ClassReference? ClassReferences { get; set; }
    }
}
