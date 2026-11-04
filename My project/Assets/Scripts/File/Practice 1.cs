using UnityEngine;
using System.IO;

public class Practice1 : MonoBehaviour
{
    private string folder;
    private string path;
    private string file;

    private void Start()
    {
        folder = Path.Combine(Application.persistentDataPath, "SaveData");
        if (!Directory.Exists(folder))
        {
            Directory.CreateDirectory(folder);
        }
        for (int i = 0; i < 3; i++)
        {
            path = Path.Combine(folder, $"save{i + 1}.txt");
            string text = $"내용{i + 1}";
            File.WriteAllText(path, text);
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Copy();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Delete();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PrintAll();
        }
    }

    private void Copy()
    {
        path = Path.Combine(folder, "save1.txt");
        string payhDest = Path.Combine(folder, "save1_backup.txt");
        file = Path.GetFileName(path);
        string copyFile = Path.GetFileName(payhDest);
        File.Copy(path, payhDest);
        Debug.Log($"{file} -> {copyFile} 복사 완료");
    }
    private void Delete()
    {
        path = Path.Combine(folder, "save3.txt");
        file = Path.GetFileName(path);
        if (!File.Exists(path))
        {
            Debug.Log("없음");
            return;
        }
        File.Delete(path);
        Debug.Log($"{file} 삭제 완료");
    }

    private void PrintAll()
    {
        path = Path.Combine(folder);
            
        string[] files = Directory.GetFiles(path);
        Debug.Log("=== 파일 목록 ===");
        for (int i = 0; i < 3; i++)
        {
            file = Path.GetFileName(files[i]);            
            Debug.Log($"- {file} (.txt)");
        }
    }

}
