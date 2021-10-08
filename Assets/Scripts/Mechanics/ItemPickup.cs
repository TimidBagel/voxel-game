using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public void Pickup()
    {
        Debug.Log("Picking up an item");
        Inventory.instance.Add(item);
        if (Inventory.instance.Add){
        Destroy(gameObject);
        }
        if (!Inventory.instance.Add){
            Debug.Log("Failed to pickup" + item.name);
        }
    }
}
 