using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Customer : MonoBehaviour
{
    private Collider2D coll;
    private Spawner spawn;
    [SerializeField] private GameObject yourself;
    [SerializeField] private Inventory invent;
    [SerializeField] private string desiredItem;
    [SerializeField] private GameObject desiredItemSlot;

    // Start is called before the first frame update
    void Start()
    {
        coll = GetComponent<Collider2D>();
        invent = GameObject.Find("Inventory").GetComponent<Inventory>();
        desiredItem = invent.allItems[Random.Range(0, invent.allItems.Length)].name;
        
        spawn = GameObject.Find("Spawner").GetComponent<Spawner>();

         desiredItem = invent.allItems[Random.Range(0, invent.allItems.Length)].name;
         for (int x = 0; x < invent.allItems.Length; x++)
        {
            if (invent.allItems[x].name == desiredItem)
            {
                desiredItemSlot.GetComponent<SpriteRenderer>().sprite = invent.allItems[x].GetComponent<SpriteRenderer>().sprite;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }


       protected void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Player")
        {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Interacted with " + yourself.name);
            OnInteract();
        }
        }

    }

    protected void OnInteract(){
        if (invent.selectedItem == desiredItem)
        {
            Debug.Log("Selling " + invent.selectedItem + " to " + yourself.name);
            invent.RemoveItem(invent.selectedItem);
            Destroy(yourself);
            spawn.lastSpawn = Time.time;
        }
}

}
