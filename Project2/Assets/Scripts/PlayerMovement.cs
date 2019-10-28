using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    float horizontal;
    float vertical;
    float mouseX;
    float mouseY;
    [SerializeField] float moveSpeed;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal");
        vertical = Input.GetAxis("Vertical");

        mouseX = Input.GetAxis("Mouse X");
        mouseY = Input.GetAxis("Mouse Y");


        if (vertical != 0)
        {
            transform.position += transform.forward * vertical * moveSpeed;
        }
        if (horizontal != 0)
        {
            transform.position += transform.right * horizontal * moveSpeed;
        }

        if (mouseX != 0)
        {
            transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y+ mouseX, transform.rotation.eulerAngles.z);
        }
        if (mouseY != 0)
        {
            Transform mainCameraTransform = Camera.main.transform;

            mainCameraTransform.rotation = Quaternion.Euler(mainCameraTransform.rotation.eulerAngles.x-mouseY, mainCameraTransform.rotation.eulerAngles.y, mainCameraTransform.rotation.eulerAngles.z);
        }
        //quaternion larla rotasyonları, vector3 lerle de positionları ayarlıyoruz.

    }
}
