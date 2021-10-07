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

        public Interactable focus;
        public GameObject gameMenu;
        private void Start()
        {
            cam = Camera.main;
            motor = GetComponent<PlayerMotor>();
        }
        private void Update()
        {
            if (gameMenu.activeSelf == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                    if (Physics.Raycast(ray, out RaycastHit hit, 500, movementMask))
                    {
                        motor.MoveToPoint(hit.point);
                        Debug.Log($"'{transform.name}' moving to {hit.point}");
                    }
                }
            }
            if (Input.GetMouseButtonDown(1))
            {
                Ray ray = cam.ScreenPointToRay(Input.mousePosition);

                if (Physics.Raycast(ray, out RaycastHit hit, 100))
                {
                    Interactable interactable = hit.collider.GetComponent<Interactable>();
                    if (interactable != null)
                    {
                        SetFocus(interactable);
                    }
                }
            }
        }
        public void SetFocus(Interactable newFocus)
        {
            if (focus == newFocus)
            {
                RemoveFocus();
                return;
            }
            focus = newFocus;
            focus.OnFocus();
            Debug.Log($"Focus is now {focus.transform.name}");
        }
        public void RemoveFocus()
        {
            focus.OnUnFocus();
            focus = null;
            Debug.Log("Focus removed");
        }
    }
}
