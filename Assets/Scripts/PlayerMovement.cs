using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;
using static UnityEditor.Experimental.GraphView.GraphView;
using Unity.VisualScripting.ReorderableList;
using System.Threading.Tasks;

public class PlayerMovement : MonoBehaviour
{

    // Start is called before the first frame update
    [SerializeField] private List<Player> _player;
    public float _speed;

    [SerializeField] private Board _board;
    [SerializeField] private Text _text;

    Vector2 _currentPos;
    Vector2 _nextPos;

    float _totalTime;
    float _deltaT;

    bool _isMoving;
    bool _gameIsOver;
    bool _turnStarted;

    int _currentPlayer = 0;
    int _tileMovementAmount;

    Die _dice = new Die();
    (int, int) Roll;

    public Button button;
    bool Clicked = false;

    int[] TileType = new int[100];
    int currenttile;
    void Start()
    {
        _board.initTilePositionRed();
        _board.initTilePositionBlue();
        _board.initTilePositionGreen();
        _board.initTilePositionYellow();
        _text.text = "Clcik to Roll dice";
    }

    void CheckWin()
    {
        if (_gameIsOver && Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("BoardGame");
        }
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
            _text.text = "You rolled a " + Roll.Item1 + " and a " + Roll.Item2;
            button.onClick.AddListener(DiceClick);

            if (_tileMovementAmount == 0 && Clicked == true)
            {

                Roll = _dice.RollDice();
                _tileMovementAmount = Roll.Item1 + Roll.Item2;
                _turnStarted = true;
                Clicked = false;

            }

            if (_tileMovementAmount > 0 && !_isMoving)
            {
                MoveOneTile(_currentPlayer);
                currenttile++;
            }

            if (_isMoving)
            {
                UpdatePosition();
            }
            CheckTileInteract();
            if (_tileMovementAmount == 0 && !_isMoving)
                {
                _text.text = "Click to roll the \ndice";
                    if (_turnStarted)
                    {
                    CheckTileInteract();
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
        void MoveBackOneTile(int player)
        {
            if (player == 0)
            {
            _nextPos = _board.GetTileRedPosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile()-2);
            }
            if (player == 1)
            {
            _nextPos = _board.GetTileBluePosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile()-2);
            }
            if (player == 2)
            {
            _nextPos = _board.GetTileGreenPosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile()-2);
            }
            if (player == 3)
            {
            _nextPos = _board.GetTileYellowPosition()[_player[_currentPlayer].GetCurrentTile()];
            _totalTime = (_nextPos - _currentPos / _speed).magnitude;
            _isMoving = true;
            _player[_currentPlayer].SetCurrentTile(_player[_currentPlayer].GetCurrentTile()-2);
            }
    }

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

    void CheckTileInteract()
    {
        _player[_currentPlayer].AddPlayerTilePos(currenttile);
        int tilespot = _player[_currentPlayer].GetPlayerTilePos();
        int playerspot = GetTileType(tilespot);
        Debug.Log(playerspot);
        Debug.Log(tilespot);
        Debug.Log(currenttile);
        Debug.Log(GetTileType(tilespot));
        currenttile = 0;
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



