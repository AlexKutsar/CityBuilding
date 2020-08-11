using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMouseOrbitImproved : MonoBehaviour
{
    public Transform target;
    public float distance = 5.0f;
    public float xSpeed = 120.0f;
    public float ySpeed = 120.0f;

    public float yMinLimit = -10f;
    public float yMaxLimit = 80f;

    public float distanceMin = .5f;
    public float distanceMax = 15f;

    //private Rigidbody rigidbody;

    private float x = 0.0f;
    private float y = 0.0f;

    private Quaternion _rotation;

    void Start()
    {
        distance = transform.position.y;
        _rotation = transform.rotation;
        Vector3 angles = transform.eulerAngles;
        x = angles.y;
        y = angles.x;

        //rigidbody = GetComponent<Rigidbody>();

        // Make the rigid body not change rotation
        /*if (rigidbody != null)
        {
            rigidbody.freezeRotation = true;
        }*/
    }

    void LateUpdate()
    {
        if (target)
        {
            distance = Mathf.Clamp(distance - Input.GetAxis("Mouse ScrollWheel") * 5, distanceMin, distanceMax);

            RaycastHit hit;
            if (Physics.Linecast(target.position, transform.position, out hit))
            {
                distance -= hit.distance;
            }
            if (Input.GetMouseButton(1))
            {
                x += Input.GetAxis("Mouse X") * xSpeed * distance * 0.02f;
                y -= Input.GetAxis("Mouse Y") * ySpeed * 0.02f;

                y = ClampAngle(y, yMinLimit, yMaxLimit);

                _rotation = Quaternion.Euler(y, x, 0);
            }

            
            Vector3 negDistance = new Vector3(0.0f, 0.0f, -distance);
            Vector3 position = _rotation * negDistance + target.position;

            transform.rotation = _rotation;
            transform.position = position;
        }
    }

    private static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360f)
            angle += 360f;
        if (angle > 360f)
            angle -= 360f;
        return Mathf.Clamp(angle, min, max);
    }

}
