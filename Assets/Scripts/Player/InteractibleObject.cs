using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour
{
    private Collider2D z_Collider;
    [SerializeField] private bool isItem;
    [SerializeField] private bool isContainer;
    [SerializeField] private GameObject yourself;
    [SerializeField] private Inventory invent;

    [SerializeField] private string inputItem;
    [SerializeField] private string outputItem;

    private GameObject input;


    private void Start(){
        z_Collider = GetComponent<Collider2D>();
    }

    protected void OnCollisionStay2D(Collision2D collision){
        if (Input.GetKeyDown(KeyCode.E)){
            Debug.Log("Interacted with " + yourself.name);
            OnInteract();
        }
    }

    protected void OnInteract(){
        if(isItem){
            invent.AddItem(yourself.name);
            Destroy(yourself);
        }

        if(isContainer)
        {
            Debug.Log("Placing " + inputItem + " into " + yourself.name);
            invent.RemoveItem(inputItem);
            invent.AddItem(outputItem);
        }



    }


}
