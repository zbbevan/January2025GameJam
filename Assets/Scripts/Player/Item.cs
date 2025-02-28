using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "InventorySystems/Item")]
public class Item : ScriptableObject
{
    public string itemName;
    public string productName;
    public Sprite itemSprite;
    public Sprite containerSprite;
    public Sprite productSprite;
    public string itemDescription;
}
