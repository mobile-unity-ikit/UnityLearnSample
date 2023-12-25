using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractiveBox : MonoBehaviour
{
    [SerializeField]
    private InteractiveBox next;

    public void AddNext(InteractiveBox box)
    {
        next = box;
    }

    void Update()
    {
        if (next != null)
        {
            Debug.DrawLine(transform.position, next.transform.position, Color.red);
            if (Physics.Raycast(transform.position, (next.transform.position - transform.position).normalized, out var hit))
            {
                ObstacleItem obstacle = hit.collider.GetComponent<ObstacleItem>();
                obstacle?.GetDamage(Time.deltaTime);
            }
        }
    }
}
