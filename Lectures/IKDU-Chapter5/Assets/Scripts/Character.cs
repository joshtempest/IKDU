using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    public string chaName;
    public int attack;

    public Character()
    {
        chaName = "Name not assigned";
    }
    public Character(string chaName)
    { 
        this.chaName = chaName;
    }
    public void PrintStatsInfo()
    {
        Debug.LogFormat("Hero: {0} - {1} attacks", chaName, attack);
    }
}
