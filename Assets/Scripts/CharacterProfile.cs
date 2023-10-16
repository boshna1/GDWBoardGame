using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProfile : MonoBehaviour
{
    //holds CharacterSprites
    public GameObject[] CharacterPFPSpr = new GameObject[12];
    //Holds character pfp location on sidebars
    public Transform[] CharacterPFP = new Transform[4];

    [SerializeField] private List<Player> _player;

    //holds character value corresponding to a class
    public int[] Character = new int[4];

    //holds location of each characters abilities
    public Transform[] Char1Ability = new Transform[2];
    public Transform[] Char2Ability = new Transform[2];
    public Transform[] Char3Ability = new Transform[2];
    public Transform[] Char4Ability = new Transform[2];

    //holds ability sprites
    public GameObject[] Abilities = new GameObject[6];

    //holds character sprites for board
    public GameObject[] CharacterPiece = new GameObject[12];
    //holds character position for board
    public Transform[] GamePiece = new Transform[4];

    public GameObject[] Items = new GameObject[12];
    public Transform[] ItemTrans = new Transform[12];

    //class initialization to get class selection variables
    ChoosePlayer Choop = new ChoosePlayer();
 
    // Start is called before the first frame update
    void Start()
    {
        Character = Choop.GetCharacterType();
        for (int x = 0; x <= 3; x++)
        {
            //set of if statements displaying class, abilities and the board piece
            if (Character[x] == 0) 
            {
                Instantiate(CharacterPFPSpr[0], CharacterPFP[0]);
                Instantiate(Abilities[0], Char1Ability[0]);
                Instantiate(Abilities[1],Char1Ability[1]);
                Instantiate(CharacterPiece[0], GamePiece[0]);
            }
            if (Character[x] == 1)
            {
                Instantiate(CharacterPFPSpr[1], CharacterPFP[0]);
                Instantiate(Abilities[2], Char1Ability[0]);
                Instantiate(Abilities[3], Char1Ability[1]);
                Instantiate(CharacterPiece[1], GamePiece[0]);
            }
            if (Character[x] == 2)
            {
                Instantiate(CharacterPFPSpr[2], CharacterPFP[0]);
                Instantiate(Abilities[4], Char1Ability[0]);
                Instantiate(Abilities[5], Char1Ability[1]);
                Instantiate(CharacterPiece[2], GamePiece[0]);

            }

            if (Character[x] == 3)
            {
                Instantiate(CharacterPFPSpr[3], CharacterPFP[1]);
                Instantiate(Abilities[0], Char2Ability[0]);
                Instantiate(Abilities[1], Char2Ability[1]);
                Instantiate(CharacterPiece[3], GamePiece[1]);

            }
            if (Character[x] == 4)
            {
                Instantiate(CharacterPFPSpr[4], CharacterPFP[1]);
                Instantiate(Abilities[2], Char2Ability[0]);
                Instantiate(Abilities[3], Char2Ability[1]);
                Instantiate(CharacterPiece[4], GamePiece[1]);

            }
            if (Character[x] == 5)
            {
                Instantiate(CharacterPFPSpr[5], CharacterPFP[1]);
                Instantiate(Abilities[4], Char2Ability[0]);
                Instantiate(Abilities[5], Char2Ability[1]);
                Instantiate(CharacterPiece[5], GamePiece[1]);

            }

            if (Character[x] == 6)
            {
                Instantiate(CharacterPFPSpr[6], CharacterPFP[2]);
                Instantiate(Abilities[0], Char3Ability[0]);
                Instantiate(Abilities[1], Char3Ability[1]);
                Instantiate(CharacterPiece[6], GamePiece[2]);

            }
            if (Character[x] == 7)
            {
                Instantiate(CharacterPFPSpr[7], CharacterPFP[2]);
                Instantiate(Abilities[2], Char3Ability[0]);
                Instantiate(Abilities[3], Char3Ability[1]);
                Instantiate(CharacterPiece[7], GamePiece[2]);
            }
            if (Character[x] == 8)
            {
                Instantiate(CharacterPFPSpr[8], CharacterPFP[2]);
                Instantiate(Abilities[4], Char3Ability[0]);
                Instantiate(Abilities[5], Char3Ability[1]);
                Instantiate(CharacterPiece[8], GamePiece[2]);
            }

            if (Character[x] == 9)
            {
                    Instantiate(CharacterPFPSpr[9], CharacterPFP[3]);
                Instantiate(Abilities[0], Char4Ability[0]);
                Instantiate(Abilities[1], Char4Ability[1]);
                Instantiate(CharacterPiece[9], GamePiece[3]);
            }
            if (Character[x] == 10)
            {
                Instantiate(CharacterPFPSpr[10], CharacterPFP[3]);
                Instantiate(Abilities[2], Char4Ability[0]);
                Instantiate(Abilities[3], Char4Ability[1]);
                Instantiate(CharacterPiece[10], GamePiece[3]);
            }
            if (Character[x] == 11)
            {
                Instantiate(CharacterPFPSpr[11], CharacterPFP[3]);
                Instantiate(Abilities[4], Char4Ability[0]);
                Instantiate(Abilities[5], Char4Ability[1]);
                Instantiate(CharacterPiece[11], GamePiece[3]);
            }

        }
    }

    

}
