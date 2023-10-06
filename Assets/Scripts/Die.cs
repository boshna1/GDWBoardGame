using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Class to roll the dice
public class Die : MonoBehaviour
{
    public int RollDice()
    {
        int Roll1 = Random.Range(0, 6);
        int Roll2 = Random.Range(0, 6);
        int TotalRoll = Roll1 + Roll2;
        return TotalRoll;
    }      
}
