using System.Drawing;

namespace ZombieSurvivorKata.ConsoleApp;

public class Survivor
{
    public string _name { get; set; }
	public int _wounds { get; set; }
	public int _actionsPerTurn { get; set; }
	public bool _alive { get; set; }
	public List<string> _inHandEquipment { get; set; }
	public List<string> _reserveEquipment { get; set; }

	public Survivor(string name)
	{
		_name= name;
		_wounds = 0;
		_actionsPerTurn = 3;
		_alive= true;
		_inHandEquipment = new List<string>();
		_reserveEquipment = new List<string>();
	}

	public void RecieveWound()
	{
		if (_alive)
			_wounds++;
		if (_wounds > 1)
			Die();
	}

	public void Die()
	{
		_alive = false;
	}

	public void AddEquipment(string newEquipment)
	{
		var allEquipment = new List<string>();
		allEquipment.AddRange(_inHandEquipment); 
		allEquipment.AddRange(_reserveEquipment);
		if(allEquipment.Count >= 5)
		{
			Console.WriteLine("You currently have the max equipment");
			Console.WriteLine("Would you like to drop a piece of equipment for this one?");

		}
	}

	public void PrintCurrentEquipment(List<string> allEquipment)
	{
		for (int i = 0; i < allEquipment.Count; i++)
		{
			Console.WriteLine(i + ": " + allEquipment[i]);
		}
	}

}
