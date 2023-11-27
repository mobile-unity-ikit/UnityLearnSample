using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Kirill_Script : SampleScript
{
    [SerializeField]
    private GameObject prefab;
    [SerializeField]
    [Range(1, 100)]
    private int repetitions;
    [SerializeField]
    [Range(0.1f, 100)]
    private float step;


    [ContextMenu("Use")]
    public override void Use()
    {
        for (int i = 0; i < repetitions; i++)
        {
            Instantiate(prefab, transform.position + i * step * transform.forward, Quaternion.identity);
        }
    }
}
