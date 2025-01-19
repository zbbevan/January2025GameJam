using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour
{
    private Collider2D z_Collider;
    [SerializeField] private bool isItem;
    [SerializeField] private bool isContainer;
    [SerializeField] private GameObject yourself;
    [SerializeField] private string boxContents;
    [SerializeField] private Inventory invent;

    [SerializeField] private string[] inputItems;
    [SerializeField] private string[] outputItems;
    [SerializeField] private AudioClip interactSound;
    [SerializeField] private AudioClip workingSound;
    [SerializeField] private float workingDuration;

    [SerializeField] private Sprite[] altSprites;
    [SerializeField] private Sprite originalSprite;

    private bool isWorking = false;
    private bool didWork = false;
    private string targetItem;


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
            invent.AddItem(boxContents);
        }
        if(isContainer && (invent.selectedItem != null))
        {
           for (int i = 0; i < inputItems.Length; i++)
           {
               if (invent.selectedItem == inputItems[i])
               {
                     targetItem = outputItems[i];
               }
           } 
        }

        if(isContainer && !isWorking && !didWork)
        {
            Debug.Log("Placing " + invent.selectedItem + " into " + yourself.name);
            invent.RemoveItem(invent.selectedItem);
            isWorking = true;

            for (int i = 0; i < inputItems.Length; i++)
            {
                if (invent.selectedItem == inputItems[i])
                {
                    yourself.GetComponent<SpriteRenderer>().sprite = altSprites[i];
                }
            }



            StartCoroutine(Working());
        }
        if(isContainer && isWorking && !didWork){
            Debug.Log("Working on " + targetItem);

        }
        if(isContainer && didWork && !isWorking){
            Debug.Log("Taking " + targetItem + " from " + yourself.name);
            invent.AddItem(targetItem);
            yourself.GetComponent<SpriteRenderer>().sprite = originalSprite;
            didWork = false;
        }



    }



    IEnumerator Working(){
        AudioSource.PlayClipAtPoint(workingSound, transform.position);
        yield return new WaitForSeconds(workingDuration);
        AudioSource.PlayClipAtPoint(interactSound, transform.position);
        isWorking = false;
        didWork = true;
    }


}
