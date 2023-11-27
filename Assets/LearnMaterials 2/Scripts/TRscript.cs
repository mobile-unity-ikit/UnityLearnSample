using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRscript : MonoBehaviour
{
    [SerializeField]
    public Transform target;

    [SerializeField]
    [Range(0.1f, 5f)]
    float duration;

    [ContextMenu("оч")]
    public void Use()
    {
        if (target != null)
        {
            StartCoroutine(ShrinkAndDestroy());
        }
        else
        {
            Debug.LogError("Target is not assigned!");
        }
    }

    private IEnumerator ShrinkAndDestroy()
    {
        if (target != null)
        {
            Transform[] children = new Transform[target.childCount];
            for (int i = 0; i < target.childCount; i++)
            {
                children[i] = target.GetChild(i);
            }

            float elapsed = 0f;

            while (elapsed < duration)
            {
                float scale = Mathf.Lerp(1f, 0f, elapsed / duration);

                foreach (Transform child in children)
                {
                    child.localScale = new Vector3(scale, scale, scale);
                }

                elapsed += Time.deltaTime;

                yield return null;
            }

            foreach (Transform child in children)
            {
                Destroy(child.gameObject);
            }
        }
    }
}
