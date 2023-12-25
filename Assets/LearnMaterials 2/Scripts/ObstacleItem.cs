using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ObstacleItem : MonoBehaviour
{
    [SerializeField]
    private float currentValue = 1f;
    [SerializeField]
    private UnityEvent onDestroyObstacle;
    
    private Renderer renderer;
    private Color startColor;
    private Color endColor;

    private void Start()
    {
        renderer = GetComponent<Renderer>();
        startColor = renderer.material.color;
        endColor = Color.red;
    }
    
    public void GetDamage(float value)
    {
        currentValue -= value;
        currentValue = Mathf.Clamp(currentValue, 0, 1);

        ChangeColor();

        if (currentValue <= 0)
        {
            onDestroyObstacle.Invoke();
            Destroy(gameObject);
        }
    }

    private void ChangeColor()
    {
        renderer.material.color = Color.Lerp(endColor, startColor, currentValue);
    }
}
