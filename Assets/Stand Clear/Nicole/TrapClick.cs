using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class TrapClick : MonoBehaviour
{
    public GameObject ObjectToShow;
    public string currenlyLooking;
    public Camera camera;

    public Rect allowedScreenArea = new Rect(100, 100, 400, 300);
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Check for left mouse button click
        if (Input.GetMouseButtonDown(1))  // 1 is for right-click
        {
            Vector2 mousePos = Input.mousePosition;

            // Convert to world position
            Vector2 mouseWorldPos = camera.ScreenToWorldPoint(mousePos);

            // Create a ray from the mouse position
            RaycastHit2D hit = Physics2D.Raycast(mouseWorldPos, Vector2.zero);

            currenlyLooking = hit.collider.gameObject.name;
            if (allowedScreenArea.Contains(mousePos) && hit.collider != null)
            {
                // Check if the hit object has the tag "Zone" and not "Barrier"
                if (hit.collider.CompareTag("Zone") && !hit.collider.CompareTag("Barrier"))
                {
                    // Instantiate the object at the mouse position in world space
                    Instantiate(ObjectToShow, mouseWorldPos, Quaternion.identity);
                }
            }
        }

        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                currenlyLooking = hit.collider.name;
                if (hit.collider.tag == "Zone" && hit.collider.tag != "Trap")
                {
                    Vector3 spawnPoint = hit.point;


                    Instantiate(ObjectToShow, spawnPoint, Quaternion.identity);


                }

            }
        }

    }
    bool IsAreaClear(Vector2 position, float radius)
    {
        Collider2D[] hits = Physics2D.OverlapCircleAll(position, radius);
        return hits.Length == 0;

    }
}