using UnityEngine;
using Newtonsoft.Json;
using System;
using System.IO;

[Serializable]
public class PlayerState
{
    public string playerName;
    public int lives;
    public float health;
    public Vector3 position;
    public Quaternion rotation;
    public Color color;

    public override string ToString()
    {
        return $"{playerName} / {lives} / {health} / {position} / {rotation} / {color}";
    }
}


public class JsonTest1 : MonoBehaviour
{
    private void Start()
    {
        var obj = new PlayerState
        {
            playerName = "ABC",
            lives = 10,
            health = 10.999f,
            position = new Vector3(1f, 2f, 3f),
            rotation = new Quaternion(1f, 2f, 3f, 4f),
            color = new Color(0.5f, 0.6f, 0.7f, 0.8f)
        };

        var path = Path.Combine(Application.persistentDataPath, "test.json");
        string json = JsonConvert.SerializeObject(obj, Formatting.Indented, new Vector3Converter(), new QuaternionConverter(), new ColorConverter()); // 직렬화
        File.WriteAllText(path, json);

        var json2 = File.ReadAllText(path);
        var obj2 = JsonConvert.DeserializeObject<PlayerState>(json2, new Vector3Converter(), new QuaternionConverter(), new ColorConverter()); // 역직렬화
        Debug.Log(obj2);
    }
}


// JsonSerializationException: Self referencing loop detected for property 'normalized' with type 'UnityEngine.Vector3'. Path 'position.normalized.normalized'. // 그냥 Vector3를 저장할시 저장 무한루프 오류

// JsonSerializationException: Self referencing loop detected for property 'normalized' with type 'UnityEngine.Quaternion'. Path 'rotation.normalized'.