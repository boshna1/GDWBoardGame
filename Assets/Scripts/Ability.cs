using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Abilites : MonoBehaviour
{
    [SerializeField] private List<Player> _player;
    //initializes player list for board movement and player info in terms of position

    public float _speed;

    //initializes board and text 
    [SerializeField] private Board _board;



    //variables for movement
    Vector2 _currentPos;
    Vector2 _nextPos;

    float _totalTime;
    float _deltaT;

    bool _isMoving;
    bool _gameIsOver;
    bool _turnStarted;

    int _currentPlayer = 0;
    int _tileMovementAmount = 0;

    //Dice script variables and class initialization
    Die _dice = new Die();
    (int, int) Roll;

    //button for rolling
    bool Clicked = false;

    //variable to determine tile type
    public int[] TileType = new int[100];
    int currenttile;
    

}