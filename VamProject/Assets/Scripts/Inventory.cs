using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    [HideInInspector]
    public List<Item> item;

    public GameObject database;
    public GameObject cellContainer;
    public GameObject MessageManager;
    public GameObject Message;
    public GameObject Player;
    public KeyCode ShowInventory;
    public KeyCode TakeButton;
    // Start is called before the first frame update
    void Start()
    {
        
        item = new List<Item>();
        cellContainer.SetActive(false);

        for (int i =0; i<cellContainer.transform.childCount; i++)
        {
            cellContainer.transform.GetChild(i).GetComponent<CurrentItem>().index = i;
        }

        for (int i = 0; i < cellContainer.transform.childCount; i++)
        {
            item.Add(new Item());
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (Time.timeScale == 1)
        {
            Cursor.lockState = CursorLockMode.Locked;
        }
        
    ToggleInventory();
        if (Input.GetKeyDown(TakeButton))
        {
            Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 10f))
            {
                if (hit.collider.GetComponent<Item>())
                {
                    Item currentItem = hit.collider.GetComponent<Item>();
                    ShowMessage(currentItem);
                    AddItem(hit.collider.GetComponent<Item>());
                }
            }
        }
    }

    void ShowMessage(Item currentItem)
    {
        GameObject msgObj = Instantiate(Message);
        msgObj.transform.SetParent(MessageManager.transform);
        Image msgImg = msgObj.transform.GetChild(0).GetComponent<Image>();
        msgImg.sprite = currentItem.icon;
        Text msgTxt = msgObj.transform.GetChild(1).GetComponent<Text>();
        msgTxt.text = currentItem.nameItem;
    }

    void AddItem(Item currentItem)
    {
        if (currentItem.isStackable)
        {
            addStacableItem(currentItem);
        }
        else
        {
            addUnstacableItem(currentItem);
        }
    }
    void addUnstacableItem(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].idItem == 0)
            {
                item[i] = currentItem;
                item[i].countItem = 1;
                DisplayItem();
                Destroy(currentItem.gameObject);
                break;
            }
        }
    }
    void addStacableItem(Item currentItem)
    {
        for (int i = 0; i < item.Count; i++)
        {
            if (item[i].idItem == currentItem.idItem)
            {
                item[i].countItem++;
                DisplayItem();
                Destroy(currentItem.gameObject);
                return;
            }
        }
        addUnstacableItem(currentItem);
    }


    void ToggleInventory()
    {
        if (Input.GetKeyDown(ShowInventory))
        {
            if (cellContainer.activeSelf)
            {
                cellContainer.SetActive(false);
                Time.timeScale = 1;
                Cursor.visible = false;

            }
            else
            {
                cellContainer.SetActive(true);
                Time.timeScale = 0;
                Cursor.visible = true;
                Cursor.lockState = CursorLockMode.Confined;

            }
        }
    }
        public void DisplayItem()
        {
            for (int i = 0; i < item.Count; i++)
            {

                Transform cell = cellContainer.transform.GetChild(i);
                Transform icon = cell.GetChild(0);
                Transform count = icon.GetChild(0);

                Text txt = count.GetComponent<Text>();

                Image img = icon.GetComponent<Image>();

                if (item[i].idItem != 0)
                {
                    img.enabled = true;
                    img.sprite = item[i].icon;
                    if (item[i].countItem > 1)
                    {
                        txt.text = item[i].countItem.ToString();
                    }
                    else
                    {
                        txt.text = null;
                    }

                }
                else
                {
                    img.enabled = false;
                    img.sprite = null;
                    txt.text = null;
                }
            }
        }
    }
