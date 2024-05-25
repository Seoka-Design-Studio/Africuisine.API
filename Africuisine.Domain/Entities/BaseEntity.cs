using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace Africuisine.Domain.Entities
{
    public class BaseEntity : IDataEntity
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)] 
        public string Id { get; set; }
        public DateTime Creation { get; set; }
        public DateTime LastUpdate { get; set; }
        public string LUserUpdate { get; set; }
        public int SeqNo { get; set; }
    }
}
