using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using UnityEngine;

[SerializeField]
public class ListWrapper<T>
{
    public List<T> values;
}


public static class JsonSerialized
{
    // C:\Users\[user name]\AppData\LocalLow\[company name]\[product name]
    static string savePath = Application.persistentDataPath;

    // ���� Ÿ���� ����Ʈ�� ��ȯ�ϴ� �޼��� (���÷��� ���)
    public static string ConvertOriginalListToJson(object dataArray, Type elementType)
    {
        // dataArray�� ���� List<T>
        // 1. ������ ListWrapper<tyoe> Ÿ�� ����
        Type wrapperType = typeof(ListWrapper<>).MakeGenericType(elementType);

        // 2. ���� �ν��Ͻ� ����
        object wrapper = Activator.CreateInstance(wrapperType);

        // 3. values �ʵ� ��������
        FieldInfo valuesField = wrapperType.GetField("values");

        // 4. dataArray�� values �ʵ忡 �Ҵ�
        // dataArray�� objectŸ�������� �����δ� List<T> (�Ű������� List<T>�� �Ѱ�� ����)
        valuesField.SetValue(wrapper, dataArray);

        // 5. JsonUtility�� ����ȭ
        return JsonUtility.ToJson(wrapper);
    }

    public static void SaveJsonToFile(string json, string saveFileName)
    {
        try
        {
            string path = Path.Combine(savePath, saveFileName);
            File.WriteAllText(path, json);
            Debug.Log($"{saveFileName}�� ����Ǿ����ϴ�. ���: {path}");
        }
        catch (Exception ex)
        {
            Debug.LogError($"���� ���� �� ���� �߻�: {ex.Message}");
        }
    }

    // �ش� ��ο� �ִ� �ؽ�Ʈ ���� �������� 
    public static string GetTextFile(string fileName)
    {
        try
        {
            string path = Path.Combine(savePath, fileName);
            string readText = File.ReadAllText(path);

            return readText;
        }
        catch (Exception ex)
        {
            Debug.LogError($"���� �ҷ����� �� ���� �߻�: {ex.Message}");
            return "";
        }
    }

    // ������ȭ
    public static List<T> Deserialization<T>(string fileName)
    {
        string readText = GetTextFile(fileName);

        ListWrapper<T> temp = JsonUtility.FromJson<ListWrapper<T>>(readText);

        return temp.values;
    }


}
