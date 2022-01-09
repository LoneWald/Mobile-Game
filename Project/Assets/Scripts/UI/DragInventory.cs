using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragInventory : MonoBehaviour
{
    public Inventory inv;

    GameObject curSlot;
    Item curSlotsItem;

    public Image followMouseImage;
    
    private InputActions input;
    
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

    void Update()
    {

        if (input.UIInput.DropItem.triggered)
        {
            GameObject obj = GetObjectUnderMouse();
            if (obj)
                obj.GetComponent<Slot>().DropItem();
        }

        if (input.UIInput.SelectItem.triggered)
        {
            curSlot = GetObjectUnderMouse();
        }
        else if (input.UIInput.MoveItem.inProgress)
        {
            followMouseImage.transform.position = Input.mousePosition;
            if (curSlot && curSlot.GetComponent<Slot>().slotsItem)
            {
                followMouseImage.color = new Color(255, 255, 255, 255);
                followMouseImage.sprite = curSlot.GetComponent<Image>().sprite;
            }
        }
        else if (input.UIInput.SetItem.triggered)
        {
            if(curSlot && curSlot.GetComponent<Slot>().slotsItem)
            {
                curSlotsItem = curSlot.GetComponent<Slot>().slotsItem;
                GameObject newObj = GetObjectUnderMouse();
                if (newObj && newObj != curSlot)
                {
                    if (newObj.GetComponent<Slot>().slotsItem)
                    {
                        Item objectsItem = newObj.GetComponent<Slot>().slotsItem;
                        if(objectsItem.itemID == curSlotsItem.itemID && objectsItem.amountInStack != objectsItem.maxStackSize)
                        {
                            curSlotsItem.transform.parent = null;
                            inv.AddItem(curSlotsItem, objectsItem);
                        }
                        else
                        {
                            objectsItem.transform.parent = curSlot.transform;
                            curSlotsItem.transform.parent = newObj.transform;
                        }
                    }
                    else
                    {
                        curSlotsItem.transform.parent = newObj.transform;
                    }
                }
            }
        }
        else
        {
            followMouseImage.sprite = null;
            followMouseImage.color = new Color(0, 0, 0, 0);
        }
    }

    GameObject GetObjectUnderMouse()
    {
        GraphicRaycaster rayCaster = GetComponent<GraphicRaycaster>();
        PointerEventData eventData = new PointerEventData(EventSystem.current);

        eventData.position = Input.mousePosition;

        List<RaycastResult> results = new List<RaycastResult>();

        rayCaster.Raycast(eventData, results);

        foreach (RaycastResult i in results)
        {
            if (i.gameObject.GetComponent<Slot>())
                return i.gameObject;
        }
        return null;
    }
}
