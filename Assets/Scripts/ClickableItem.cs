using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickableItem : MonoBehaviour
{
    public ShopScript shopScript;

    private void OnMouseDown()
    {
        shopScript.OnItemClick(this.gameObject);
    }
}