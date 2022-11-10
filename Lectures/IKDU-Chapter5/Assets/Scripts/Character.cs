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
    public Character(string arg_chaName)
    { 
        chaName = arg_chaName;
    }
    public void PrintStatsInfo()
    {
        Debug.LogFormat("Hero: {0} - {1} attacks with", chaName, attack);
    }
}
public struct Weapon
{
    public string weaponName;
    public int damage;

    public Weapon(string arg_name, int arg_damage)
    {
        weaponName = arg_name;
        damage = arg_damage;
    }

    public void PrintWeaponStats()
    {
        Debug.LogFormat("Weapon: {0} - {1} DMG", weaponName, damage);
    }
}
