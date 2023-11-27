using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SampleScriptExecutor : MonoBehaviour
{
    [SerializeField]
    private List<SampleScript> sampleScriptList = new List<SampleScript>();

    [ContextMenu("Выполнить все Use()")]
    public void ExecuteAllScripts()
    {
        foreach (var script in sampleScriptList)
        {
            script.Use();
        }
    }
}
