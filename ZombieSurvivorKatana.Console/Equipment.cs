using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class Equipment
    {
        public string Name { get; set; }
        public Guid Id { get; set; }
        public EquipmentTypeEnum EquipmentType { get; set; }
        public Equipment(string name)
        {
            Name = name;
            EquipmentType = EquipmentTypeEnum.Reserve;
            Id= Guid.NewGuid();
        }
    }
}
