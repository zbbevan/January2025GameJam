using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollidableObject : MonoBehaviour
{
    //The following code was found in a video tutorial by Antarsoft on YouTube at https://www.youtube.com/watch?v=R_DPVlJK8o8
    //The code was modified to fit the needs of the project

    private Collider2D z_Collider;
    [SerializeField] private ContactFilter2D z_filter;
    private List<Collider2D> z_Colliders = new List<Collider2D>();

    private void Start(){
        z_Collider = GetComponent<Collider2D>();
    }
    protected virtual void Update(){
        z_Collider.OverlapCollider(z_filter, z_Colliders);
        foreach (var o in z_Colliders){
            OnCollided(o.gameObject);
        }
    }

    protected virtual void OnCollided(GameObject collision){
        Debug.Log("Collided with " + collision.name);
    }

}
