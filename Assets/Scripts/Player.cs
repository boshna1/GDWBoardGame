using System.Collections;
using System.Collections.Generic;
using Unity.Jobs;
using UnityEngine;

public class Player : MonoBehaviour
{
    Vector3 _position;
    public Transform _trans;

    int _currentTile = 1;

    bool _isPlayerTurn;

    int PlayerTilePos = 0;

    private void Start()
    {
        _trans = GetComponent<Transform>();

        _position = _trans.position;
    }

    private void Update()
    {
        _trans.position = _position;

    }

    public Vector2 GetPosition()
    {
        return _position;
    }

    public void SetPosition(Vector2 pos)
    {
        _position = pos;
    }
    public bool GetIsPlayerTurn()
    {
        return _isPlayerTurn;
    }

    public void SetIsPlayerTurn(bool isTurn)
    {
        _isPlayerTurn = isTurn;
    }

    public int GetCurrentTile()
    {
        return _currentTile;

    }

    public void SetCurrentTile(int currentTile)
    {
        _currentTile = currentTile;
    }

    public int GetPlayerTilePos()
    {
        return PlayerTilePos;
    }
    public void AddPlayerTilePos(int ptp)
    {
        PlayerTilePos += ptp;
    }
}
