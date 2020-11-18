using UnityEngine;
using System.Collections.Generic;
using System;

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/Prerequisite", order = 1)]
public class Prerequisite : ScriptableObject
{

    public Item[] conditions;

    public bool CheckAgainst(Item[] items)
    {
        List<Item> conditionsList = new List<Item>();
        List<Item> itemsList = new List<Item>();
        foreach(Item item in conditionsList)
        {
            if(!itemsList.Contains(item))
            {
                return false;
            }
        }
        return true;
    }
}

[Serializable]
public struct Item
{
    public string name;
}