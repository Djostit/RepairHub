using System.ComponentModel.DataAnnotations;

namespace RepairHub.Database.Entities.Base
{
    public class Entity : Interface.IEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
