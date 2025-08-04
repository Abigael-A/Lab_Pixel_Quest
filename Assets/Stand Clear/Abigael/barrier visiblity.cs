using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class barriervisiblity : MonoBehaviour
{
    public string targetTag = "Enemy";

    private Renderer objectRenderer;
    // Start is called before the first frame update
    void Start()
    {
        objectRenderer = GetComponent<Renderer>();
        SetVisibility(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(targetTag))
        {
            SetVisibility(false);
        }
    }

    void SetVisibility(bool isVisible)
    {
        if (objectRenderer != null)
        {
            objectRenderer.enabled = isVisible;
        }
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(1)) // Right-click
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform == this.transform)
                {
                    SetVisibility(true);
                }
            }
        }
    }
    void ToggleVisibility()
    {
        if (objectRenderer != null)
        {
            objectRenderer.enabled = !objectRenderer.enabled;
        }
    }
}
