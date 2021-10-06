using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Assets.Scripts.Mechanics
{
    public class CameraController : MonoBehaviour
    {
        public Transform camTransform;

        public float movementSpeed;
        public float movementTime;
        public float normalSpeed;
        public float fastSpeed;

        public Vector3 newPos;
        public Vector3 zoomAmount;
        public Vector3 newZoom;
        public Vector3 dragStartPos;
        public Vector3 dragCurrentPos;
        private void Start()
        {
            camTransform = Camera.main.transform;
            newPos = transform.position;
            newZoom = camTransform.localPosition;
        }
        private void Update()
        {
            HandleMovementInput();
        }
        private void LateUpdate()
        {
            //HandleMouseInput();
            // Please, I need to fix this. Would really enjoy being able to click and drag
            // for camera movement, but it doesn't seem to work in this video: https://www.youtube.com/watch?v=rnqF6S7PfFA
        }
        private void HandleMovementInput()
        {
            if (Input.GetKey(KeyCode.LeftShift))
                movementSpeed = fastSpeed;
            else
                movementSpeed = normalSpeed;
            if (Input.GetKey(KeyCode.W) || (Input.GetKey(KeyCode.UpArrow)))
                newPos += (transform.forward * movementSpeed);
            if (Input.GetKey(KeyCode.S) || (Input.GetKey(KeyCode.DownArrow)))
                newPos += (transform.forward * -movementSpeed);
            if (Input.GetKey(KeyCode.A) || (Input.GetKey(KeyCode.LeftArrow)))
                newPos += (transform.right * -movementSpeed);
            if (Input.GetKey(KeyCode.D) || (Input.GetKey(KeyCode.RightArrow)))
                newPos += (transform.right * movementSpeed);
            transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * movementTime);

            if (Input.GetKey(KeyCode.R))
                newZoom += zoomAmount;
            if (Input.GetKey(KeyCode.F))
                newZoom -= zoomAmount;
            camTransform.localPosition = Vector3.Lerp(camTransform.localPosition, newZoom, Time.deltaTime * movementTime);
        }
        // I really need to fix this part :(
        //private void HandleMouseInput()
        //{
        //    if (Input.GetMouseButtonDown(2))
        //    {
        //        Debug.Log("This is working!");
        //        Plane plane = new Plane(Vector3.up, Vector3.zero);
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //        float entry;

        //        if (plane.Raycast(ray, out entry))
        //            dragStartPos = ray.GetPoint(entry);
        //    }
        //    if (Input.GetMouseButtonDown(2))
        //    {
        //        Debug.Log("This is also working!");
        //        Plane plane = new Plane(Vector3.up, Vector3.zero);
        //        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        //        float entry;

        //        if (plane.Raycast(ray, out entry))
        //        {
        //            dragCurrentPos = ray.GetPoint(entry);

        //            newPos = transform.position + dragStartPos - dragCurrentPos;
        //        }
        //    }
        //}
    }
}