using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Item : MonoBehaviour
{

    public string nameItem;
    public int idItem;
    [HideInInspector]
    public int countItem;
    public bool isStackable;
    [Multiline(5)]
    public string descriptionItem;
    public Sprite icon;
    public UnityEvent customEvent;
    public bool IsRemovable;
    public bool IsDroped;
    

}
