using UnityEngine;
using Newtonsoft.Json;
using System;
public class SaveCharacterData
{
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(CharacterDataConverter))]
    public CharacterData CharacterData { get; set; }
    public DateTime CreationTime { get; set; }

    public SaveCharacterData()
    {
        InstanceId = Guid.NewGuid();
        CreationTime = DateTime.Now;
    }

    public override string ToString()
    {
        return $"{InstanceId} {CharacterData.Id} : ({CreationTime})";
    }

    public static SaveCharacterData GetRandomCharacter()
    {
        var newCharactor = new SaveCharacterData();
        newCharactor.CharacterData = DataTableManager.CharacterTable.GetRandom();
        return newCharactor;
    }
}
