using Cinemachine;
using UnityEngine;

public class MoveAroundCamera : MonoBehaviour
{
    [SerializeField] private Camera cam;
    [SerializeField] private float zoom = 10f;
    [SerializeField] private Transform target;
    [SerializeField] private float distanceToTarget = 10;
    bool isMoving = false;

    private void Update()
    {
        cam.transform.position = new Vector3(target.position.x, target.position.y,transform.position.z);

        if(cam.orthographic)
        {
            cam.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * zoom;
        }
        else
        {
            cam.fieldOfView -= Input.GetAxis("Mouse ScrollWheel") * zoom;

        }
    }
}