using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    private InputActions input;
    public GameObject inventoryObject;

    public Slot[] slots;
    private void Awake()
    {
        input = new InputActions();
    }
    private void OnEnable()
    {
        input.Enable();
    }
    private void OnDisable()
    {
        input.Disable();
    }


    void Start()
    {
        inventoryObject.SetActive(false);

        foreach(Slot i in slots)
        {
            i.CustomStart();
        }
    }

    void Update()
    {
        if(input.UIInput.Inventory.triggered)
        {
            if(inventoryObject.activeSelf == false)
            {
                inventoryObject.SetActive(true);
            }
            else
            {
                inventoryObject.SetActive(false);
            }
        }
        // if (Input.GetKeyDown(KeyCode.E))
        // {
        //     Ray ray = Camera.main.ScreenPointToRay(new Vector2(Screen.width / 2, Screen.height / 2));
        //     RaycastHit hit;
        //     if (Physics.Raycast(ray, out hit, distance))
        //     {
        //         if (hit.collider.gameObject.GetComponent<Item>())
        //             AddItem(hit.collider.gameObject.GetComponent<Item>());

        //     }
        // }

        foreach(Slot i in slots)
        {
            i.CheckForItem();
        }
    }

    public int GetItemAmount(int id)
    {
        int num = 0;
        foreach(Slot i in slots)
        {
            if (i.slotsItem)
            {
                Item z = i.slotsItem;
                if (z.itemID == id)
                    num += z.amountInStack;
            }
        }
        return num;
    }

    public void RemoveItemAmount(int id, int amountToRemove)
    {
        foreach(Slot i in slots)
        {
            if (amountToRemove <= 0)
                return;

            if (i.slotsItem)
            {
                Item z = i.slotsItem;
                if(z.itemID == id)
                {
                    int amountThatCanRemoved = z.amountInStack;
                    if(amountThatCanRemoved <= amountToRemove)
                    {
                        Destroy(z.gameObject);
                        amountToRemove -= amountThatCanRemoved;
                    }
                    else
                    {
                        z.amountInStack -= amountToRemove;
                        amountToRemove = 0;
                    }
                }
            }
        }
    }

    public void AddItem(Item itemToBeAdded, Item startingItem = null)
    {
        int amountInStack = itemToBeAdded.amountInStack;
        List<Item> stackableItems = new List<Item>();
        List<Slot> emptySlots = new List<Slot>();

        if (startingItem && startingItem.itemID == itemToBeAdded.itemID && startingItem.amountInStack < startingItem.maxStackSize)
            stackableItems.Add(startingItem);

        foreach (Slot i in slots)
        {
            if (i.slotsItem)
            {
                Item z = i.slotsItem;
                if (z.itemID == itemToBeAdded.itemID && z.amountInStack < z.maxStackSize && z != startingItem)
                    stackableItems.Add(z);
            }
            else
            {
                emptySlots.Add(i);
            }
        }

        foreach (Item i in stackableItems)
        {
            int amountThatCanbeAdded = i.maxStackSize - i.amountInStack;
            if(amountInStack <= amountThatCanbeAdded)
            {
                i.amountInStack += amountInStack;
                Destroy(itemToBeAdded.gameObject);
                return;
            }
            else
            {
                i.amountInStack = i.maxStackSize;
                amountInStack -= amountThatCanbeAdded;
            }
        }

        itemToBeAdded.amountInStack = amountInStack;
        if(emptySlots.Count > 0)
        {
            itemToBeAdded.transform.parent = emptySlots[0].transform;
            itemToBeAdded.gameObject.SetActive(false);
        }
    }
}



// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;
// using UnityEngine.UI;

// public class Inventory : MonoBehaviour
// {
//     private Canvas canvas;
//     private InputActions input;
//     public GameObject player;

//     public Transform inventorySlots;

// 	private Items items;

// 	private Slot[] slots;
    
//     private void Awake()
//     {
//         input = new InputActions();
//     }
//     private void OnEnable()
//     {
//         input.Enable();
//     }
//     private void OnDisable()
//     {
//         input.Disable();
//     }
//     void Start()
//     {
//         canvas = GetComponent<Canvas>();
// 		canvas.enabled = false;
// 		items = player.GetComponent<Items>();
// 		slots = inventorySlots.GetComponentsInChildren<Slot>(); //Получение всех ячеек
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
//         if(input.UIInput.Inventory.triggered){
// 			canvas.enabled = !canvas.enabled;
//         }
        
//     }
// }
