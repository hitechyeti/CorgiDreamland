using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerData
{

    public string name = "";

    public int dreamType = 1;

    public int musicVolume = 5;
    public int musicEnabled = 1;

    public int controlMode = 1;

    public int lastScore = 0;
    public int highScore = 0;
    public int goodBoyPoints = 150;

    public int[] currentCorgiUpgrades = new int[] { 0, 0, 0, 0};

    public int[] corgiUnlocks = new int[] { 0, 1, 1, 1, 1, 1 };
    public int[] corgiCosts = new int[] { 0, 50, 150, 150, 150, 150 };

    public int[] hatUnlocks = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1};
    public int[] hatCosts = new int[] { 0, 50, 50, 50, 50, 50, 75, 75, 75, 75, 75, 75, 100, 100, 125};

    public int[] costumeUnlocks = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    public int[] costumeCosts = new int[] { 0, 75, 75, 75, 75, 75, 125, 125, 125, 150, 175, 175, 175 };

    public int[] trailUnlocks = new int[] { 0, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1, 1 };
    public int[] trailCosts = new int[] { 0, 150, 150, 200, 100, 100, 100, 150, 125, 125, 100, 150, 125, 125, 125, 150 };

}

