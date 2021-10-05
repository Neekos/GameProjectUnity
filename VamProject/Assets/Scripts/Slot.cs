using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{

    public Sprite ActiveCell;

    Sprite cell;
    Image img;
    // Start is called before the first frame update

    void OnDisable()
    {
        img.sprite = cell;
    }
    void Start()
    {
        img = GetComponent<Image>();
        cell = img.sprite;
    }

    
   


    public void OnPointerEnter(PointerEventData eventData)
    {
        img.sprite = ActiveCell;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        img.sprite = cell;
    }
}
