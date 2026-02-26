using System.ComponentModel.DataAnnotations;

namespace LaForetMagique.Models
{
    public abstract class Entity
    {
        [Key]
        public int Id { get; set; }

        public int x { get; set; }
        public int y { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;

    }
}
