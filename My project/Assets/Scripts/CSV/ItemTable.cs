using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ItemTable : DataTable
{
    private readonly Dictionary<string, ItemData> tables = new Dictionary<string, ItemData>();

    public override void Load(string filename)
    {
        tables.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<ItemData>(textAsset.text);
        foreach (var item in list)
        {
            if (!tables.ContainsKey(item.Id))
            {
                tables.Add(item.Id, item);
            }
            else
            {
                Debug.Log("아이템 아이디 중복");
            }
        }
    }

    public ItemData Get(string id)
    {
        if (!tables.ContainsKey(id))
        {
            Debug.LogError($"{id}: 아이템 없음");
            return null;
        }
        return tables[id];
    }

    public ItemData GetRandom()
    {
        var itemList = tables.Values.ToList();
        return itemList[Random.Range(0, itemList.Count)];
    }
}
