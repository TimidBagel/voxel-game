using UnityEngine;
using Unity;
using UnityEditor;

namespace Assets.Scripts.Characters.Player
{
    [RequireComponent(typeof(PlayerMotor))]
    public class PlayerController : MonoBehaviour
    {
        public LayerMask movementMask;
        Camera cam;
        PlayerMotor motor;
        private void Start()
        {
            cam = Camera.main;
            motor = GetComponent<PlayerMotor>();
        }
        private void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                
                if (Physics.Raycast(ray, out hit, 100, movementMask))
                {
                    motor.MoveToPoint(hit.point);
                    Debug.Log($"'{transform.name}' moving to {hit.point}");
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                if (Physics.Raycast(ray, out hit, 100))
                {
                    // check if the object hit is interactable
                    // if we did set it as our focus
                }
            }
        }
    }
}
