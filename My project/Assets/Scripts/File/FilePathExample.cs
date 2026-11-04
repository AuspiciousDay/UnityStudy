using UnityEngine;

public class FilePathExample : MonoBehaviour
{
    void Start()
    {
        Debug.Log($"persistentDataPath: {Application.persistentDataPath}");
        Debug.Log($"dataPath: {Application.dataPath}");
        Debug.Log($"streamingAssetsPath: {Application.streamingAssetsPath}");
    }
}

/*
persistentDataPath: C:/Users/양정일/AppData/LocalLow/DefaultCompany/My project
UnityEngine.Debug:Log (object)
FilePathExample:Start () (at Assets/Scripts/FilePathExample.cs:7)


dataPath: C:/Users/양정일/Unity/Unity/UnityStudy/My project/Assets
UnityEngine.Debug:Log (object)
FilePathExample:Start () (at Assets/Scripts/FilePathExample.cs:8)

streamingAssetsPath: C:/Users/양정일/Unity/Unity/UnityStudy/My project/Assets/StreamingAssets
UnityEngine.Debug:Log (object)
FilePathExample:Start () (at Assets/Scripts/FilePathExample.cs:9)

*/