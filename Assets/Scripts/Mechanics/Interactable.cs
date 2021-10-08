using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    InteractionMenu interactionMenu;
    Transform player;
    public Transform interactionTransform;

    new public string name;
    public string type;

    bool isFocus = false;
    public bool canInteract = false;

    public float interactionRadius = 2.5f;
    private void Start()
    {
        interactionMenu = InteractionMenu.instance;
        interactionMenu.gameObject.SetActive(false);
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
        interactionMenu.SetNameAndType(this);
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
