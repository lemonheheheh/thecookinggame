using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;
    private int direction;

    private void OnTriggerEnter(Collider other)
    {
        if (Input.GetKey(KeyCode.LeftArrow)) { direction = 1; }
        if (Input.GetKey(KeyCode.RightArrow)) { direction = 2; }
    }

    private void OnTriggerExit(Collider other)
    {
        direction = 0;
    }


    public void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow) && direction != 1)
        {
            transform.Translate(Vector3.left * (Time.deltaTime * speed));
        }

        if (Input.GetKey(KeyCode.RightArrow) && direction != 2)
        {
            transform.Translate(Vector3.right * (Time.deltaTime * speed));
        }
            
    }
}
