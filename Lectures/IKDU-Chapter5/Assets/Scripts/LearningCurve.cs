using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LearningCurve : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Character hero = new Character();
        hero.PrintStatsInfo();
        Character heroine = new Character("Agatha");
        heroine.PrintStatsInfo();

        Character hero2 = hero;
        hero2.PrintStatsInfo();
        hero2.chaName = "BlahBlah";
        hero.PrintStatsInfo();
        hero2.PrintStatsInfo();

        Debug.Log("Here info changes");

        Weapon huntingBow = new Weapon("Hunting bow", 105);
        huntingBow.PrintWeaponStats();
        Weapon simpleBow = huntingBow;
        simpleBow.PrintWeaponStats();
        simpleBow.weaponName = "trashFlinger";
        huntingBow.PrintWeaponStats();
        simpleBow.PrintWeaponStats();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
