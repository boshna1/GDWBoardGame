using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEditor.U2D.Animation;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

// 
// TBD
// 



public class CameraMovement : MonoBehaviour
{
    [SerializeField] private List<Player> _player;
    int _currentPlayer = 0;
    bool x = true;
     

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        

    }
}
//TBD
/*
bool ItemAction;
bool AbilityAction;
bool RollAction;

public Button RollButton;
public Button ItemButton;
public Button AbilityButton;

public Transform RollButtonT;
public Transform ItemButtonT;
public Transform AbilityButtonT;

int[] Item1 = new int[4];
int[] Item2 = new int[4];

Item ItemC = new Item();
int tempPlayer;

int usePlayerItem1;
int usePlayerItem2;

public Button P1Pick;
public Button P2Pick;
public Button P3Pick;
public Button P4Pick;

public Transform P1PickT;
public Transform P2PickT;
public Transform P3PickT;
public Transform P4PickT;
*/

/* TBD
            if (_tileMovementAmount == 0 && Clicked == false && (ItemAction == false || AbilityAction == false))
            {
                Instantiate(RollButton, RollButtonT);
                Instantiate(ItemButton, ItemButtonT);
                Instantiate(AbilityButton, AbilityButtonT);

            }
            _text.text = "You rolled a " + Roll.Item1 + " and a " + Roll.Item2;

            if (_tileMovementAmount == 0 && Clicked == false && ItemAction == true) 
            {
                Instantiate(P1Pick, P1PickT);
                Instantiate(P2Pick, P2PickT);
                Instantiate(P3Pick, P3PickT);
                Instantiate(P4Pick, P4PickT);
            }
            */
/* TBD
    public void UseItem1()
    {
        if (_currentPlayer == 0)
        {
            tempPlayer = 0;
        }
        if (_currentPlayer == 1)
        {
            tempPlayer = 1;
        }
        if (_currentPlayer == 2)
        {
            tempPlayer = 2;
        }
        if (_currentPlayer == 3)
        {
            tempPlayer = 3;
        }
        usePlayerItem1 = ItemC.GetItem(_currentPlayer, 0, Item1[tempPlayer]);
        ItemAction = true;
    }

    public void UseItem2() 
    {
        if (_currentPlayer == 0)
        {
            tempPlayer = 0;
        }
        if (_currentPlayer == 1)
        {
            tempPlayer = 1;
        }
        if (_currentPlayer == 2)
        {
            tempPlayer = 2;
        }
        if (_currentPlayer == 3)
        {
            tempPlayer = 3;
        }
        usePlayerItem2 = ItemC.GetItem(_currentPlayer, 1, Item2[tempPlayer]);
        ItemAction = true;
    }
    */
/*&& (ItemAction == true || AbilityAction == true)*/