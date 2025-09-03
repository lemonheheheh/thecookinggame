using UnityEngine;

public class ClickPickup : MonoBehaviour
{
    [Header("Pizza Layers")]
    public GameObject mushroomLayer; // assign this in Inspector

    private GameObject heldItem;
    public float holdDistance = 5f;   // distance from camera while dragging
    public float dropHeight = 0.5f;   // height above pizza when dropped

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
                // Drop ingredient on pizza
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit))
                {
                    // Show mushroom layer
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
            Vector3 mousePos = Input.mousePosition;
            mousePos.z = holdDistance; // lock to a fixed distance
            Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);

            heldItem.transform.position = worldPos;
        }
    }
}