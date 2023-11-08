using System.ComponentModel.DataAnnotations.Schema;

namespace Repository.Entity
{
    [Table(name:"Order")]
    public class OrderEntity
    {
        [Column("Id")]
        public int Id { get; set; }
        [Column("EntryDate")]
        public DateTime EntryDate { get; set; }
        [Column("Name")]
        public string Name { get; set; }
        [Column("Desc")]
        public string Desc { get; set; }
        [Column("IsInvoiced")]
        public bool IsInvoiced { get; set; } = true;
        [Column("IsDeleted")]
        public bool IsDeleted { get; set; } = false;
    }
}