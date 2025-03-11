using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private string wapperClassName = "ItemWrapper";

    [Header("=== ������ �����͸� ���� �������� ���� Dictionray ===")]
    private Dictionary<int, Item> itemDictionray;

    [Header("===�ν����� â���� �������� List===")]
    [SerializeField] private List<Item> itemList;

    void Start()
    {
        InitItem();
    }

    private void InitItem() 
    {
        List<ItemWrapper> itemWrapperList = 
            JsonSerialized.Deserialization<ItemWrapper>(wapperClassName);

        itemDictionray = new Dictionary<int, Item>();
        itemList = new List<Item>();

        // ��ųʸ��� �˸°� �ֱ�
        foreach (var wrapper in itemWrapperList)
        {
            Weapon weapon = new Weapon
                   (
                       wrapper.ItemNum,
                       wrapper.ItemType,
                       wrapper.ItemName,
                       wrapper.ItemToopTip,
                       wrapper.AttackSpeed,
                       wrapper.AttackDamage,
                       wrapper.DurationTime
                   );

            // ��ųʸ��� ���� 
            itemDictionray[wrapper.ItemNum] = weapon;

            // (�ӽ�)����Ʈ�� ����
            itemList.Add(weapon);
        }

    }

}
