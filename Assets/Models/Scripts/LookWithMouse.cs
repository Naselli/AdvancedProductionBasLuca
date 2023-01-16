#if ENABLE_INPUT_SYSTEM 
using UnityEngine.InputSystem;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWithMouse : MonoBehaviour
{
    [SerializeField] private float     mouseSensitivity = 100f;
    [SerializeField] private Transform playerBody;
    private                  float     xRotation = 0f;
    private                  float     xInput;
    private                  float     yInput;
    private                  float     smoothValue = 20f;
    

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        
        xInput = Mathf.Lerp(xInput, mouseX, smoothValue * Time.deltaTime );
        yInput = Mathf.Lerp(yInput, mouseY, smoothValue * Time.deltaTime );

        
        xRotation -= yInput;
        xRotation = Mathf.Clamp(xRotation, -50f, 50f);

  
        transform.localRotation = Quaternion.Euler(xRotation , 0f, 0f);

        playerBody.Rotate(Vector3.up * xInput);
    }
}
