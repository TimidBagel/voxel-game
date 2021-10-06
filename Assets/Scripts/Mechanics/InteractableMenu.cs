using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Characters.Player;
using UnityEngine.UI;

public class InteractableMenu : MonoBehaviour
{
    public PlayerMotor playerMotor;
    public PlayerController playerController;
    public void Approach()
    {
        playerMotor.MoveToPoint(playerController.focus.transform.position);
    }
}
