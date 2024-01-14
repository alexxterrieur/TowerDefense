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
        if (zoom > 0)
        {
            cam.orthographicSize -= 1;
        }
        else if (zoom < 0)
        {
            cam.orthographicSize += 1;
        }

        //limit of the camera zoom
        cam.orthographicSize = Mathf.Clamp(cam.orthographicSize, 5, 25);
    }

    private void LateUpdate()
    {
        if (isMoving)
        {
            var position = transform.right * (delta.x * -movementSpeed);
            position += transform.up * (delta.y * -movementSpeed);
            Vector3 newPosition = transform.position + position * Time.deltaTime;

            //limit the camera position
            newPosition.x = Mathf.Clamp(newPosition.x, -50f, 4f);
            newPosition.y = Mathf.Clamp(newPosition.y, 12f, 25f);
            newPosition.z = Mathf.Clamp(newPosition.z, -50f, 8f);
            transform.position = newPosition;
        }
    }

}
