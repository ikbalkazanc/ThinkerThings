using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using ThinkerThings.Core.Common;
using ThinkerThings.Core.Contracts;
using ThinkerThings.Core.Entities.Devices;

namespace ThinkerThings.Core.Entities
{
    public class Gateway : AuditableBaseEntity , IDeleteable
    {
        public bool isAlive { get; set; }

        
        public int NetworkId { get; set; }
        public Network Network { get; set; }
        
        public int UserId { get; set; }
        public  User User { get; set; }

        
        public ICollection<AirConditioner> AirConditioners { get; set; }
        public ICollection<MotionSensor> MotionSensors { get; set; }
        public ICollection<SmartLamp> SmartLamps { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? DeletedOn { get; set; }
        public string DeleteRemarks { get; set; }
    }
}
