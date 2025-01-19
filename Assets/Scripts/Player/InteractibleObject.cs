using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : MonoBehaviour
{
    private Collider2D z_Collider;
    [SerializeField] private bool isItem;
    [SerializeField] private bool isContainer;
    [SerializeField] private bool isMachine;
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

    private Spawner spawn;

    private bool isWorking = false;
    private bool didWork = false;
    private string targetItem;


    private void Start()
    {
        z_Collider = GetComponent<Collider2D>();
        invent = GameObject.Find("Inventory").GetComponent<Inventory>();
        spawn = GameObject.Find("Spawner").GetComponent<Spawner>();
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

    protected void OnInteract()
    {
        if (isItem)
        {
            invent.AddItem(yourself.name);
            Destroy(yourself);
        }
        if (isContainer)
        {
            invent.AddItem(boxContents);
        }

        if (isMachine && (invent.selectedItem != null))
        {
            for (int i = 0; i < inputItems.Length; i++)
            {
                if (invent.selectedItem == inputItems[i])
                {
                    targetItem = outputItems[i];
                }
            }
        }

        if (isMachine && !isWorking && !didWork)
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
        if (isMachine && isWorking && !didWork)
        {
            Debug.Log("Working on " + targetItem);

        }
        if (isMachine && didWork && !isWorking)
        {
            Debug.Log("Taking " + targetItem + " from " + yourself.name);
            invent.AddItem(targetItem);
            yourself.GetComponent<SpriteRenderer>().sprite = originalSprite;
            didWork = false;
        }


    }



    IEnumerator Working()
    {
        AudioSource.PlayClipAtPoint(workingSound, transform.position);
        yield return new WaitForSeconds(workingDuration);
        AudioSource.PlayClipAtPoint(interactSound, transform.position);
        isWorking = false;
        didWork = true;
    }


}
