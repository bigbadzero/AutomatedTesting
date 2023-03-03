﻿using System.Text;

namespace ZombieSurvivorKatana.ConsoleApp;

public static class Constants
{
    public static string MaxEquipmentMessage()
    {
        var sb = new StringBuilder();
        sb.Append("You are at the maximum amount of equipment you can currently hold.");
        sb.Append("Would you like to discard a piece of equipment");
        return sb.ToString();
    }

    public static string MaxInHandEquipmentMessage()
    {
        var sb = new StringBuilder();
        sb.Append("You already have the maximum amount of InHand Equipment.");
        sb.Append("Would you like to swap out an In Hand piece of Equipment");
        return sb.ToString();
    }
}
