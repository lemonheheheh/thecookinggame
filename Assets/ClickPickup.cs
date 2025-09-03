using UnityEngine;

public class ClickPickup : MonoBehaviour
{
    private GameObject heldItem;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (heldItem == null)
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("Ingredient"))
                    {
                        heldItem = hit.collider.gameObject;
                    }
                }
            }
            else
            {
                
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    heldItem.transform.position = hit.point + Vector3.up * 0.5f;
                    heldItem = null;
                }
            }
        }

        
        if (heldItem != null)
        {
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = 5f;
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
            heldItem.transform.position = worldPos;
        }
    }
}

