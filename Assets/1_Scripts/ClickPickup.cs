using System;
using _1_Scripts;
using UnityEngine;

public class ClickPickup : MonoBehaviour
{
    private GameObject heldItem;
    public float holdHeight = 0.5f;      // height above pizza while dragging
    public float followSpeed = 15f;      // smoothing speed

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
        if (Input.GetMouseButtonDown(0))
        {
            if (heldItem == null)
            {
                TryPickUp();
            }
            else
            {
                DropItem();
            }
        }

        if (heldItem != null)
        {
            MoveHeldItem();
        }
    }

    private void TryPickUp()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit, Mathf.Infinity))
        {
            if (hit.collider.CompareTag("Ingredient"))
            {
                heldItem = hit.collider.gameObject;
                Debug.Log("Picked up: " + heldItem.name);

                // Disable physics while dragging
                if (heldItem.TryGetComponent<Rigidbody>(out Rigidbody rb))
                {
                    rb.isKinematic = true;
                }
            }
        }
    }

    private void DropItem()
    {
        Debug.Log("Dropped: " + heldItem.name);

        // Re-enable physics when dropped
        if (heldItem.TryGetComponent<Rigidbody>(out Rigidbody rb))
        {
            rb.isKinematic = false;
        }

        heldItem = null;
    }

    private void MoveHeldItem()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero); // y=0 plane
        if (plane.Raycast(ray, out float distance))
        {
            Vector3 targetPos = ray.GetPoint(distance);
            targetPos.y = holdHeight;

            // Smooth movement
            heldItem.transform.position = Vector3.Lerp(
                heldItem.transform.position,
                targetPos,
                Time.deltaTime * followSpeed
            );
        }
    }

    private void ReleaseItem()
    {
        Debug.Log("ReleaseItem");
        DropItem();
    }
}