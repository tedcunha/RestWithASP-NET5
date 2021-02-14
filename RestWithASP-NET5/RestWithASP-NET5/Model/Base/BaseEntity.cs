using System.ComponentModel.DataAnnotations.Schema;

namespace RestWithASP_NET5.Model.Base
{
    public class BaseEntity
    {
        [Column("Id")]
        public int Id { get; set; }
    }
}
