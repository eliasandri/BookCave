

using System.ComponentModel.DataAnnotations;

namespace BookCave.Data.EntityModels
{
    public class ShopCart
    {
        [Key]
        public int RecordId { get; set; }
        public int CartId { get; set; }
        public int ItemId { get; set; }
        public int Count { get; set; }
        public System.DateTime DateCreated { get; set; }
        public virtual Book Book { get; set; }
    }
}