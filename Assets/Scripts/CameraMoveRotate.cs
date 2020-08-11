using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMoveRotate : MonoBehaviour
{
    [SerializeField] private float _speedRotation = 3f;
    [SerializeField] private float _speedMove = 5f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        Rotate();
    }

    private void Move()
    {
        if (Input.mousePosition.x >= (Screen.width - 2.25f))
        {
            transform.position += new Vector3(_speedMove * Time.deltaTime, 0.0f, 0.0f);
        }
        else if (Input.mousePosition.x <= 2.25f)
        {
            transform.position -= new Vector3(_speedMove * Time.deltaTime, 0.0f, 0.0f);
        }

        if (Input.mousePosition.y >= (Screen.height - 2.25f))
        {
            transform.position += new Vector3(0.0f, 0.0f, _speedMove * Time.deltaTime);
        }
        else if (Input.mousePosition.y <= 2.25f)
        {
            transform.position -= new Vector3(0.0f, 0.0f, _speedMove * Time.deltaTime);
        }
    }

    private void Rotate()
    {
        if (Input.GetMouseButton(1))
        {
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");
            //Quaternion.AngleAxis(mouseX* 100, Vector3.up);
            transform.Rotate(-mouseY * _speedRotation * Time.deltaTime, mouseX * _speedRotation * Time.deltaTime, 0);
            Debug.Log(mouseX * _speedRotation * Time.deltaTime);
        }
    }
}
