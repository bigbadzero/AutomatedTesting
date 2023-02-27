﻿using ZombieSurvivorKatana.ConsoleApp.Actions;

namespace ZombieSurvivorKatana.ConsoleApp;

public class Game
{
    public List<Survivor> Survivors { get; set; }
    public readonly IUserInput _userInput;
    private bool GameOver { get; set; }
    public Game(IUserInput userInput)
    {
        Survivors = new List<Survivor>();
        _userInput = userInput;
        GameOver = false;
        StartGame();
        PlayGame();
    }

    public void CreateSurvivor(string name)
    {
        var characterCreated = false;
        while(!characterCreated)
        {
            var doesSurviviorAlreadyExist = Survivors.Any(x => x.Name == name);
            if (doesSurviviorAlreadyExist)
            {
                Console.WriteLine($"Survivor with the name {name} already exists");
                Console.WriteLine("Please try a different name");
            }
            else
            {
                var Survivor = new Survivor(name, this);
                Survivors.Add(Survivor);
                Console.WriteLine($"Survivor {Survivor.Name} created");
                characterCreated= true;
            }
        }

    }

    public void CheckGameStatus()
    {
        if (Survivors.All(x => x.Active == false))
            GameOver= true;
        
    }

    private void StartGame()
    {
        Console.WriteLine("Welcome to Zombie Survivor Game");
        Console.WriteLine("How many surviviors will be in this game to begin with?");
        var numOfSurvivors = _userInput.GetIntFromUser();

        for (int i = 0; i < numOfSurvivors; i++)
        {
            Console.WriteLine($"Enter the name for Survivior #{i +1}");
            var name = _userInput.GetNameFromUser();
            CreateSurvivor(name);
        }

    }

    private void PlayGame()
    {
        while(!GameOver)
        {
            ResetActionsPerTurn();
            foreach (var survivor in Survivors)
            {
                //while survivor has turns get an action
                //after action is performed reevaluate actions
                while(survivor.ActionsPerTurn > 0 && survivor.Active == true)
                {
                    //get an action
                    //perform action
                    Console.WriteLine($"What Action Would {survivor.Name} Like To Perform?");
                    var gameActions = Enum.GetNames(typeof(GameActions));
                    var test = gameActions.Length;
                    for (int i = 0; i < gameActions.Length; i++)
                    {
                        Console.WriteLine($"{i} {gameActions[i]}");
                    }
                    var gameActionChoosen = _userInput.GetIntFromUserWithRange(0, gameActions.Length -1);
                    //equipment actions
                    //add equipment
                    //drop equipment
                    //make equipment inhand
                }
            }
        }
    }

    private void ResetActionsPerTurn()
    {
        foreach (var survivor in Survivors)
        {
            survivor.ActionsPerTurn = 3;
        }
    }

}
