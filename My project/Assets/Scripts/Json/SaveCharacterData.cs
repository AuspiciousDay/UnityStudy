using UnityEngine;
using Newtonsoft.Json;
using System;
public class SaveCharacterData : MonoBehaviour
{
    public Guid InstanceId { get; set; }

    [JsonConverter(typeof(CharacterDataConverter))]
    public CharacterData CharacterData { get; set; }
    public DateTime CreationTime { get; set; }

    public SaveCharacterData()
    {
        InstanceId = Guid.NewGuid(); // 값이 큰 난수를 리턴
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
