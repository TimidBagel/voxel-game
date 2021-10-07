using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Characters.Player;
using UnityEngine.UI;

public class InteractableMenu : MonoBehaviour
{
    public PlayerMotor playerMotor;
    public PlayerController playerController;
    public Text objectNameText;
    public Text objectTypeText;
    public void SetNameAndType(Interactable gameObject)
    {
        //objectNameText = gameObject.transform.name;
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
        Debug.Log("Actions specific to this object are being viewed");
        // code to display additional object type specific actions for the interactable object
    }
}
