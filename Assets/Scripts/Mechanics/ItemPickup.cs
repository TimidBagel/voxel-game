using UnityEngine;

public class ItemPickup : Interactable
{
    public void Pickup()
    {
        Debug.Log("Picking up an item");
        // add the item to the inventory
        Destroy(gameObject);
    }
}
