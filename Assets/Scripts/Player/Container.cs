using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Container : InteractableObject
{
    public string containerName;
    public Sprite icon;
    public string containerDescription;
    public string[] containerContents;
    public int maxSlots;
    public int currentSlots;
}
