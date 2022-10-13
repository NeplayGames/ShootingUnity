using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControl : MonoBehaviour
{
    // Start is called before the first frame update

    float xRotation;
    float yRotation;
    private void Start()
    {
        Cursor.visible = false;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        float mouseY = Input.GetAxis("Mouse Y") * 200 * Time.deltaTime;
        float mouseX = Input.GetAxis("Mouse X") * 200 * Time.deltaTime;
        xRotation -= mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);
        yRotation -= mouseY;
        yRotation = Mathf.Clamp(yRotation, -90f, 90f);
        transform.localRotation = Quaternion.Euler( yRotation,0, 0f);
        transform.parent.localRotation = Quaternion.Euler( 0, -xRotation, 0f);
    }
}
