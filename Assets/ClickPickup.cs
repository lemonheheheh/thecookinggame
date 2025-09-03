using UnityEngine;

public class ClickPickup : MonoBehaviour
{
    [Header("Pizza Layers")]
    public GameObject mushroomLayer; // assign this in Inspector

    private GameObject heldItem;
    public float holdHeight = 0.5f; // height above pizza

    void Update()
    {
        // Pick up / drop logic
        if (Input.GetMouseButtonDown(0))
        {
            if (heldItem == null)
            {
                // Pick up ingredient
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    if (hit.collider.CompareTag("Ingredient") && hit.collider.name == "Mushroom")
                    {
                        heldItem = hit.collider.gameObject;
                    }
                }
            }
            else
            {
                // Drop ingredient
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    // Show mushroom layer on pizza
                    if (mushroomLayer != null)
                        mushroomLayer.SetActive(true);

                    // Remove dragged object
                    Destroy(heldItem);
                    heldItem = null;
                }
            }
        }

        // Follow mouse while holding
        if (heldItem != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                Vector3 followPos = hit.point;
                followPos.y = holdHeight; // lock height above pizza
                heldItem.transform.position = followPos;
            }
        }
    }
}