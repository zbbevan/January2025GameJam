using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [SerializeField] private GameObject[] inventory;
    [SerializeField] private GameObject[] slots;
    private bool[] isFull = new bool[7];

    private string[] itemList = new string[7];

    [SerializeField] private GameObject[] allItems;

    public string selectedItem;
    [SerializeField] private Sprite originalSprite;
    [SerializeField] private Sprite selectedItemSprite;



    void Start()
    {
        for (int i = 0; i < isFull.Length; i++)
        {
            isFull[i] = false;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            selectedItem = itemList[0];
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i].GetComponent<Image>().sprite = originalSprite;
            }
            inventory[0].GetComponent<Image>().sprite = selectedItemSprite;
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            selectedItem = itemList[1];
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i].GetComponent<Image>().sprite = originalSprite;
            }
            inventory[1].GetComponent<Image>().sprite = selectedItemSprite;
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            selectedItem = itemList[2];
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i].GetComponent<Image>().sprite = originalSprite;
            }
            inventory[2].GetComponent<Image>().sprite = selectedItemSprite;
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            selectedItem = itemList[3];
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i].GetComponent<Image>().sprite = originalSprite;
            }
            inventory[3].GetComponent<Image>().sprite = selectedItemSprite;
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            selectedItem = itemList[4];
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i].GetComponent<Image>().sprite = originalSprite;
            }
            inventory[4].GetComponent<Image>().sprite = selectedItemSprite;
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            selectedItem = itemList[5];
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i].GetComponent<Image>().sprite = originalSprite;
            }
            inventory[5].GetComponent<Image>().sprite = selectedItemSprite;
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            selectedItem = itemList[6];
            for (int i = 0; i < inventory.Length; i++)
            {
                inventory[i].GetComponent<Image>().sprite = originalSprite;
            }
            inventory[6].GetComponent<Image>().sprite = selectedItemSprite;
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
                selectedItem = itemList[i];
                for (int x = 0; x < inventory.Length; x++)
                {
                    inventory[x].GetComponent<Image>().sprite = originalSprite;
                }
                inventory[i].GetComponent<Image>().sprite = selectedItemSprite;
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

