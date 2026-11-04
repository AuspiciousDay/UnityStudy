using UnityEngine;
using System.IO;

public class Practice2 : MonoBehaviour
{
    private string path1;
    private string path2;
    private string path3;
    private void Start()
    {
        path1 = Path.Combine(Application.persistentDataPath, "original.txt");
        path2 = Path.Combine(Application.persistentDataPath, "encrypted.dat");
        path3 = Path.Combine(Application.persistentDataPath, "decrypted.txt");
        File.WriteAllText(path1, "Hello Unity World");

        using (StreamReader reader = File.OpenText(path1))
        {
            string line = reader.ReadLine();
            Debug.Log($"원본: {line}");
        }

        using (FileStream fs = new FileStream(path1, FileMode.Open))
        using (FileStream fs2 = new FileStream(path2, FileMode.Create))
        {
            int readbyte;

            while ((readbyte = fs.ReadByte()) != -1)
            {
                fs2.WriteByte((byte)(readbyte ^ 0xAB));
            }
            Debug.Log($"암호화 완료 (파일 크기: {fs2.Length} bytes)");
        }

        using (FileStream fs = new FileStream(path3, FileMode.Create))
        using (FileStream reader = new FileStream(path2, FileMode.Open))
        {
            int readbyte;

            while ((readbyte = reader.ReadByte()) != -1)
            {
                fs.WriteByte((byte)(readbyte ^ 0xAB));
            }
            Debug.Log($"복호화 완료");
        }

        using (StreamReader reader1 = File.OpenText(path1))
        using (StreamReader reader2 = File.OpenText(path3))
        {
            string line2 = reader2.ReadLine();
            Debug.Log($"복호화 결과: {line2}");
            string line1 = reader1.ReadLine();
            Debug.Log($"원본과 일치: {line2 == line1}");
        }


    }
}
