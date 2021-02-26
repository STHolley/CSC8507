using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private const float Y_ANGLE_MIN = -10.0f;
    private const float Y_ANGLE_MAX = 89.9f;

    public Transform lookAt;
    public Transform cTransform;

    private Camera c;

    private float distance = 6.0f;
    private float currentX = 0.0f;
    private float currentY = 0.0f;
    private float sensitivityX = 4.0f;
    private float sensitivityY = 1.0f;

    private int reboundFrames = 0;

    private void Start()
    {
        cTransform = transform;
        c = Camera.main;
    }

    private void Update()
    {
        currentX -= Input.GetAxis("Mouse X") * sensitivityX;
        currentY += Input.GetAxis("Mouse Y") * sensitivityY;
        currentY = Mathf.Clamp(currentY, Y_ANGLE_MIN, Y_ANGLE_MAX);
        RaycastHit hit;
        if (Physics.Raycast(lookAt.position, Vector3.Normalize(transform.position - lookAt.position), out hit, 6.0f) && !(hit.collider.GetComponent<Renderer>().sharedMaterial.color.a < 1.0f))
        {
            if (Vector3.Distance(hit.point, lookAt.position) > 1.0f)
            {
                Debug.DrawRay(lookAt.position, hit.point - lookAt.position, Color.green);
                distance = Mathf.Clamp(hit.distance, 1.0f, 10.0f);
            }
            else
            {
                distance = 1.0f;
            }
            Vector3 dir = new Vector3(0, 0, -distance);
            Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
            cTransform.position = lookAt.position + rotation * dir;
            cTransform.LookAt(lookAt.position);
            reboundFrames = 3;
        }
        else {
            if (reboundFrames != 0)
            {
                Vector3 dir = new Vector3(0, 0, -distance);
                Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
                //cTransform.position = lookAt.position + rotation * dir;
                cTransform.LookAt(lookAt.position);
                Vector3.Lerp(transform.position, lookAt.position + rotation * dir, (float)reboundFrames / 10.0f);
                reboundFrames--;
            } else
            {
                Vector3 dir = new Vector3(0, 0, -6.0f);
                Quaternion rotation = Quaternion.Euler(currentY, currentX, 0);
                cTransform.position = lookAt.position + rotation * dir;
                cTransform.LookAt(lookAt.position);
            }
           
        }
        
    }
}
