using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICsvParsable
{
    void Parse(string[] values);

}

[System.Serializable]
public class Stage : ICsvParsable
{
    [SerializeField] private int hp;
    [SerializeField] private string name;
    [SerializeField] private List<string> animal;

    public void Parse(string[] values)
    {
        hp = int.Parse(values[0]);
        name = values[1];

        animal = new List<string>();
        string[] temp = values[3].Split('-');
        for (int i = 0; i < temp.Length; i++)
        {
            animal.Add(temp[i]);
        }
    }
}
