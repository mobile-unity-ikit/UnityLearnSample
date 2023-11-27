
using System.Collections;
using UnityEngine;

public class LoomeL_Script : SampleScript
{
    [SerializeField]
    [Range(0.1f, 2f)]
    private float rotationTime;
    [SerializeField]
    private Vector3 rotationAngles = new Vector3(90f, 0f, 0f);

    private Quaternion targetRotation;
    [SerializeField]
    private bool isRotating = false;

    [ContextMenu("Use")]
    public override void Use()
    {
        if (!isRotating)
        {
            targetRotation = Quaternion.Euler(rotationAngles);
            StartCoroutine(RotateObject());
        }
    }

    private IEnumerator RotateObject()
    {
        isRotating = true;

        float elapsedTime = 0f;
        Quaternion initialRotation = transform.rotation;

        while (elapsedTime < rotationTime)
        {
            float t = elapsedTime / rotationTime;
            transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, t);
            elapsedTime += Time.deltaTime;
            yield return null;
        }

        transform.rotation = targetRotation;
        isRotating = false;
    }
}