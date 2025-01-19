using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] inventory;
    [SerializeField] private GameObject[] slots;
    private bool[] isFull = new bool[6];

    private string[] itemList = new string[6];

    [SerializeField] private GameObject[] allItems;


    void Start()
    {
        for (int i = 0; i < isFull.Length; i++)
        {
            isFull[i] = false;
        }
    }

    public void AddItem(string item)
    {
        for (int i = 0; i < inventory.Length; i++)
        {
            if (isFull[i] == false)
            {
                slots[i].SetActive(true);
                itemList[i] = item;
                 for (int x = 0; x < allItems.Length; x++)
             {
                if (allItems[x].name == item)
                {
                 slots[i].GetComponent<Image>().sprite = allItems[x].GetComponent<SpriteRenderer>().sprite;
                }
            }
                isFull[i] = true;
                break;
            }
        }
    }

    public void RemoveItem(string item)
    {
        for (int i = 0; i < itemList.Length; i++)
        {
            if (itemList[i] == item)
            {
                Debug.Log("Removing " + item);
                slots[i].SetActive(false);
                isFull[i] = false;
                break;
            }
        }
    }

    public void GetItem(string item, GameObject returnItem)
    {
        for (int i = 0; i < allItems.Length; i++)
        {
            if (allItems[i].name == item)
            {
                returnItem = allItems[i];
            }
        }
    }

}
