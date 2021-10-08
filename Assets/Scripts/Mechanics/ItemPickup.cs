using UnityEngine;

public class ItemPickup : Interactable
{
    public Item item;
    public void Pickup()
    {
        Debug.Log($"'{item.name}' was picked up");
        bool wasPickedUp = Inventory.instance.Add(item);
        if (wasPickedUp)
            Destroy(gameObject);
    }
}
 