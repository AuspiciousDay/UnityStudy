using UnityEngine;

public class SaveLoadTest1 : MonoBehaviour
{
    public void Save()
    {
        SaveLoadManager.Data = new SaveDataV4();
        SaveLoadManager.Data.PlayerFirstName = "Yang";
        SaveLoadManager.Data.PlayerLastName = "JeongIl";
        SaveLoadManager.Data.Gold = Random.Range(100,200);
        Debug.Log($"세이브 결과: {SaveLoadManager.Save()}");
    }

    public void Load()
    {
        Debug.Log($"로드 결과: {SaveLoadManager.Load()}");
        Debug.Log(SaveLoadManager.Data.PlayerFirstName);
        Debug.Log(SaveLoadManager.Data.PlayerLastName);
        Debug.Log(SaveLoadManager.Data.Gold);
    }
}
