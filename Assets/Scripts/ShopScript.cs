using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;
using static UnityEditor.Progress;

public class ShopScript : MonoBehaviour
{
    public GameObject shop;
    private GameObject tempShop; //duplicate shop
    public GameObject[] items;
    public GameObject[] displayItems;

    private List<Vector2> displayLocations = new List<Vector2>() { new Vector2(-2.97f, -2.94f), new Vector2(-0.3f, -2.94f), new Vector2(2.37f, -2.94f) };

    public PlayerMovement playerMovement = new PlayerMovement();
    public int playerTurn;

    

    private List<GameObject> inventoryItems1 = new List<GameObject>();
    private List<GameObject> inventoryItems2 = new List<GameObject>();
    private List<GameObject> inventoryItems3 = new List<GameObject>();
    private List<GameObject> inventoryItems4 = new List<GameObject>();

    [SerializeField] private List<Player> _player;

    void DisplayItems()
    {
        tempShop = Instantiate(shop);
        tempShop.transform.position = new Vector2(-0.2959419f, 0.07f);

        for (int i = 0; i < 3; i++)
        {
            int randomItem = UnityEngine.Random.Range(0, 7);
            displayItems[i] = Instantiate(items[randomItem]);
            displayItems[i].transform.position = displayLocations[i];
            displayItems[i].AddComponent<ClickableItem>().shopScript = this;
        }
    }

    public void OnItemClick(GameObject clickedItem)
    {
        playerTurn = playerMovement.GetCurrentPlayer();
        if (playerTurn == 0)
        {
            AddToInventory1(clickedItem);
        }
        else if (playerTurn == 1)
        {
            AddToInventory2(clickedItem);
        }
        else if (playerTurn == 2)
        {
            AddToInventory3(clickedItem);
        }
        else if (playerTurn == 3)
        {
            AddToInventory4(clickedItem);
        }


        foreach (GameObject item in displayItems)
        {
            if (item != clickedItem)
            {
                Destroy(item);
            }
        }
        Destroy(tempShop);

        clickedItem.transform.localScale = new Vector2(1f, 1f);
    }


    //add to inventory and position items
    public void AddToInventory1(GameObject item)
    {
        inventoryItems1.Add(item);

        if (inventoryItems1.Count >= 1)
        {
            inventoryItems1[0].transform.position = new Vector2(-8.79f, 3.37f);
        }
        if (inventoryItems1.Count >= 2)
        {
            inventoryItems1[1].transform.position = new Vector2(-8.09f, 3.37f);
        }
        if (inventoryItems1.Count >= 3)
        {
            inventoryItems1[2].transform.position = new Vector2(-7.39f, 3.37f);
        }
        if (inventoryItems1.Count >= 4)
        {
            for (int i = 3; i < inventoryItems1.Count; i++)
            {
                Destroy(inventoryItems1[i]);
            }
        }
    }

    public void AddToInventory2(GameObject item)
    {
        inventoryItems2.Add(item);

        if (inventoryItems2.Count >= 1)
        {
            inventoryItems2[0].transform.position = new Vector2(-8.69f, -1.53f);
        }
        if (inventoryItems2.Count >= 2)
        {
            inventoryItems2[1].transform.position = new Vector2(-7.99f, -1.53f);
        }
        if (inventoryItems2.Count >= 3)
        {
            inventoryItems2[2].transform.position = new Vector2(-7.29f, -1.53f);
        }
        if (inventoryItems2.Count >= 4)
        {
            for (int i = 3; i < inventoryItems2.Count; i++)
            {
                Destroy(inventoryItems2[i]);
            }
        }
    }

    public void AddToInventory3(GameObject item)
    {
        inventoryItems3.Add(item);

        if (inventoryItems3.Count >= 1)
        {
            inventoryItems3[0].transform.position = new Vector2(7.46f, -1.4f);
        }
        if (inventoryItems3.Count >= 2)
        {
            inventoryItems3[1].transform.position = new Vector2(8.16f, -1.4f);
        }
        if (inventoryItems3.Count >= 3)
        {
            inventoryItems3[2].transform.position = new Vector2(8.86f, -1.4f);
        }
        if (inventoryItems3.Count >= 4)
        {
            for (int i = 3; i < inventoryItems3.Count; i++)
            {
                Destroy(inventoryItems3[i]);
            }
        }
    }

    public void AddToInventory4(GameObject item)
    {
        inventoryItems4.Add(item);

        if (inventoryItems4.Count >= 1)
        {
            inventoryItems4[0].transform.position = new Vector2(7.46f, 3.47f);
        }
        if (inventoryItems4.Count >= 2)
        {
            inventoryItems4[1].transform.position = new Vector2(8.16f, 3.47f);
        }
        if (inventoryItems4.Count >= 3)
        {
            inventoryItems4[2].transform.position = new Vector2(8.86f, 3.47f);
        }
        if (inventoryItems4.Count >= 4)
        {
            for (int i = 3; i < inventoryItems4.Count; i++)
            {
                Destroy(inventoryItems4[i]);
            }
        }
    }

    public List<GameObject> GetInv1()
    {
        return inventoryItems1;
    }
    public List<GameObject> GetInv2()
    {
        return inventoryItems2;
    }
    public List<GameObject> GetInv3()
    {
        return inventoryItems3;
    }
    public List<GameObject> GetInv4()
    {
        return inventoryItems4;
    }
}
