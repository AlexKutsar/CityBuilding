using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveRotate : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            //Quaternion.AngleAxis(mouseX* 100, Vector3.up);
            transform.Rotate(mouseY * _speedRotation * Time.deltaTime, mouseX * _speedRotation * Time.deltaTime, 0);
            Debug.Log(mouseX * _speedRotation * Time.deltaTime);
        }
    }
}
