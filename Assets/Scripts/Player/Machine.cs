using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Machine : InteractableObject
{

     public AudioSource audioSource;
    [SerializeField] public AudioClip interactSound;
    [SerializeField] public AudioClip workingSound;
    [SerializeField] public float workingDuration;

    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public override void OnInteract()
    {
        if (invent.selectedItem != null)
        {
            for (int i = 0; i < inputItems.Length; i++)
            {
                if (invent.selectedItem == inputItems[i])
                {
                    targetItem = outputItems[i];
                }
            }
        }

        if (!isWorking && !didWork)
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


        if (isWorking && !didWork)
        {
            Debug.Log("Working on " + targetItem);

        }
        if (didWork && !isWorking)
        {
            Debug.Log("Taking " + targetItem + " from " + yourself.name);
            invent.AddItem(targetItem);
            yourself.GetComponent<SpriteRenderer>().sprite = originalSprite;
            didWork = false;
        }




    }

}
