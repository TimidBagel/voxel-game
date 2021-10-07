using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Characters.Player;
using UnityEngine.UI;

public class InteractableMenu : MonoBehaviour
{
    public PlayerMotor playerMotor;
    public PlayerController playerController;
    public Interactable currentObject;

    public GameObject additionalActionsPannel;

    public Text objectNameText;
    public Text objectTypeText;

    #region Singleton
    public static InteractableMenu instance;
    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogWarning("MORE THAN ONE INSTANCE OF INTERACTIONMENU FOUND!");
            return;
        }
        instance = this;
    }
    #endregion

    public void SetNameAndType(Interactable thing)
    {
        currentObject = thing;
        objectNameText.text = currentObject.name;
        objectTypeText.text = currentObject.type;
    }
    public void Approach()
    {
        playerMotor.MoveToPoint(playerController.focus.transform.position);
    }
    public void ViewInformation()
    {
        Debug.Log("This information is being viewed");
        // code to display a description of the interactable object
    }
    public void ViewActions()
    {
        additionalActionsPannel.SetActive(true);
        if (currentObject.type == "Pickup")
        {
            // displays actions for objects that can be picked up
        }
    }
    public void HideActions()
    {
        additionalActionsPannel.SetActive(false);
    }
}
