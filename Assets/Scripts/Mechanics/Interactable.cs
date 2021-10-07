using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    InteractableMenu interactionMenu;
    new public string name;
    public string type;
    private void Start()
    {
        interactionMenu = InteractableMenu.instance;
    }
    public void OnFocus()
    {
        interactionMenu.gameObject.SetActive(true);
        interactionMenu.SetNameAndType(this);
    }
    public void OnUnFocus()
    {
        interactionMenu.gameObject.SetActive(false);
        interactionMenu.HideActions();
    }
}
