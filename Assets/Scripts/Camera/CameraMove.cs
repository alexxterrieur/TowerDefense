using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraMove : MonoBehaviour
{
    [SerializeField] Camera cam;
    private Vector2 delta;
    private float zoom;
    private bool isMoving;

    [SerializeField] private float movementSpeed = 10;

    public void OnLook(InputAction.CallbackContext ctx)
    {
        delta = ctx.ReadValue<Vector2>();
    }

    public void OnMove(InputAction.CallbackContext ctx)
    {
        isMoving = ctx.started || ctx.performed;
    }

    public void OnZoom(InputAction.CallbackContext ctx)
    {
        zoom = ctx.ReadValue<float>();
        if(zoom > 0)
        {
            gameObject.GetComponent<Camera>().orthographicSize -= 1;
        }
        else if(zoom < 0)
        {
            gameObject.GetComponent<Camera>().orthographicSize += 1;
        }

        //set the limit of the camera
        if(gameObject.GetComponent<Camera>().orthographicSize <= 5)
            gameObject.GetComponent<Camera>().orthographicSize = 5;
        else if(gameObject.GetComponent<Camera>().orthographicSize >= 15)
            gameObject.GetComponent<Camera>().orthographicSize = 15;

    }

    private void LateUpdate()
    {
        if(isMoving)
        {
            var position = transform.right * (delta.x * -movementSpeed);
            position += transform.up * (delta.y * -movementSpeed);
            transform.position += position * Time.deltaTime;
        }
    }
}
