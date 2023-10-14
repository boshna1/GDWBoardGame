using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


public class Item
{
    // Start is called before the first frame update
    public int currentplayer;
    public Transform[] Char1Item = new Transform[2];
    public Transform[] Char2Item = new Transform[2];
    public Transform[] Char3Item = new Transform[2];
    public Transform[] Char4Item = new Transform[2];
    public int[] P1Item = new int[2];
    public int[] P2Item = new int[2];
    public int[] P3Item = new int[2];
    public int[] P4Item = new int[2];
    public GameObject[] Items = new GameObject[8];
    int tempItem;

    public void SetItem(int currentPlayer, int Itemslot, int Itemtype)
    {
        if (currentPlayer == 0)
        {
            if (Itemslot == 0)
            {
                P1Item[0] = Itemtype;
            }
            if (Itemslot == 1)
            {
                P1Item[1] = Itemtype;
            }
        }
        if (currentPlayer == 1)
        {
            if (Itemslot == 0)
            {
                P2Item[0] = Itemtype;
            }
            if (Itemslot == 1)
            {
                P2Item[1] = Itemtype;
            }
        }
        if (currentPlayer == 2)
        {
            if (Itemslot == 0)
            {
                P3Item[0] = Itemtype;
            }
            if (Itemslot == 1)
            {
                P3Item[1] = Itemtype;
            }
        }
        if (currentPlayer == 3)
        {
            if (Itemslot == 0)
            {
                P4Item[0] = Itemtype;
            }
            if (Itemslot == 1)
            {
                P4Item[1] = Itemtype;
            }
        }
    }

    public int GetItem(int currentPlayer, int Itemslot, int Itemtype)
    {
        
        if (currentPlayer == 0)
        {
            if (Itemslot == 0)
            {
                tempItem = P1Item[0];
            }
            if (Itemslot == 1)
            {
                tempItem = P1Item[1];
            }
        }
        if (currentPlayer == 1)
        {
            if (Itemslot == 0)
            {
                tempItem = P2Item[0];
            }
            if (Itemslot == 1)
            {
                tempItem = P2Item[1];
            }
        }
        if (currentPlayer == 2)
        {
            if (Itemslot == 0)
            {
                tempItem = P3Item[0];
            }
            if (Itemslot == 1)
            {
                tempItem = P3Item[1];
            }
        }
        if (currentPlayer == 3)
        {
            if (Itemslot == 0)
            {
                tempItem = P4Item[0];
            }
            if (Itemslot == 1)
            {
                tempItem = P4Item[1];
            }
        }
        return tempItem;
    }
}
