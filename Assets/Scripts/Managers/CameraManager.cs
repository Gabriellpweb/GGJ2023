using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    public float speed = 15f;

    public float cameraX = 40;

    // Update is called once per frame
    void Update()
    {
        transform.localEulerAngles = new Vector3(cameraX, 0, 0);

        if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
        {
            transform.Translate(new Vector3(speed * Time.deltaTime, 0, 0));
        }

        if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
        {
            transform.Translate(new Vector3(-speed * Time.deltaTime, 0, 0));
        }

        if ((Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S)))
        {
            transform.Translate(new Vector3(0, -speed * Time.deltaTime, -speed * Time.deltaTime));
        }

        if ((Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W)))
        {
            transform.Translate(new Vector3(0, speed * Time.deltaTime, speed * Time.deltaTime));
        }
    }
}
