using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveRaycast : MonoBehaviour
{

    [SerializeField]
    private GameObject prefab;
    private InteractiveBox savedBox;
    
    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            HandleLeftClick();
        }
        else if (Input.GetMouseButtonDown(1))
        {
            HandleRightClick();
        }
    }
    
    private void HandleLeftClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.CompareTag("InteractivePlane"))
            {
                CreateInteractiveBox(hit);
            }
            else
            {
                SetNextInteractiveBox(hit);
            }
        }
    }
    private void HandleRightClick()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            InteractiveBox hitBox = hit.collider.GetComponent<InteractiveBox>();
            if (hitBox != null)
            {
                Destroy(hitBox.gameObject);
            }
        }
    }

    private void CreateInteractiveBox(RaycastHit hit)
    {
        Vector3 position = hit.point + hit.normal * (prefab.transform.localScale.y / 2);
        Instantiate(prefab, position, Quaternion.identity);
    }

    private void SetNextInteractiveBox(RaycastHit hit)
    {
        InteractiveBox hitBox = hit.collider.GetComponent<InteractiveBox>();
        if (hitBox != null)
        {
            if (savedBox == null)
            {
                savedBox = hitBox;
            }
            else
            {
                savedBox.AddNext(hitBox);
            }
        }
    }
}
