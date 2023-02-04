using System.Drawing;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices;

namespace ZombieSurvivorKata.ConsoleApp;

public class Survivor
{
    public string _name { get; set; }
	public int _wounds { get; set; }
	public int _actionsPerTurn { get; set; }
	public bool _alive { get; set; }
	public List<Equipment> _inHandEquipment { get; set; }
	public List<Equipment> _reserveEquipment { get; set; }
	public int _maxWeaponCount { get; set; }

	public Survivor(string name)
	{
		_name= name;
		_wounds = 0;
		_actionsPerTurn = 3;
		_alive= true;
		_inHandEquipment = new List<Equipment>();
		_reserveEquipment = new List<Equipment>();
		_maxWeaponCount = 5;
	}

	public void RecieveWound()
	{
        var allEquipment = CombineEquipmentLists(_inHandEquipment, _reserveEquipment);
        if (_alive)
		{
            _wounds++;
			if (MaxWeaponsExceeded(allEquipment))
			{
                Console.WriteLine("Due to Wounds you must remove a weapon");
				
            }
        }
		if (_wounds > 1)
			Die();
	}

	public void Die()
	{
		_alive = false;
	}

	public void AddEquipment(Equipment newEquipment)
	{
		var allEquipment = CombineEquipmentLists(_inHandEquipment, _reserveEquipment);
		var totalWeaponsCount = _inHandEquipment.Count + _reserveEquipment.Count;
        if (totalWeaponsCount >= 5)
		{
			EquipmentFullMessage();
            var userInput = new UserInput();
			var replaceEquipment = userInput.GetIntFromUserWithRange(1, 2);
            if(replaceEquipment == 1)
			{
				var equipmentToRemove = GetEquipmentToRemove(allEquipment);

                RemoveEquipment(equipmentToRemove);
            }
        }
		else
		{
			allEquipment.Add(newEquipment);
		}
	}
	
	public void RemoveEquipment(Equipment equipmentToRemove)
	{
		if(isEquipmentInEquipmentList(_inHandEquipment, equipmentToRemove))
		{
			_inHandEquipment.Remove(equipmentToRemove);
			Console.WriteLine("Weapon dropped from In Hand Weapons");
		}
		else
		{
			_reserveEquipment.Remove(equipmentToRemove);
            Console.WriteLine("Weapon dropped from Reserve Weapons");
        }
	}

	public void AddEquipment(Equipment newEquipment)
	{

	}

	private Equipment GetEquipmentToRemove(List<Equipment> allEquipment)
	{
        UserInput userInput = new UserInput();
        PrintCurrentEquipment(allEquipment);
        var indexOfEqiupmentToReplace = userInput.GetIntFromUserWithRange(0, allEquipment.Count - 1);
        Equipment equipmentToRemove = allEquipment[indexOfEqiupmentToReplace];
		return equipmentToRemove;
    }

	private bool isEquipmentInEquipmentList(List<Equipment> listOfEquipment, Equipment equipmentToRemove)
	{
		if (listOfEquipment.Contains(equipmentToRemove))
			return true;
		else
			return false;
	}

	public void PrintCurrentEquipment(List<Equipment> allEquipment)
	{
		for (int i = 0; i < allEquipment.Count; i++)
		{
			Console.WriteLine(i + ": " + allEquipment[i].Name);
		}
	}

	private void EquipmentFullMessage()
	{
        Console.WriteLine("You currently have the max equipment");
        Console.WriteLine("Would you like to drop a piece of equipment for this one?");
        Console.WriteLine("1 = yes, 2 = no");
    }

	private List<Equipment> CombineEquipmentLists(List<Equipment> inHand,List<Equipment> reserve)
	{
		var combined = new List<Equipment>();
		combined.AddRange(inHand);
		combined.AddRange(reserve);
		return combined;
	}


	private bool MaxWeaponsExceeded(List<Equipment> allEquipment)
	{
		if (allEquipment.Count > _maxWeaponCount)
			return true;
		else
			return false;
	}
	

}
