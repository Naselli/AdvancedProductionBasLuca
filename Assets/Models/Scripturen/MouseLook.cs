using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    private float X;
    private float Y;

    public float minX;
    public float maxX;

    public float minY;
    public float maxY;

    public float Sensitivity;

    void Awake()
    {
        Vector3 euler = transform.rotation.eulerAngles;
        X = euler.x;
        Y = euler.y;

        transform.rotation = Quaternion.Euler(0f, 180f, 0.0f);
    }

    void Start()
    {
        //Set Cursor to not be visible
        Cursor.visible = false;
    }

    void Update()
    {
        float MIN_X = minX;
        float MAX_X = maxX;
        float MIN_Y = -minY;
        float MAX_Y = maxY;

        X += Input.GetAxis("Mouse X") * (Sensitivity * Time.deltaTime);
        if (X < MIN_X) X = MIN_X;
        else if (X > MAX_X) X = MAX_X;

        Y -= Input.GetAxis("Mouse Y") * (Sensitivity * Time.deltaTime);
        if (Y < MIN_Y) Y = MIN_Y;
        else if (Y > MAX_Y) Y = MAX_Y;


            transform.rotation = Quaternion.Euler(Y, X, 0.0f);
    }

}


