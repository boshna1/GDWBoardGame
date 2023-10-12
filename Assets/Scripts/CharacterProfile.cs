using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterProfile : MonoBehaviour
{
    public GameObject[] CharacterPFPSpr = new GameObject[11];
    public Transform[] CharacterPFP = new Transform[3];

    public int[] Character = new int[11];

    public Transform[] Char1Ability = new Transform[1];
    public Transform[] Char2Ability = new Transform[1];
    public Transform[] Char3Ability = new Transform[1];
    public Transform[] Char4Ability = new Transform[1];

    public GameObject[] Items = new GameObject[8];
    public GameObject[] Abilities = new GameObject[5];

    public Transform[] Char1Item = new Transform[2];
    public Transform[] Char2Item = new Transform[2];        
    public Transform[] Char3Item = new Transform[2];
    public Transform[] Char4Item = new Transform[2];
 
    // Start is called before the first frame update
    void Start()
    {
        for (int x = 0; x <= 9; x++)
        {
            if (Character[x] == 0) 
            {
                Instantiate(CharacterPFPSpr[0], CharacterPFP[0]);
                Instantiate(Abilities[0], Char1Ability[0]);
                Instantiate(Abilities[1],Char1Ability[1]);
            }
            if (Character[x] == 1)
            {
                Instantiate(CharacterPFPSpr[1], CharacterPFP[0]);
                Instantiate(Abilities[2], Char1Ability[0]);
                Instantiate(Abilities[3], Char1Ability[1]);
            }
            if (Character[x] == 2)
            {
                Instantiate(CharacterPFPSpr[2], CharacterPFP[0]);
                Instantiate(Abilities[4], Char1Ability[0]);
                Instantiate(Abilities[5], Char1Ability[1]);

            }

            if (Character[x] == 3)
            {
                Instantiate(CharacterPFPSpr[3], CharacterPFP[1]);
                Instantiate(Abilities[0], Char2Ability[0]);
                Instantiate(Abilities[1], Char2Ability[1]);

            }
            if (Character[x] == 4)
            {
                    Instantiate(CharacterPFPSpr[4], CharacterPFP[1]);
                Instantiate(Abilities[2], Char2Ability[0]);
                Instantiate(Abilities[3], Char2Ability[1]);

            }
            if (Character[x] == 5)
            {
                    Instantiate(CharacterPFPSpr[5], CharacterPFP[1]);
                Instantiate(Abilities[4], Char2Ability[0]);
                Instantiate(Abilities[5], Char2Ability[1]);

            }

            if (Character[x] == 6)
            {
                Instantiate(CharacterPFPSpr[6], CharacterPFP[2]);
                Instantiate(Abilities[0], Char3Ability[0]);
                Instantiate(Abilities[1], Char3Ability[1]);

            }
            if (Character[x] == 7)
            {
                Instantiate(CharacterPFPSpr[7], CharacterPFP[2]);
                Instantiate(Abilities[2], Char3Ability[0]);
                Instantiate(Abilities[3], Char3Ability[1]);

            }
            if (Character[x] == 8)
            {
                Instantiate(CharacterPFPSpr[8], CharacterPFP[2]);
                Instantiate(Abilities[4], Char3Ability[0]);
                Instantiate(Abilities[5], Char3Ability[1]);

            }

            if (Character[x] == 9)
            {
                    Instantiate(CharacterPFPSpr[9], CharacterPFP[3]);
                Instantiate(Abilities[0], Char4Ability[0]);
                Instantiate(Abilities[1], Char4Ability[1]);

            }

            if (Character[x] == 10)
            {
                Instantiate(CharacterPFPSpr[10], CharacterPFP[3]);
                Instantiate(Abilities[2], Char4Ability[0]);
                Instantiate(Abilities[3], Char4Ability[1]);

            }

            if (Character[x] == 11)
            {
                Instantiate(CharacterPFPSpr[11], CharacterPFP[3]);
                Instantiate(Abilities[4], Char4Ability[0]);
                Instantiate(Abilities[5], Char4Ability[1]);

            }

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
