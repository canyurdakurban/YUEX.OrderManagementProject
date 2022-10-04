using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using YUEX.OrderManagementProject.Entities.IEntities;

namespace YUEX.OrderManagementProject.Entities.Entities
{
    [Serializable]
    public class BaseEntity : IEntity
    {
        [Key]
        public int Id { get; set; }       
        public bool IsActive { get; set; } = true;                
        public DateTime CreatedDate { get; set; } = DateTime.Now;
        public DateTime UpdateDate { get; set; } = DateTime.Now;
        public int CreateUser { get; set; }
        public int UpdatedUser { get; set; }
    }
}
