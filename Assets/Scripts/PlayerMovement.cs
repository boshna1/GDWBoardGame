using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static UnityEditor.Experimental.GraphView.GraphView;
using Unity.VisualScripting.ReorderableList;
using System.Threading.Tasks;
using System;
using Unity.VisualScripting;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update

    //initializes player list for board movement and player info in terms of position
    [SerializeField] private List<Player> _player;
    public float _speed;

    //initializes board and text 
    [SerializeField] private Board _board;
    [SerializeField] private Text _text;

    //variables for movement
    Vector2 _currentPos;
    Vector2 _nextPos;

    float _totalTime;
    float _deltaT;

    bool _isMoving;
    bool _gameIsOver;
    bool _turnStarted;

    int _currentPlayer = 0;
    int _tileMovementAmount;

    //Dice script variables and class initialization
    Die _dice = new Die();
    (int, int) Roll;

    //button for rolling
    public Button button;
    bool Clicked = false;

    //variable to determine tile type
    public int[] TileType = new int[100];
    int currenttile;

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

    void Start()
    {
        //initializes piece position
        _board.initTilePositionRed();
        _board.initTilePositionBlue();
        _board.initTilePositionGreen();
        _board.initTilePositionYellow();
        _text.text = "Choose an action";
    }

    void CheckWin()
    {
        if ((_player[0].GetCurrentTile() == 100 || _player[1].GetCurrentTile() == 100 && !_isMoving))
        {
            _gameIsOver = true;
            _text.text = $"Game Over! Player {_currentPlayer + 1} Wins! Press 'Space' to play again!";
        }
    }

    // Update is called once per frame
    void Update()
    {
        CheckWin();

        if (!_gameIsOver)
        {
            _currentPos = _player[_currentPlayer].GetPosition();

            if (_currentPlayer == 0)
            {
                _text.color = Color.red;
            }
            if (_currentPlayer == 1)
            {
                _text.color = Color.blue;
            }
            if (_currentPlayer == 2)
            {
                _text.color = Color.green;
            }
            if (_currentPlayer == 3)
            {
                _text.color = Color.yellow;
            }
            _text.text = "Choose an Action";
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
            
            if (_tileMovementAmount == 0 && Clicked == true /*&& (ItemAction == true || AbilityAction == true)*/)
            {
                //rolls die
                Roll = _dice.RollDice();
                _tileMovementAmount = Roll.Item1 + Roll.Item2;
                _turnStarted = true;
                Clicked = false;

            }

            if (_tileMovementAmount > 0 && !_isMoving)
            {
                //moves player and counts amount moved
                MoveOneTile(_currentPlayer);
                currenttile++;
            }

            if (_isMoving)
            {
                UpdatePosition();
            }

            if (_tileMovementAmount == 0 && !_isMoving)
                {
                _text.text = "Choose an Action";


                if (_turnStarted)
                    { 
                        _turnStarted = false;

                    if (_currentPlayer == 3 && !_isMoving && _turnStarted == false)
                        {
                            _currentPlayer = 0;

                        }
                        else
                            _currentPlayer++;
                    }

                }
            }
        }

        void UpdatePosition()
        {
            _deltaT += Time.deltaTime / _totalTime;

            if (_deltaT < 0f)
            {
                _deltaT = 0f;
            }

            if (_deltaT >= 1f || _nextPos == _currentPos)
            {
                _isMoving = false;
                _tileMovementAmount--;
                _deltaT = 0f;
            }

            _player[_currentPlayer].SetPosition(Vector2.Lerp(_currentPos, _nextPos, _deltaT));
        }


        void MoveOneTile(int player)
        {
            if (player == 0)
            { 
            _nextPos = _board.GetTileRedPosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile() + 1);
            }
            if (player == 1)
            {
            _nextPos = _board.GetTileBluePosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile() + 1);
            }
            if (player == 2)
            {
            _nextPos = _board.GetTileGreenPosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile() + 1);
            }
            if (player == 3)
            {
            _nextPos = _board.GetTileYellowPosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile() + 1);
            }
        }
        
        //Attempted to use but was unsuccessful
        void MoveBackOneTile(int player)
        {
            if (player == 0)
            {
            _nextPos = _board.GetTileRedPosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile());
            }
            if (player == 1)
            {
            _nextPos = _board.GetTileBluePosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile());
            }
            if (player == 2)
            {
            _nextPos = _board.GetTileGreenPosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile());
            }
            if (player == 3)
            {
            _nextPos = _board.GetTileYellowPosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile());
            }
    }

    //linked to roll butotn
    public void DiceClick()
    {
        Clicked = true;
    }

    public void SetTileType(int i,int type)
    {
        TileType[i] = type;
    }
    public int GetTileType(int i)
    {
        return TileType[i];
    }

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

    //Attempted to use, had many problems with using. Moving too many times, not moving at all etc.
    void CheckTileInteract()
    {
        _player[_currentPlayer].AddPlayerTilePos(currenttile);
        int tilespot = _player[_currentPlayer].GetPlayerTilePos(); // determines player position 
        int playerspot = GetTileType(tilespot); //determines tile type player is on
        Debug.Log(playerspot);
        Debug.Log(tilespot);
        Debug.Log(currenttile);
        Debug.Log(GetTileType(tilespot));
        currenttile = 0;
        // if statements executing different effects depending on tile player lands on
        if (playerspot == 0)
        {
        }
        if (playerspot == 2)
        {

        }
        if (playerspot == 3)
        {
            MoveBackOneTile(_currentPlayer);
            MoveBackOneTile(_currentPlayer);
            playerspot = 0;
        }
        if (playerspot == 4)
        {
            MoveOneTile(_currentPlayer);
            MoveOneTile(_currentPlayer);
            playerspot = 0;
        }
        if (playerspot == 5)
        {

        }
        if (playerspot == 6)
        {

        }
        if (playerspot == 7)
        {

        }

    }
}



