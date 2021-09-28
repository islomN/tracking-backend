using System.ComponentModel.DataAnnotations.Schema;

namespace Tracking.Core.Tables
{
    [Table("operation_systems")]
    public class OperationSystem
    {
        [Column("id")]
        public byte Id { get; set; }
        
        [Column("name")]
        public string Name { get; set; }
    }
}