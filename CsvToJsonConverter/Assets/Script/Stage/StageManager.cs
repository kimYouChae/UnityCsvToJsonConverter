using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StageManager : MonoBehaviour
{
    [Header("===�ν����� â���� �������� List===")]
    [SerializeField] private List<Stage> stages;

    void Start()
    {
        var temp = JsonSerialized.Deserialization<Stage>("Stage");

        foreach (var stage in temp) 
        {
            Debug.Log(stage.StageIdx);
        }
    }


}
