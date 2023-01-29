using System.Drawing;

namespace ZombieSurvivorKata.ConsoleApp;

public class Survivor
{
    public string _name { get; set; }
	public int _wounds { get; set; }
	public int _actionsPerTurn { get; set; }
	public bool _alive { get; set; }
	public Survivor(string name)
	{
		_name= name;
		_wounds = 0;
		_actionsPerTurn = 3;
		_alive= true;
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

}
