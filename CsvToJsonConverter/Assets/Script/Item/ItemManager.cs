using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemManager : MonoBehaviour
{
    private string wapperClassName = "ItemWrapper";

    [Header("=== 아이템 데이터를 쉽게 가져가기 위한 Dictionray ===")]
    private Dictionary<int, Item> itemDictionray;

    [Header("===인스펙터 창에서 보기위한 List===")]
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

        // 딕셔너리에 알맞게 넣기
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

            // 딕셔너리에 저장 
            itemDictionray[wrapper.ItemNum] = weapon;

            // (임시)리스트에 저장
            itemList.Add(weapon);
        }

    }

}
