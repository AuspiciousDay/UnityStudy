using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class State
{
    public string name;
    public Vector3 position;
    public Quaternion rotation;
    public Vector3 scale;
    public Color color;
}

public class Buttons : MonoBehaviour
{
    public GameObject[] prefabs;
    private List<GameObject> objects = new List<GameObject>();

    private JsonSerializerSettings jsonSetting;
    private void Awake()
    {
        jsonSetting = new JsonSerializerSettings();
        jsonSetting.Formatting = Formatting.Indented;
        jsonSetting.Converters.Add(new Vector3Converter());
        jsonSetting.Converters.Add(new QuaternionConverter());
        jsonSetting.Converters.Add(new ColorConverter());
    }

    public void Create()
    {
        int randomIndex = Random.Range(0, prefabs.Length);
        Vector3 randomPosition = Random.insideUnitSphere * 10f;
        Quaternion randomRotation = Random.rotation;
        Vector3 randomScale = Vector3.one * Random.Range(0.5f, 2f);
        Color randomColor = Random.ColorHSV();

        GameObject newGo = Instantiate(prefabs[randomIndex]);
        newGo.transform.position = randomPosition;
        newGo.transform.rotation = randomRotation;
        newGo.transform.localScale = randomScale;
        Renderer rend = newGo.GetComponent<Renderer>();
        rend.material.color = randomColor;

        objects.Add(newGo);
    }
    public void Clear()
    {
        foreach (GameObject obj in objects)
        {
            Destroy(obj);
        }
        objects.Clear();
    }
    public void Save()
    {
        List<State> saveData = new List<State>();
        foreach (GameObject obj in objects)
        {
            State data = new State();
            data.name = obj.name;
            data.position = obj.transform.position;
            data.rotation = obj.transform.rotation;
            data.scale = obj.transform.localScale;
            Renderer rend = obj.GetComponent<Renderer>();
            data.color = rend.material.color;
            saveData.Add(data);
        }

        string json = JsonConvert.SerializeObject(saveData, jsonSetting);

        string path = Path.Combine(Application.persistentDataPath, "test2.json");
        File.WriteAllText(path, json);
    }

    public void Load()
    {
        Clear();
        string path = Path.Combine(Application.persistentDataPath, "test2.json");
        string json = File.ReadAllText(path);
        var saveData = JsonConvert.DeserializeObject<List<State>>(json, jsonSetting);
        foreach (var data in saveData)
        {
            int prefabIndex = -1;
            for (int i = 0; i < prefabs.Length; i++)
            {
                if (data.name.Contains(prefabs[i].name))
                {
                    prefabIndex = i;
                    break;
                }
            }

            var newGo = Instantiate(prefabs[prefabIndex]);
            newGo.transform.position = data.position;
            newGo.transform.rotation = data.rotation;
            newGo.transform.localScale = data.scale;
            Renderer rend = newGo.GetComponent<Renderer>();
            rend.material.color = data.color;

            objects.Add(newGo);
        }
    }
}

