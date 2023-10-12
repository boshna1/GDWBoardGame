using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to roll the dice
public class Die
{
    public (int,int) RollDice()
    {
        int Roll1 = Random.Range(1, 6);
        int Roll2 = Random.Range(1, 6);
        int TotalRoll = Roll1 + Roll2;
        return (Roll1, Roll2);
    }      
}
