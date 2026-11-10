using UnityEngine;
using Newtonsoft.Json;
using System;

public class SaveItemData
{
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(ItemDataConverter))]
    public ItemData ItemData { get; set; }
    public DateTime CreationTime { get; set; }

    public SaveItemData()
    {
        InstanceId = Guid.NewGuid(); // 값이 큰 난수를 리턴
        CreationTime = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{InstanceId} {ItemData.Id} : ({CreationTime})";
    }

    public static SaveItemData GetRandomItem()
    {
        var newItem = new SaveItemData();
        newItem.ItemData = DataTableManager.ItemTable.GetRandom();
        return newItem;
    }
}
