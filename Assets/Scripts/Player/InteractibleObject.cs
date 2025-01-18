using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractibleObject : CollidableObject
{
    protected override void OnCollided(GameObject collision){
        if (Input.GetKeyDown(KeyCode.E)){
            OnInteract();
        }
    }

    protected virtual void OnInteract(){
        Debug.Log("Interacted with " + gameObject.name);

    }


}
