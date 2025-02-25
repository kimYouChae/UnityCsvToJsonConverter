using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

[CustomEditor(typeof(CsvToJsonConverter))]
public class CsvJsonButton : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        CsvToJsonConverter mana = (CsvToJsonConverter)target;

        if (GUILayout.Button("Cvs to Json"))
        {
            mana.CsvConverByName();
        }
    }
}
