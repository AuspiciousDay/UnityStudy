using UnityEngine;
using TMPro;
using System.Collections.Generic;

public class UiCharacterList : MonoBehaviour
{
    public readonly string[] SortingOptionNames = 
    {
        "SORT_DATE_ASC",
        "SORT_DATE_DESC",
        "SORT_NAME_ASC",
        "SORT_NAME_DESC",
    };

    public readonly string[] FilteringOptionNames =
    {
        "FILTER_ALL",
        "FILTER_WEAPON",
        "FILTER_EQUIP",
        "FILTER_CONSUMABLE",
    };
    public TMP_Dropdown sorting;
    public TMP_Dropdown filtering;

    public UiCharacterSlotList uiCharacterSlotList;

    private void OnEnable()
    {
        UpdateDropdownOptions();
        
        OnLoad();
        OnChangeSorting(sorting.value);
        OnChangeFiltering(filtering.value);

        Variables.OnLanguageChanged += UpdateDropdownOptions;
    }

    private void OnDisable()
    {
        Variables.OnLanguageChanged -= UpdateDropdownOptions;
        OnSave();
    }

    public void UpdateDropdownOptions()
    {
        var stringTable = DataTableManager.StringTable;
        sorting.ClearOptions();
        var options = new List<string>();
        foreach(var id in SortingOptionNames)
        {
            options.Add(stringTable.Get(id));
        }
        sorting.AddOptions(options);

        filtering.ClearOptions();
        options.Clear();
        foreach(var id in FilteringOptionNames)
        {
            options.Add(stringTable.Get(id));
        }
        filtering.AddOptions(options);
    }

    public void OnChangeSorting(int index)
    {
        uiCharacterSlotList.Sorting = (UiCharacterSlotList.SortingOptions)index;
    }

    public void OnChangeFiltering(int index)
    {
        uiCharacterSlotList.Filtering = (UiCharacterSlotList.FilteringOptions)index;
    }

    public void OnCreateCharacter()
    {
        uiCharacterSlotList.AddRandomCharacter();
    }

    public void OnRemoveCharacter()
    {
        uiCharacterSlotList.RemoveCharacter();
    }

    public void OnSave()
    {
        SaveLoadManager.Data.CharacterList = uiCharacterSlotList.GetSaveCharacterDataList();
        SaveLoadManager.Save();
    }

    public void OnLoad()
    {
        SaveLoadManager.Load();
        uiCharacterSlotList.SetSaveCharacterDataList(SaveLoadManager.Data.CharacterList);
    }
}
