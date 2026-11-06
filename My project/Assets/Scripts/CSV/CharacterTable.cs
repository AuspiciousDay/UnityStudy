using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class CharacterTable : DataTable
{
    private readonly Dictionary<string, CharacterData> tables = new Dictionary<string, CharacterData>();
    public override void Load(string filename)
    {
        tables.Clear();

        var path = string.Format(FormatPath, filename);
        var textAsset = Resources.Load<TextAsset>(path);
        var list = LoadCSV<CharacterData>(textAsset.text);
        foreach(var character in list)
        {
            if (!tables.ContainsKey(character.Id))
            {
                tables.Add(character.Id, character);
            }
            else
            {
                Debug.Log("캐릭터 아이디 중복");
            }
        }
    }

    public CharacterData Get(string id)
    {
        if (!tables.ContainsKey(id))
        {
            Debug.LogError($"{id}: 캐릭터 없음");
            return  null;
        }
        return tables[id];
    }
    public CharacterData GetRandom()
    {
        var characterList = tables.Values.ToList();
        return characterList[Random.Range(0, characterList.Count)];
    }
}
