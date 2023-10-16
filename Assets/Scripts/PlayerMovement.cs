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
using System.Numerics;
using Vector2 = UnityEngine.Vector2;
using Random = UnityEngine.Random;
using UnityEditorInternal.Profiling.Memory.Experimental;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update

    //initializes player list for board movement and player info in terms of position
    [SerializeField] private List<Player> _player;
    public float _speed;

    [SerializeField] private ShopScript SS = new ShopScript();

    //initializes board and text 
    [SerializeField] private Board _board;
    [SerializeField] private Text _text,_text2;


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
    public Button button;
    bool Clicked = false;

    //variable to determine tile type
    public int[] TileType = new int[100];
    int currenttile;

    int TargetPlayer;
    public bool GetKey;

    int Roll3;

    int dupe;

    public bool immune;

    int tilespot;
    int playerspot;

    bool Interacted;

    bool GetItem;

    bool UseUtility;

    public GameObject[] Items = new GameObject[7];

    public Button AbilityBut, ItemBut;
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
        if ((_player[0].GetCurrentTile() == 99 || _player[1].GetCurrentTile() == 99 || _player[2].GetCurrentTile() == 99 || _player[3].GetCurrentTile() == 99) && !_isMoving)
        {
            _gameIsOver = true;
            _text.text = $"Game Over! Player {_currentPlayer + 1} Wins!";
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
                _text2.color = Color.red;
            }
            if (_currentPlayer == 1)
            {
                _text.color = Color.blue;
                _text2.color = Color.blue;
            }
            if (_currentPlayer == 2)
            {
                _text.color = Color.green;
                _text2.color = Color.green;
            }
            if (_currentPlayer == 3)
            {
                _text.color = Color.yellow;
                _text2.color = Color.yellow;
            }
            _text.text = "Choose an Action";
            _text2.text = "You rolled a " + Roll.Item1 + " and a " + Roll.Item2;
            
            if (_tileMovementAmount == 0 && Clicked == true)
            {
                //rolls die
                Roll = _dice.RollDice();
                Debug.Log(Roll);
                _tileMovementAmount = Roll.Item1 + Roll.Item2 + Roll3 + _player[_currentPlayer].GetSpeed();
                if (_player[_currentPlayer].GetSpeed() < 1)
                {
                    _player[_currentPlayer].AddSpeed(1);
                }
                _turnStarted = true;
                Clicked = false;
                Interacted = false;
                SetAbilityFalseButton();
                SetItemFalseButton();

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

            if (_tileMovementAmount == 0 && _turnStarted == true && Interacted == false)
            {
                CheckTileInteract();
                if (playerspot == 1)
                {
                    SS.DisplayItems();
                }
                if (playerspot == 3)
                {
                    _player[_currentPlayer].SetPosition(_player[_currentPlayer].GetPosition() + new Vector2(-1f, 0f));
                    _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile() - 1);
                    _player[_currentPlayer].AddPlayerTilePos(-1);
                }
                if (_player[_currentPlayer].GetPosition().x < -5)
                {
                    _player[_currentPlayer].SetPosition(_player[_currentPlayer].GetPosition() + new Vector2(1f, -1f));
                }
                if (_player[_currentPlayer].GetPosition().x > 5)
                {
                    _player[_currentPlayer].SetPosition(_player[_currentPlayer].GetPosition() + new Vector2(-1f, -1f));

                    _isMoving = false;
                }
                if (playerspot == 4)
                {
                    _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile() + 1);
                    _player[_currentPlayer].AddPlayerTilePos(1);
                    _tileMovementAmount = 1;
                    _isMoving = false;
                }
                if (playerspot == 5)
                {
                    _player[_currentPlayer].AddGold(-3);
                }
                if (playerspot == 6 && GetItem == true)
                {
                    if (_currentPlayer == 0)
                    {
                        int randomItem = UnityEngine.Random.Range(0, 5);
                        SS.AddToInventory1(Items[randomItem]);
                    }
                    if (_currentPlayer == 1)
                    {
                        int randomItem = UnityEngine.Random.Range(0, 5);
                        SS.AddToInventory2(Items[randomItem]);
                    }
                    if (_currentPlayer == 2)
                    {
                        int randomItem = UnityEngine.Random.Range(0, 5);
                        SS.AddToInventory1(Items[randomItem]);
                    }
                    if (_currentPlayer == 3)
                    {
                        int randomItem = UnityEngine.Random.Range(0, 5);
                        SS.AddToInventory4(Items[randomItem]);
                    }
                    GetItem = true;

                }
                if (playerspot == 7)
                {
                    _player[_currentPlayer].AddGold(3);
                }
                playerspot = 0;
                Interacted = true;

            }

            if (_tileMovementAmount == 0 && !_isMoving && Interacted == true)
            {

                _text.text = "Choose an Action";
                

                if (_turnStarted)
                {
                    _turnStarted = false;
                    Interacted = false;
                    _player[_currentPlayer].SetisImmune(false);
                    _player[_currentPlayer].SetIsPlayerTurn(false);

                    if (_currentPlayer == 3 && !_isMoving)
                    {
                        _currentPlayer = 0;
                    }
                    else
                        _currentPlayer++;
                }
                Debug.Log(_currentPlayer);
                SetCurrentPlayer(_currentPlayer );
                _player[_currentPlayer].SetIsPlayerTurn(true);
                GetItem = false;
                SetAbilityTrueButton();
                SetItemTrueButton();
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
            _player[0].SetCurrentTile(_player[_currentPlayer].GetCurrentTile() + 1);
        }
        if (player == 1)
        {
            _nextPos = _board.GetTileBluePosition()[_player[1].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[1].SetCurrentTile(_player[1].GetCurrentTile() + 1);
        }
        if (player == 2)
        {
            _nextPos = _board.GetTileGreenPosition()[_player[2].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[2].SetCurrentTile(_player[2].GetCurrentTile() + 1);
        }
        if (player == 3)
        {
            _nextPos = _board.GetTileYellowPosition()[_player[3].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[3].SetCurrentTile(_player[3].GetCurrentTile() + 1);
        }
    }

    //linked to roll butotn
    public void DiceClick()
    {
        Clicked = true;
        Debug.Log("click");
    }

    public void SetTileType(int i, int type)
    {
        TileType[i] = type;
    }
    public int GetTileType(int i)
    {
        return TileType[i];
    }



    //Attempted to use, had many problems with using. Moving too many times, not moving at all etc.
    void CheckTileInteract()
    {
        _player[_currentPlayer].AddPlayerTilePos(currenttile);
        tilespot = _player[_currentPlayer].GetPlayerTilePos(); // determines player position 
        playerspot = GetTileType(tilespot); //determines tile type player is on
        Debug.Log(playerspot);
        Debug.Log(tilespot);
        Debug.Log(currenttile);
        Debug.Log(GetTileType(tilespot));
        currenttile = 0;
        
    }
   
    public void SetRoll3(int rolled)
    {
        Roll3 = rolled;
    }

    public void SetCurrentPlayer(int input)
    {
        _currentPlayer = input;
    }
    public int GetCurrentPlayer()
    {
        return _currentPlayer;
    }

    public void SetAbilityFalseButton()
    {
        AbilityBut.GetComponent<Button>().enabled = false;
    }

    public void SetItemFalseButton()
    {
        ItemBut.GetComponent<Button>().enabled = false;
    }

    public void SetAbilityTrueButton()
    {
        AbilityBut.GetComponent<Button>().enabled = true;
    }

    public void SetItemTrueButton()
    {
        ItemBut.GetComponent<Button>().enabled = true;
    }
}




