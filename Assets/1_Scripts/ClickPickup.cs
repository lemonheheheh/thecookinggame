using System;
using _1_Scripts;
using UnityEngine;

public class ClickPickup : MonoBehaviour
{
    private GameObject heldItem;
    public float holdHeight = 0.5f; // height above pizza while dragging

    private void Awake()
    {
        TimerEvents.TimerEnds += ReleaseItem;
    }

    private void OnDisable()
    {
        TimerEvents.TimerEnds -= ReleaseItem;
    }

    void Update()
    {
        // Pick up / drop ingredient
        if (Input.GetMouseButtonDown(0))
        {
            if (heldItem == null)
            {
                // Cast a ray from camera through mouse
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Ingredient"))
                    {
                        heldItem = hit.collider.gameObject;
                        Debug.Log("Picked up: " + heldItem.name);
                    }
                }
            }
            else
            {
                // Release ingredient (do NOT destroy it here)
                heldItem = null;
            }
        }

        // Move held ingredient with mouse
        if (heldItem != null)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Plane plane = new Plane(Vector3.up, Vector3.zero); // horizontal plane at y=0
            if (plane.Raycast(ray, out float distance))
            {
                Vector3 worldPos = ray.GetPoint(distance);
                worldPos.y = holdHeight; // lock above pizza
                heldItem.transform.position = worldPos;
            }
        }
    }

    private void ReleaseItem()
    {
        Debug.Log("ReleaseItem");
        heldItem = null;
    }
}
