using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public Collider2D z_Collider;
    [SerializeField] public GameObject yourself;
    [SerializeField] public string boxContents;
    [SerializeField] public Inventory invent;

    [SerializeField] public string[] inputItems;
    [SerializeField] public string[] outputItems;
    public AudioSource audioSource;
    [SerializeField] public AudioClip interactSound;
    [SerializeField] public AudioClip workingSound;
    [SerializeField] public float workingDuration;

    [SerializeField] public Sprite[] altSprites;
    [SerializeField] public Sprite originalSprite;

    public Spawner spawn;

    public bool isWorking = false;
    public bool didWork = false;
    public string targetItem;


    public void Start()
    {
        z_Collider = GetComponent<Collider2D>();
        invent = GameObject.Find("Inventory").GetComponent<Inventory>();
        spawn = GameObject.Find("Spawner").GetComponent<Spawner>();
        audioSource = GetComponent<AudioSource>();
    }

    public virtual void OnTriggerStay2D(Collider2D collision)
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

    public virtual void OnInteract()
    {
        
    }



    public IEnumerator Working()
    {
        audioSource.clip = workingSound;
        audioSource.Play();
        yield return new WaitForSeconds(workingDuration);
        audioSource.Stop();
        audioSource.clip = interactSound;
        audioSource.Play();
        isWorking = false;
        didWork = true;
    }


}
