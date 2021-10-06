using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public GameObject interactableMenu;
    public void OnFocus()
    {
        interactableMenu.SetActive(true);
    }
    public void OnUnFocus()
    {
        interactableMenu.SetActive(false);
    }
}
