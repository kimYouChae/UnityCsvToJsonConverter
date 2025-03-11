using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Stage
{
    [SerializeField] private int stageIndex;
    [SerializeField] private float stageMinute;

    public int StageIdx { get => stageIndex; }
    public float StageTime { get => stageMinute;  }

    public Stage( int h , float n) 
    { 
        this.stageIndex = h ;
        this.stageMinute = n ;
    }

}
