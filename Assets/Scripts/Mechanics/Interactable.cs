using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    InteractionMenu interactionMenu;
    Transform player;
    //public Transform interactionTransform; replace regular transform.position with this

    public ItemPickup itemPickup;
    public ObjectInteraction objectInteraction;

    bool isFocus = false;
    bool isObject = false;
    bool isItem = false;
    public bool canInteract = false;

    public float interactionRadius = 2.5f;
    private void Start()
    {
        interactionMenu = InteractionMenu.instance;
        interactionMenu.gameObject.SetActive(false);

        itemPickup = GetComponent<ItemPickup>();
        objectInteraction = GetComponent<ObjectInteraction>();
        if (itemPickup != null)
        {
            isItem = true;
            isObject = false;
        }
        if (objectInteraction != null)
        {
            isObject = true;
            isItem = false;
        }
    }
    private void Update()
    {
        if (isFocus)
        {
            float distance = Vector3.Distance(player.position, transform.position);
            if (distance <= interactionRadius)
            {
                canInteract = true;
            }
            else
            {
                canInteract = false;
            }
        }
    }
    public void OnFocus(Transform playerTransform)
    {
        isFocus = true;
        player = playerTransform;

        interactionMenu.gameObject.SetActive(true);

        if (isItem)
        {
            interactionMenu.SetNameAndType(null, itemPickup);
        }
        if (isObject)
        {
            interactionMenu.SetNameAndType(objectInteraction, null);
        }
        interactionMenu.HideActions();
    }
    public void OnUnFocus()
    {
        isFocus = false;

        interactionMenu.gameObject.SetActive(false);
        interactionMenu.HideActions();
        interactionMenu.playerMotor.StopFollowingTarget();
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, interactionRadius);
    }
}
