using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ZombieSurvivorKatana.ConsoleApp
{
    public class Survivor
    {
        public string Name { get; set; }
        public int Wounds { get; internal set; }
        public int ActionsPerTurn { get; internal set; }
        public bool Active { get; internal set; }
        private List<Equipment> Equipment { get; set; }
        public int MaxEquipment { get; internal set; }
        public IUserInput _userInput;
        private Constants Constants {get; }


        public Survivor(string name, IUserInput userInput)
        {
            Name = name;
            Wounds = 0;
            ActionsPerTurn = 3;
            Active = true;
            Equipment = new List<Equipment>();
            MaxEquipment = 5;
            _userInput = userInput;
            Constants = new Constants();
        }

        private void RecieveWound()
        {
            Wounds++;
            if (Wounds == 2)
                Die();
            MaxEquipment = MaxEquipment - Wounds;
            if(Equipment.Count > MaxEquipment)
            {
                Console.WriteLine("Because of your wounds you can no longer carry this much equipment");
                DropEquipment();
            }
        }
        
        

        private void Die()
        {
            Active = false;
        }

        public void SetEquipmentToInHand(int indexOfEquipmentToBeInHand)
        {
            //check if you already have two inHand pieces of equipment
            var inHandEquipment = Equipment.Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).ToList();
            if(inHandEquipment.Count() < 2)
            {
                Equipment[indexOfEquipmentToBeInHand].EquipmentType = EquipmentTypeEnum.InHand;
            }
            else
            {
                Console.Write(Constants.MaxInHandEquipmentMessage);
                var swapOutEquipment = _userInput.Proceed();
                if (swapOutEquipment == true)
                {
                    Console.WriteLine("Which piece would you like to swap");
                    PrintCurrentInHandEquipment();
                    var indexOfEquipmentToBeSwapped = _userInput.GetIntFromUserWithRange(0, 1);
                    var inHandequipmentToBeSwapped = inHandEquipment[indexOfEquipmentToBeSwapped];
                    Equipment.Remove(inHandequipmentToBeSwapped);
                }
            }
        }

        public void AddEquipment(Equipment newEquipment)
        {
            //check count vs maxEquipment
            if (Equipment.Count == MaxEquipment)
            {
                Console.WriteLine(Constants.MaxEquipmentMessage);
                var discardEquipment = _userInput.Proceed();
                if (discardEquipment == true)
                    DropEquipment();
                else
                {
                    Console.WriteLine($"{newEquipment.Name} Discarded");
                    return;
                }

            }
            else
                Equipment.Add(newEquipment);
        }

        public void PrintCurrentEquipment()
        {
            for (int i = 0; i < Equipment.Count; i++)
                Console.WriteLine($"{i}) {Equipment[i].Name}");
        }

        public void PrintCurrentInHandEquipment()
        {
            var inHandEquipment = Equipment.Where(x => x.EquipmentType == EquipmentTypeEnum.InHand).ToList();
            for (int i = 0; i < inHandEquipment.Count(); i++)
                Console.WriteLine($"{i}) {inHandEquipment[i].Name}");
        }

        public void DropEquipment()
        {
            Console.WriteLine("Which weapon would you like to drop");
            PrintCurrentEquipment();
            var equipmentToDropIndex = _userInput.GetIntFromUserWithRange(0, Equipment.Count - 1);
            var equipmentToDrop = Equipment[equipmentToDropIndex];
            Equipment.Remove(equipmentToDrop);
            Console.WriteLine($"{equipmentToDrop.Name} dropped");
        }

        //public Equipment GetEquipmentToDrop()
        //{

        //}

        public List<Equipment> GetEqupment()
        {
            return Equipment;
        }
    }
}
