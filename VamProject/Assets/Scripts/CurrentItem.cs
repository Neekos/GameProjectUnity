using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;


public class CurrentItem : MonoBehaviour, IPointerClickHandler
{
    
    [HideInInspector]
    public int index;
    GameObject inventoryObj;
    Inventory inventory;
    
    

    // Start is called before the first frame update
    void Start()
    {
        inventoryObj = GameObject.FindGameObjectWithTag("InventoryManager");
        inventory = inventoryObj.GetComponent<Inventory>();
        
    }

    // Update is called once per frame
       

    public void OnPointerClick(PointerEventData eventData)
    {

        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (inventory.item[index].customEvent!=null)
            {
                inventory.item[index].customEvent.Invoke();            
            }
            if (inventory.item[index].IsRemovable)
            {
                Remove();
            }
        }

        if (eventData.button == PointerEventData.InputButton.Right)
        {
            if (inventory.item[index].IsDroped)
            {
                Drop();
                Remove();
            }
            
            
           
            
        } 
    }
    void Remove()
    {
        if (inventory.item[index].idItem != 0)
        {
            
            if (inventory.item[index].countItem > 1)
            {
                inventory.item[index].countItem--;
            }
            else
            {
                inventory.item[index] = new Item();
            }

            inventory.DisplayItem();
        }

    }
    void Drop()
    {
        if (inventory.item[index].idItem != 0)
        {
            for (int i = 0; i<inventory.database.transform.childCount; i++ )
            {
                Item item = inventory.database.transform.GetChild(i).GetComponent<Item>(); 
                if (item)
                {
                    if (inventory.item[index].idItem == item.idItem )
                    {
                        GameObject droppedObj = Instantiate(item.gameObject);
                        droppedObj.transform.position = Camera.main.transform.position + Camera.main.transform.forward;
                    }
                    
                }
                
            }
        }
    }
}
