using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class forMovement : MonoBehaviour //script created in unity has to be same with this public class
{
    public float speed = 200f;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.right * 1 * 200f * Time.deltaTime);
        }
        else if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.right * -1 * 200f * Time.deltaTime);
        }
    }
}
