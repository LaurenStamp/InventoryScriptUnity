// This script is used for Impaired by Lauren Stamp
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // array of how many objects a player can hold in their inventory
    public GameObject[] inventory = new GameObject[5];

    public void AddItem(GameObject item)
    {
        bool itemAdded = false;

        // loops through the array and adds a key if there is room in inventory
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == null)
            {
                inventory[i] = item;
                Debug.Log(item.name + " was added");
                itemAdded = true;
                item.SendMessage("DoInteraction");
                break;
            }
        }

        if (!itemAdded)
        {
            Debug.Log("Inventory Full - Item not added");
        }
    }

    public bool FindItem(GameObject item)
    {
        // loops through the array to find a particular item
        for (int i = 0; i < inventory.Length; i++)
        {
            if (inventory[i] == item)
            {
                return true;
            }
        }
        return false;
    }

    public bool FindKey()
    {
        // loops through array to find a key
        for(int i=0; i < inventory.Length; i++)
        {
            if(inventory[i]!=null)
            {
                if (inventory[i].GetComponent<InteractionObject>().IsKey())
                {
                    inventory[i] = null;
                    return true;
                }
            }
        }
        return false;
    }

}
