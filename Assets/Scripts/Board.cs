using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

[System.Serializable]
public class Board : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private Transform _initialTransform;

    Vector2[] _tilepositionRed = new Vector2[100];
    Vector2[] _tilepositionBlue = new Vector2[100];
    Vector2[] _tilepositionGreen = new Vector2[100];
    Vector2[] _tilepositionYellow = new Vector2[100];
    public Vector2[] GetTileRedPosition()
    {
        return _tilepositionRed;
    }
    public Vector2[] GetTileBluePosition()
    {
        return _tilepositionBlue;
    }
    public Vector2[] GetTileGreenPosition()
    {
        return _tilepositionGreen;
    }
    public Vector2[] GetTileYellowPosition()
    {
        return _tilepositionYellow;
    }

    public void initTilePositionRed()
    {
        bool reverse = false;
        _tilepositionRed[0] = new Vector2(_initialTransform.position.x - 4.8f, _initialTransform.position.y - 4.15f);

        for (int i = 1; i < 100; i++)
        {
            if (i % 10 == 0)
            {
                _tilepositionRed[i] = _tilepositionRed[i - 1] + new Vector2(0f, 1f);
            }

            else if (!reverse)
            {
                _tilepositionRed[i] = _tilepositionRed[i - 1] + new Vector2(1f, 0f);
            }
            else if (reverse)
            {
                _tilepositionRed[i] = _tilepositionRed[i - 1] + new Vector2(-1f, 0f);
            }
            if ((i + 1) % 10 == 0)
            {
                reverse = !reverse;
            }
        }
    }
    public void initTilePositionBlue()
    {
        bool reverse = false;
        _tilepositionBlue[0] = new Vector2(_initialTransform.position.x - 4.15f, _initialTransform.position.y - 4.8f);

        for (int i = 1; i < 100; i++)
        {
            if (i % 10 == 0)
            {
                _tilepositionBlue[i] = _tilepositionBlue[i - 1] + new Vector2(0f, 1f);
            }

            else if (!reverse)
            {
                _tilepositionBlue[i] = _tilepositionBlue[i - 1] + new Vector2(1f, 0f);
            }
            else if (reverse)
            {
                _tilepositionBlue[i] = _tilepositionBlue[i - 1] + new Vector2(-1f, 0f);
            }
            if ((i + 1) % 10 == 0)
            {
                reverse = !reverse;
            }
        }
    }
    public void initTilePositionYellow()
    {
        bool reverse = false;
        _tilepositionYellow[0] = new Vector2(_initialTransform.position.x - 4.85f, _initialTransform.position.y - 4.85f);

        for (int i = 1; i < 100; i++)
        {
            if (i % 10 == 0)
            {
                _tilepositionYellow[i] = _tilepositionYellow[i - 1] + new Vector2(0f, 1f);
            }

            else if (!reverse)
            {
                _tilepositionYellow[i] = _tilepositionYellow[i - 1] + new Vector2(1f, 0f);
            }
            else if (reverse)
            {
                _tilepositionYellow[i] = _tilepositionYellow[i - 1] + new Vector2(-1f, 0f);
            }
            if ((i + 1) % 10 == 0)
            {
                reverse = !reverse;
            }
        }
    }
    public void initTilePositionGreen()
    {
        bool reverse = false;
        _tilepositionGreen[0] = new Vector2(_initialTransform.position.x - 4.15f, _initialTransform.position.y - 4.15f);

        for (int i = 1; i < 100; i++)
        {
            if (i % 10 == 0)
            {
                _tilepositionGreen[i] = _tilepositionGreen[i - 1] + new Vector2(0f, 1f);
            }

            else if (!reverse)
            {
                _tilepositionGreen[i] = _tilepositionGreen[i - 1] + new Vector2(1f, 0f);
            }
            else if (reverse)
            {
                _tilepositionGreen[i] = _tilepositionGreen[i - 1] + new Vector2(-1f, 0f);
            }
            if ((i + 1) % 10 == 0)
            {
                reverse = !reverse;
            }
        }
    }
}
