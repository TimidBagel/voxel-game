using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Characters.Player;
using UnityEngine.UI;

public class InteractionMenu : MonoBehaviour
{
    #region Variables
    [Header("Designations")]
    public PlayerMotor playerMotor;
    public PlayerController playerController;
    public Interactable currentObject;
    public GameObject additionalActionsPannel;

    [Header("Name Text")]
    public Text objectNameText;
    public Text objectTypeText;

    [Header("Action Buttons")]
    public GameObject ViewActionsButton;
    public GameObject HideActionsButton;
    public GameObject action1Button;
    public GameObject action2Button;
    public GameObject action3Button;
    public GameObject action4Button;
    public Text action1Text;
    public Text action2Text;
    public Text action3Text;
    public Text action4Text;
    #endregion

    #region Singleton
    public static InteractionMenu instance;
    private void Awake()
    {
        ViewActionsButton.SetActive(true);
        HideActionsButton.SetActive(false);
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
    public void CloseMenu()
    {
        playerController.focus = null;
        playerMotor.StopFollowingTarget();
        gameObject.SetActive(false);
    }
    public void ViewActions()
    {
        ViewActionsButton.SetActive(false);
        HideActionsButton.SetActive(true);
        additionalActionsPannel.SetActive(true);
        if (currentObject.type == "Item")
        {
            action1Button.SetActive(true);
            action2Button.SetActive(true);
            action3Button.SetActive(false);
            action4Button.SetActive(false);
            action1Text.text = "Pickup";
            action2Text.text = "Search on Market";
        }
        if (currentObject.type == "Lootable")
        {
            action1Button.SetActive(true);
            action2Button.SetActive(false);
            action3Button.SetActive(false);
            action4Button.SetActive(false);
            action1Text.text = "Loot";
        }
        if (currentObject.type == "Minable")
        {
            action1Button.SetActive(true);
            action2Button.SetActive(true);
            action3Button.SetActive(false);
            action4Button.SetActive(false);
            action1Text.text = "Mine";
            action2Text.text = "Search on Market";
        }
        if (currentObject.type == "Character")
        {
            action1Button.SetActive(true);
            action2Button.SetActive(true);
            action3Button.SetActive(true);
            action4Button.SetActive(true);
            action1Text.text = "Attack";
            action2Text.text = "Talk";
            action3Text.text = "Trade";
            action4Text.text = "Follow Target";
        }
        else
        {
            Debug.Log("No available actions for interactable object");
        }
    }
    public void HideActions()
    {
        HideActionsButton.SetActive(false);
        ViewActionsButton.SetActive(true);
        additionalActionsPannel.SetActive(false);
    }
    public void Action1()
    {
        if (action1Text.text == "Pickup")
        {
            ItemPickup currentItem = currentObject.GetComponent<ItemPickup>();
            if (currentItem != null)
            {
                if (currentItem.canInteract)
                {
                    currentItem.Pickup();
                }
                else
                {
                    Debug.Log("Player too far from item");
                    // text should show up on the screen for this
                }
            }
        }
        if (action1Text.text == "Loot")
        {
            if (currentObject.canInteract)
            {
                // code for looting the focused lootable object
            }
            else
            {
                Debug.Log("Player too far away from object");
            }
        }
        if (action1Text.text == "Mine")
        {
            if (currentObject.canInteract)
            {
                // code for mining the focused object, should transfer to inventory
            }
            else
            {
                Debug.Log("Player too far away from object");
            }
        }
        if (action1Text.text == "Attack")
        {
            // code for attacking the focused character
        }
    }
    public void Action2()
    {
        if (action2Text.text == "Search on Market")
        {
            // code for displaying buy/sell prices for the focused item
        }
        if (action2Text.text == "Talk")
        {
            if (currentObject.canInteract)
            {
                // code for talking with the focused character
            }
            else
            {
                Debug.Log("Player too far away from character");
            }
        }
    }
    public void Action3()
    {
        if (action3Text.text == "Trade")
        {
            if (currentObject.canInteract)
            {
                // code for trading with the focused character
            }
            else
            {
                Debug.Log("Player too far away from character");
            }
        }
    }
    public void Action4()
    {
        if (action4Text.text == "Follow Target")
        {
            playerMotor.FollowTarget(currentObject);
        }
    }
}
