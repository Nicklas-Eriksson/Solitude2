using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Solitude2.Models
{
    public class Inventory
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Items")]
        public int ItemId { get; set; }
        [ForeignKey("Players")]
        public int PlayerId { get; set; }
    }
}
