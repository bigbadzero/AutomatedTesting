using ZombieSurvivorKata.ConsoleApp.Enums;

namespace ZombieSurvivorKata.ConsoleApp;
public class Survivor
{
    private readonly IUserInput _userInput;
    public string _name { get; set; }
    public int _wounds { get; set; }
    public int _actionsPerTurn { get; set; }
    public bool _alive { get; set; }
    public List<Equipment> _equipment { get; set; }
    public int _maxEquipmentCount { get; set; }
    public LevelEnums _currentLevel { get; set; }
    public int _currentExperience { get; set; }

    public Survivor(string name, IUserInput userInput)
    {
        _name = name;
        _wounds = 0;
        _actionsPerTurn = 3;
        _alive = true;
        _equipment = new List<Equipment>();
        _maxEquipmentCount = 5;
        _userInput = userInput;
        _currentLevel = LevelEnums.Blue;
        _currentExperience = 0;
    }

    public void RecieveWound()
    {
        if (_alive)
        {
            _wounds++;
            _maxEquipmentCount = +_maxEquipmentCount - _wounds;
            if (_equipment.Count > _maxEquipmentCount)
            {
                Console.WriteLine("Due to Wounds you must remove a weapon");
                var equipmentToRemove = GetEquipmentToRemove();
                RemoveEquipment(equipmentToRemove);
            }
        }
        if (_wounds > 1)
            Die();
    }

    public void Die()
    {
        _alive = false;
        Game.AnySurvivorsLeft();
    }

    public void AddEquipment(Equipment newEquipment)
    {
        if (_equipment.Count >= _maxEquipmentCount)
        {
            EquipmentFullMessage();
        }
        else
            _equipment.Add(newEquipment);
    }

    public void RemoveEquipment(Equipment equipmentToRemove)
    {
        foreach (var equipment in _equipment)
        {
            if (equipment == equipmentToRemove)
            {
                _equipment.Remove(equipment);
                break;
            }
        }
    }

    public void SetEquipmtentToMainHand(int indexOfWeaponToBeMainHand)
    {
        var inHandCount = GetInHandEquipmentCount();
        if (inHandCount >= 2)
        {
            MaxInHandWeaponsMessage();
        }
        else
            _equipment[indexOfWeaponToBeMainHand].InHand = true;
    }

    public void RemoveEquipmentFromMainHand(int indexOfWeaponToRemoveFromMainHand)
    {
        var inHandCount = GetInHandEquipmentCount();
        if (inHandCount > 0 && inHandCount <= 2)
        {
            _equipment[indexOfWeaponToRemoveFromMainHand].InHand = false;
        }
        else
            Console.WriteLine("No Equipment In Hand");
    }

    private int GetInHandEquipmentCount()
    {
        int mainHandCount = 0;
        foreach (var equipment in _equipment)
        {
            if (equipment.InHand)
                mainHandCount++;
        }
        return mainHandCount;
    }


    private Equipment GetEquipmentToRemove()
    {
        PrintCurrentEquipment(_equipment);
        var indexOfEqiupmentToReplace = _userInput.GetIntFromUserWithRange(0, _equipment.Count - 1);
        Equipment equipmentToRemove = _equipment[indexOfEqiupmentToReplace];
        return equipmentToRemove;
    }


    public void PrintCurrentEquipment(List<Equipment> allEquipment)
    {
        for (int i = 0; i < allEquipment.Count; i++)
        {
            Console.WriteLine(i + ": " + allEquipment[i].Name);
        }
    }

    public void GainExperience()
    {
        _currentExperience++;
        if(_currentExperience == 7 || _currentExperience == 19 || _currentExperience == 43)
        {
            LevelUp();
        }
    }

    public void LevelUp()
    {

        switch (_currentLevel)
        {
            case LevelEnums.Blue:
                _currentLevel = LevelEnums.Yellow;
                break;
            case LevelEnums.Yellow:
                _currentLevel = LevelEnums.Orange;
                break;
            case LevelEnums.Orange:
                _currentLevel = LevelEnums.Red;
                break;
            case LevelEnums.Red:
                break;
            default:
                break;
        }
    }

    private void EquipmentFullMessage()
    {
        Console.WriteLine("You currently have the max equipment");
        Console.WriteLine("Remove a piece of Equipment to add a new piece");
    }

    private void MaxInHandWeaponsMessage()
    {
        Console.WriteLine("You already have 2 In Hand Weapons");
        Console.WriteLine("You will need unequip one first");
    }

}
