using UnityEngine;

public class Movement : MonoBehaviour
{
    [SerializeField]
    public float speed = 10;
    
    public void Update()
    {
        
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Translate(Vector3.left * (Time.deltaTime * speed));
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Translate(Vector3.right * (Time.deltaTime * speed));
        }
            
    }
}
