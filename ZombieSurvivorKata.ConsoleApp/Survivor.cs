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
	public List<string> _inHandEquipment { get; set; }
	public List<string> _reserveEquipment { get; set; }
	public int _maxWeaponCount { get; set; }

	public Survivor(string name)
	{
		_name= name;
		_wounds = 0;
		_actionsPerTurn = 3;
		_alive= true;
		_inHandEquipment = new List<string>();
		_reserveEquipment = new List<string>();
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
				RemoveEquipment(allEquipment);
            }
        }
		if (_wounds > 1)
			Die();
	}

	public void Die()
	{
		_alive = false;
	}

	public void AddEquipment(string newEquipment)
	{
		var allEquipment = CombineEquipmentLists(_inHandEquipment, _reserveEquipment);
        if (allEquipment.Count >= 5)
		{
			EquipmentFullMessage();
            var userInput = new UserInput();
			var replaceEquipment = userInput.GetIntFromUserWithRange(1, 2);
            if(replaceEquipment == 1)
			{
				RemoveEquipment(allEquipment);
				allEquipment.Add(newEquipment);
			}
			CheckIfInHandWeaponDiscarded(allEquipment);
        }
		else
		{
			allEquipment.Add(newEquipment);
		}
	}
	
	public void RemoveEquipment(List<string> currentEquipment)
	{
		UserInput userInput= new UserInput();
		PrintCurrentEquipment(currentEquipment);
		var indexOfEqiupmentToReplace = userInput.GetIntFromUserWithRange(0, currentEquipment.Count - 1);
		currentEquipment.Remove(currentEquipment[indexOfEqiupmentToReplace]);
	}

	public void PrintCurrentEquipment(List<string> allEquipment)
	{
		for (int i = 0; i < allEquipment.Count; i++)
		{
			Console.WriteLine(i + ": " + allEquipment[i]);
		}
	}

	private void EquipmentFullMessage()
	{
        Console.WriteLine("You currently have the max equipment");
        Console.WriteLine("Would you like to drop a piece of equipment for this one?");
        Console.WriteLine("1 = yes, 2 = no");
    }

	private List<string> CombineEquipmentLists(List<string> inHand,List<string> reserve)
	{
		var combined = new List<string>();
		combined.AddRange(inHand);
		combined.AddRange(reserve);
		return combined;
	}

	private void CheckIfInHandWeaponDiscarded(List<string> allEquipment)
	{
        foreach (var equipment in _inHandEquipment)
        {
            if (!allEquipment.Contains(equipment))
            {
				_inHandEquipment.Remove(equipment);
				Console.WriteLine($"{equipment} Was removed From In Hand Weapons");
            }
        }
    }

	private bool MaxWeaponsExceeded(List<string> allEquipment)
	{
		if (allEquipment.Count > _maxWeaponCount)
			return true;
		else
			return false;
	}
	

}
