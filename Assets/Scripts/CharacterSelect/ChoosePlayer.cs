using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class ChoosePlayer : MonoBehaviour
{
    public Text playerText;
    public GameObject[] SpritePFP = new GameObject[12];
    public Transform transform1, transform2, transform3;
    private int currentplayer = 0;
    public static int player1choice, player2choice, player3choice, player4choice;

    static int[] Character = new int[4];

    // Start is called before the first frame update
    void Start()
    {
        //initializes first set of sprites for player 1 to choose
        playerText.text = "Player 1 Choose";
        Instantiate(SpritePFP[0], transform1);
        Instantiate(SpritePFP[1], transform2);
        Instantiate(SpritePFP[2], transform3);
    }

    // Update is called once per frame
    void Update()
    {
        //displays set of sprites depending on what player is choosing
        playerText.text = "Player " + (currentplayer + 1);
        if (currentplayer == 1) 
        {
            Instantiate(SpritePFP[3], transform1);
            Instantiate(SpritePFP[4], transform2);
            Instantiate(SpritePFP[5], transform3);
        }
        if (currentplayer == 2)
        {
            Instantiate(SpritePFP[6], transform1);
            Instantiate(SpritePFP[7], transform2);
            Instantiate(SpritePFP[8], transform3);
        }
        if (currentplayer == 3)
        {
            Instantiate(SpritePFP[9], transform1);
            Instantiate(SpritePFP[10], transform2);
            Instantiate(SpritePFP[11], transform3);
        }
        if (currentplayer == 4)
        {
            SetCharacterType(player1choice, player2choice, player3choice, player4choice);
            SceneManager.LoadScene("MainGame");
        }
    }

    //functions that pass a value depending on what class the player picks and which player
    public void ChooseKnight()
    {
        if (currentplayer == 0) 
        {
            player1choice = 0;
        }
        if (currentplayer == 1)
        {
            player2choice = 3;
        }
        if (currentplayer == 2)
        {
            player3choice = 6;
        }
        if (currentplayer == 3)
        {
            player4choice = 9;
            
        }
        currentplayer++;
    }
    public void ChooseWizard()
    {
        if (currentplayer == 0)
        {
            player1choice = 1;
        }
        if (currentplayer == 1)
        {
            player2choice = 4;
        }
        if (currentplayer == 2)
        {
            player3choice = 7;
        }
        if (currentplayer == 3)
        {
            player4choice = 10;
        }
        currentplayer++;
    }
    public void ChooseThief()
    {
        if (currentplayer == 0)
        {
            player1choice = 2;
        }
        if (currentplayer == 1)
        {
            player2choice = 5;
        }
        if (currentplayer == 2)
        {
            player3choice = 8;
        }
        if (currentplayer == 3)
        {
            player4choice = 11;
        }
        currentplayer++;
    }
    public void SetCharacterType(int type1, int type2, int type3, int type4)
    {
        Character[0] = type1;
        Character[1] = type2;
        Character[2] = type3;
        Character[3] = type4;
    }

    public int[] GetCharacterType()
    {
        return Character;
    }
}
