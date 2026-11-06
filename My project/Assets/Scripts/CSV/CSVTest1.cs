using UnityEngine;
using CsvHelper;
using System.IO;
using System.Globalization;

public class CsvData
{
    public string Id { get; set; }
    public string String { get; set; }
}

public class CSVTest1 : MonoBehaviour
{
    public UICharacterButton[] characterButtons;
    public UICharacterInfo characterInfo;
    private void Start()
    {
        characterButtons[0].SetCharacter("CHAR_1");
        characterButtons[0].button.onClick.AddListener(() => characterInfo.SetCharacter("CHAR_1"));

        characterButtons[1].SetCharacter("CHAR_2");
        characterButtons[1].button.onClick.AddListener(() => characterInfo.SetCharacter("CHAR_2"));

        characterButtons[2].SetCharacter("CHAR_3");
        characterButtons[2].button.onClick.AddListener(() => characterInfo.SetCharacter("CHAR_3"));

        characterButtons[3].SetCharacter("CHAR_4");
        characterButtons[3].button.onClick.AddListener(() => characterInfo.SetCharacter("CHAR_4"));
    }


    // private StringTable stringTable;

    // private void Start()
    // {
    //     stringTable = DataTableManager.StringTable;

    //     Debug.Log(stringTable.Get("HELLO"));
    //     Debug.Log(stringTable.Get("BYE"));
    //     Debug.Log(stringTable.Get("YOU_DIE"));

    //     var itemData = DataTableManager.ItemTable.Get("ITEM_1");
    //     Debug.Log($"{itemData.StringName},{itemData.StringDesc}");
    // }
    // public TextAsset textAsset;
    // private void Start()
    // {
    //     TextAsset csv = Resources.Load<TextAsset>("DataTables/StringTableKr");
    //     using(var reader = new StringReader(csv.text))
    //     using(var csvReader = new CsvReader(reader, CultureInfo.InvariantCulture))
    //     {
    //         var records = csvReader.GetRecords<CsvData>();
    //         foreach(var record in records)
    //         {
    //             Debug.Log($"{record.Id} : {record.String}");
    //         }
    //     }
    // }
}
