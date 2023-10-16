using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.TextCore.Text;
using UnityEngine.UI;

public class InGameMenus : MonoBehaviour
{
    PlayerMovement PM = new PlayerMovement();

    [SerializeField] private List<Player> _player;

    public Transform Dropdown1;
    public Transform Dropdown2;

    public GameObject AbilityDropdown1;
    public GameObject TargetDrop;

    public GameObject ItemDropdown1;

    public GameObject[] Ability = new GameObject[6];
    public Transform[] AbilityTrans = new Transform[2];

    public GameObject[] Item = new GameObject[9];
    public Transform[] ItemTrans = new Transform[3];

    public GameObject[] PlayerPFP = new GameObject[4];
    public Transform[] PlayerTrans = new Transform[4];

    public Button AbilityBut1;
    public Button AbilityBut2;

    int AbilityUse;

    public Button ItemBut1;
    public Button ItemBut2;
    public Button ItemBut3;

    bool SelfTarget;

    int Target;

    public Button PlayerI1,PlayerI2,PlayerI3,PlayerI4;

    public int[] Character = new int[4];

    ChoosePlayer Choop = new ChoosePlayer();

    bool hit = false;

    int currentplayer;

    int Roll3;

    public GameObject[] SpritePFP = new GameObject[12];

    GameObject tempAbility, tempAbility2, tempDrop1, tempDrop2, tempPFP1, tempPFP2, tempPFP3, tempPFP4;

    public Button BackButton, BackButton2;

    public Text BackBut, BackBut2;

    public Text DropText1, DropText2;

    public GameObject Empty;

    public List<GameObject> Items = new List<GameObject>();

    public ShopScript SC = new ShopScript();

    public void Start()
    {
        BackBut.text = "";
        BackBut2.text = "";
        DropText1.text = "";
        DropText2.text = "";

    }
    public void AbilityDropdown()
    {
        tempDrop1 = Instantiate(AbilityDropdown1, Dropdown1);
        BackBut.text = "Back";
        DropText1.text = "Ability";
        Character = Choop.GetCharacterType();
        for (int x = 0; x <= 3; x++)
        {
            if  (Character[x] == 0 && _player[0].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[0], AbilityTrans[0]);
                tempAbility2 =Instantiate(Ability[1], AbilityTrans[1]);
                PlayerPFP[0] = SpritePFP[0];
            }
            if (Character[x] == 1 && _player[0].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[2], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[3], AbilityTrans[1]);
                PlayerPFP[0] = SpritePFP[1];
            }
            if (Character[x] == 2 && _player[0].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[4], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[5], AbilityTrans[1]);
                PlayerPFP[0] = SpritePFP[2];

            }

            if (Character[x] == 3 && _player[1].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[0], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[1], AbilityTrans[1]);
                PlayerPFP[1] = SpritePFP[3];

            }
            if (Character[x] == 4 && _player[1].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[2], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[3], AbilityTrans[1]);
                PlayerPFP[1] = SpritePFP[4];
            }
            if (Character[x] == 5 && _player[1].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[4], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[5], AbilityTrans[1]);
                PlayerPFP[1] = SpritePFP[5];
            }
            if (Character[x] == 6 && _player[2].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[0], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[0], AbilityTrans[0]);
                PlayerPFP[2] = SpritePFP[6];
            }

            if (Character[x] == 7 && _player[2].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[2], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[3], AbilityTrans[1]);
                PlayerPFP[2] = SpritePFP[7];
            }
            if (Character[x] == 8 && _player[2].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[4], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[5], AbilityTrans[1]);
                PlayerPFP[2] = SpritePFP[8];
            }

            if (Character[x] == 9 && _player[3].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[0], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[1], AbilityTrans[0]);
                PlayerPFP[3] = SpritePFP[9];
            }
            if (Character[x] == 10 && _player[3].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[2], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[3], AbilityTrans[1]);
                PlayerPFP[3] = SpritePFP[10];
            }
            if (Character[x] == 11 && _player[3].GetIsPlayerTurn() == true)
            {
                tempAbility = Instantiate(Ability[4], AbilityTrans[0]);
                tempAbility2 = Instantiate(Ability[5], AbilityTrans[1]);
                PlayerPFP[3] = SpritePFP[11];
            }
            if (Character[x] == 0)
            {
                PlayerPFP[0] = SpritePFP[0];
            }
            if (Character[x] == 1)
            {
                PlayerPFP[0] = SpritePFP[0];
            }
            if (Character[x] == 2)
            {
                PlayerPFP[0] = SpritePFP[0];
            }
            if (Character[x] == 3)
            {
                PlayerPFP[1] = SpritePFP[3];
            }
            if (Character[x] == 4)
            {
                PlayerPFP[1] = SpritePFP[4];
            }
            if (Character[x] == 5)
            {
                PlayerPFP[1] = SpritePFP[5];
            }
            if (Character[x] == 6)
            {
                PlayerPFP[2] = SpritePFP[6];
            }
            if (Character[x] == 7)
            {
                PlayerPFP[2] = SpritePFP[7];
            }
            if (Character[x] == 8)
            {
                PlayerPFP[2] = SpritePFP[8];
            }
            if (Character[x] == 9)
            {
                PlayerPFP[3] = SpritePFP[9];
            }
            if (Character[x] == 10)
            {
                PlayerPFP[3] = SpritePFP[10];
            }
            if (Character[x] == 11)
            {
                PlayerPFP[3] = SpritePFP[11];
            }
        }
        AbilityBut1.GetComponent<Button>().enabled = true;
        AbilityBut2.GetComponent<Button>().enabled = true;
        BackButton.GetComponent<Button>().enabled = true;
    }

   
    public void TargetDropdown()
    {
        BackButton2.GetComponent<Button>().enabled = true;
        BackBut2.text = "Back";
        DropText2.text = "Target";
        tempDrop2 = Instantiate(TargetDrop,Dropdown2);
        tempPFP1 = Instantiate(PlayerPFP[0], PlayerTrans[0]);
        tempPFP2 = Instantiate(PlayerPFP[1], PlayerTrans[1]);
        tempPFP3 = Instantiate(PlayerPFP[2], PlayerTrans[2]);
        tempPFP4 = Instantiate(PlayerPFP[3], PlayerTrans[3]);
        PlayerI1.GetComponent<Button>().enabled = true;
        PlayerI2.GetComponent<Button>().enabled = true;
        PlayerI3.GetComponent<Button>().enabled = true;
        PlayerI4.GetComponent<Button>().enabled = true;
        AbilityBut1.GetComponent<Button>().enabled = false;
        AbilityBut2.GetComponent<Button>().enabled = false;
        ItemBut1.GetComponent<Button>().enabled = false;
        ItemBut2.GetComponent<Button>().enabled = false;
        ItemBut3.GetComponent<Button>().enabled = false;
        BackButton.GetComponent<Button>().enabled = true;

    }

    //Casts ability based on which ability used and target and if they are immune
    public void Cast()
    {
        //bonk
        if ((Character[0] == 0 || Character[1] == 3 || Character[2] == 6 || Character[3] == 9) && AbilityUse == 1 && hit == false && _player[Target].GetisImmune() == false)
        {
            _player[Target].AddSpeed(-(_player[Target].GetSpeed()/2));
        }
        //block
        if ((Character[0] == 0 || Character[1] == 3 || Character[2] == 6 || Character[3] == 9) && AbilityUse == 2 && hit == false)
        {
            _player[Target].SetisImmune(true);
        }
        //Wind blast
        if ((Character[0] == 1 || Character[1] == 4 || Character[2] == 7 || Character[3] == 10) && AbilityUse == 1 && hit == false && _player[Target].GetisImmune() == false)
        {
            _player[Target].SetPosition(_player[Target].GetPosition() + new Vector2((-2f),0));
            _player[Target].SetCurrentTile(_player[Target].GetCurrentTile() - 2);
            _player[Target].AddPlayerTilePos(-2);
        }
        //FrostBeam
        if ((Character[0] == 1 || Character[1] == 4 || Character[2] == 7 || Character[3] == 10) && AbilityUse == 2 && hit == false && _player[Target].GetisImmune() == false)
        {
            _player[Target].AddSpeed(-(_player[Target].GetSpeed() / 2));
        }
        //steal
        if ((Character[0] == 2 || Character[1] == 5 || Character[2] == 8 || Character[3] == 11) && AbilityUse == 1 && hit == false && _player[Target].GetisImmune() == false)
        {
            _player[Target].AddGold(-5);
            _player[currentplayer].AddGold(5);
        }
        //dash
        if ((Character[0] == 2 || Character[1] == 5 || Character[2] == 8 || Character[3] == 11) && AbilityUse == 2 && hit == false)
        {
            PM.SetRoll3(Random.Range(1, 6));
        }
        AbilityUse = 0;
        hit = true;
        tempAbility.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempAbility2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP3.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP4.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempDrop1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempDrop2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        AbilityBut1.GetComponent<Button>().enabled = false;
        AbilityBut2.GetComponent<Button>().enabled = false;
        PlayerI1.GetComponent<Button>().enabled = false;
        PlayerI2.GetComponent<Button>().enabled = false;
        PlayerI3.GetComponent<Button>().enabled = false;
        PlayerI4.GetComponent<Button>().enabled = false;
        BackButton.GetComponent<Button>().enabled = false;
        BackButton2.GetComponent<Button>().enabled = false;
        DropText1.text = "";
        DropText2.text = "";
        BackBut.text = "";
        BackBut2.text = "";
        tempAbility.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempAbility2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP3.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP4.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempDrop1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempDrop2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        AbilityBut1.GetComponent<Button>().enabled = false;
        AbilityBut2.GetComponent<Button>().enabled = false;
        PlayerI1.GetComponent<Button>().enabled = false;
        PlayerI2.GetComponent<Button>().enabled = false;
        PlayerI3.GetComponent<Button>().enabled = false;
        PlayerI4.GetComponent<Button>().enabled = false;
        BackButton.GetComponent<Button>().enabled = false;
        BackButton2.GetComponent<Button>().enabled = false;
    }
   
    public void UseAbility1()
    {
        AbilityUse = 1;
        PlayerI1.GetComponent<Button>().enabled = true;
        PlayerI2.GetComponent<Button>().enabled = true;
        PlayerI3.GetComponent<Button>().enabled = true;
        PlayerI4.GetComponent<Button>().enabled = true;
        AbilityBut1.GetComponent<Button>().enabled = false;
        AbilityBut2.GetComponent<Button>().enabled = false;
    }
    public void UseAbility2()
    {
        AbilityUse = 2;
        PlayerI1.GetComponent<Button>().enabled = true;
        PlayerI2.GetComponent<Button>().enabled = true;
        PlayerI3.GetComponent<Button>().enabled = true;
        PlayerI4.GetComponent<Button>().enabled = true;
        AbilityBut1.GetComponent <Button>().enabled = false;
        AbilityBut2.GetComponent<Button>().enabled = false;
    }
    public void SetPlayer1Target()
    {
        Target = 0;
        PlayerI1.GetComponent<Button>().enabled = false;
        PlayerI2.GetComponent<Button>().enabled = false;
        PlayerI3.GetComponent<Button>().enabled = false;
        PlayerI4.GetComponent<Button>().enabled = false;
        hit = false;
    }
    public void SetPlayer2Target()
    {
        Target = 1;
        for (int i = 0; i <= 3; i++)
            PlayerI1.GetComponent<Button>().enabled = false;
        PlayerI2.GetComponent<Button>().enabled = false;
        PlayerI3.GetComponent<Button>().enabled = false;
        PlayerI4.GetComponent<Button>().enabled = false;
        hit = false;
    }
    public void SetPlayer3Target()
    {
        Target = 2;
        for (int i = 0; i <= 3; i++)
            PlayerI1.GetComponent<Button>().enabled = false;
        PlayerI2.GetComponent<Button>().enabled = false;
        PlayerI3.GetComponent<Button>().enabled = false;
        PlayerI4.GetComponent<Button>().enabled = false;
        hit = false;
    }
    public void SetPlayer4Target()
    {
        Target = 3;
        for (int i = 0; i <= 3; i++)
            PlayerI1.GetComponent<Button>().enabled = false;
        PlayerI2.GetComponent<Button>().enabled = false;
        PlayerI3.GetComponent<Button>().enabled = false;
        PlayerI4.GetComponent<Button>().enabled = false;
        hit = false;
    }
    public void GoBackDrop1()
    {
        tempDrop1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempAbility.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempAbility2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        AbilityBut1.GetComponent<Button>().enabled = false;
        AbilityBut2.GetComponent<Button>().enabled = false;
        BackButton.GetComponent<Button>().enabled = false;
        DropText1.text = "";
        DropText2.text = "";
        BackBut.text = "";
        BackBut2.text = "";
        tempDrop2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempAbility.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempAbility2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP3.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP4.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempDrop1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempDrop2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        AbilityBut1.GetComponent<Button>().enabled = false;
        AbilityBut2.GetComponent<Button>().enabled = false;
        PlayerI1.GetComponent<Button>().enabled = false;
        PlayerI2.GetComponent<Button>().enabled = false;
        PlayerI3.GetComponent<Button>().enabled = false;
        PlayerI4.GetComponent<Button>().enabled = false;
        BackButton.GetComponent<Button>().enabled = false;
        BackButton2.GetComponent<Button>().enabled = false;
    }
    public void GoBackDrop2()
    {
        tempAbility.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempAbility2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP3.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP4.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempDrop1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        
        AbilityBut1.GetComponent<Button>().enabled = false;
        AbilityBut2.GetComponent<Button>().enabled = false;
        PlayerI1.GetComponent<Button>().enabled = false;
        PlayerI2.GetComponent<Button>().enabled = false;
        PlayerI3.GetComponent<Button>().enabled = false;
        PlayerI4.GetComponent<Button>().enabled = false;
        BackButton.GetComponent<Button>().enabled = false;
        BackButton2.GetComponent<Button>().enabled = false;
        DropText1.text = "";
        DropText2.text = "";
        BackBut.text = "";
        BackBut2.text = "";
        tempDrop2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempAbility.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempAbility2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP3.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempPFP4.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempDrop1.GetComponent<SpriteRenderer>().sortingOrder = 0;
        tempDrop2.GetComponent<SpriteRenderer>().sortingOrder = 0;
        AbilityBut1.GetComponent<Button>().enabled = false;
        AbilityBut2.GetComponent<Button>().enabled = false;
        PlayerI1.GetComponent<Button>().enabled = false;
        PlayerI2.GetComponent<Button>().enabled = false;
        PlayerI3.GetComponent<Button>().enabled = false;
        PlayerI4.GetComponent<Button>().enabled = false;
        BackButton.GetComponent<Button>().enabled = false;
        BackButton2.GetComponent<Button>().enabled = false;
    }
    public void ItemDropDown()
    {
        
        tempDrop1 = Instantiate(ItemDropdown1, Dropdown1);
        tempAbility = null;
        tempAbility2 = null;
        BackBut.text = "Back";
        DropText1.text = "Item";
        currentplayer = PM.GetCurrentPlayer();
        if (currentplayer == 0)
        {
            Items = SC.GetInv1();
            Instantiate(Items.ElementAt(0), ItemTrans[0]);
            Instantiate(Items.ElementAt(1), ItemTrans[1]);
            Instantiate(Items.ElementAt(2), ItemTrans[2]);
        }
        if (currentplayer == 1)
        {
            Items = SC.GetInv2();
            Instantiate(Items.ElementAt(0), ItemTrans[0]);
            Instantiate(Items.ElementAt(1), ItemTrans[1]);
            Instantiate(Items.ElementAt(2), ItemTrans[2]);
        }
        if (currentplayer == 2)
        {
            Items = SC.GetInv3();
            Instantiate(Items.ElementAt(0), ItemTrans[0]);
            Instantiate(Items.ElementAt(1), ItemTrans[1]);
            Instantiate(Items.ElementAt(2), ItemTrans[2]);
        }
        if (currentplayer == 3)
        {
            Items = SC.GetInv4();
            Instantiate(Items.ElementAt(0), ItemTrans[0]);
            Instantiate(Items.ElementAt(1), ItemTrans[1]);
            Instantiate(Items.ElementAt(2), ItemTrans[2]);
        }
    }
}
    


