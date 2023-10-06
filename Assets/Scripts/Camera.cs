using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Experimental.GraphView.GraphView;

public class Camera : MonoBehaviour
{
    [SerializeField] private List<Player> _player;
    Transform camerapos;
    bool playerturn = true;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (playerturn == true)
        {
            
        }
    }
}
