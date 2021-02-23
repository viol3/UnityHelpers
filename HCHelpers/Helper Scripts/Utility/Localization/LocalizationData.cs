using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocalizationData
{
    GameLanguage language;
    CSVObject tutorialCSV;
    CSVObject uiCSV;

    public LocalizationData(GameLanguage language)
    {
        this.language = language;
        InitUnits();
        InitMenu();
    }

    void InitUnits()
    {
        tutorialCSV = CSVReader.Read(Resources.Load<TextAsset>("Localization/" + language.ToString() + "/Tutorial").text);
    }

    void InitMenu()
    {
        uiCSV = CSVReader.Read(Resources.Load<TextAsset>("Localization/" + language.ToString() + "/UI").text);
    }

    public GameLanguage GetGameLanguage()
    {
        return language;
    }

    public string GetValueByCode(LocalizedType type, string code, string defaultString, string columnName)
    {
        if(type == LocalizedType.UI)
        {
            Dictionary<string, object> data = uiCSV.GetDataByCode(code);
            if (data != null && data[columnName] != null)
            {
                return data[columnName].ToString();
            }
            else
            {
                Debug.LogWarning("There is localization error. TYPE : " + type + " ||| CODE :" + code + " ||| COLUMN NAME : " + columnName);
                return defaultString;
            }
            
        }
        else if (type == LocalizedType.Tutorial)
        {
            if (tutorialCSV.GetDataByCode(code)[columnName] != null)
            {
                return tutorialCSV.GetDataByCode(code)[columnName].ToString();
            }
            else
            {
                Debug.LogWarning("There is localization error. TYPE : " + type + " ||| CODE :" + code + " ||| COLUMN NAME : " + columnName);
                return defaultString;
            }
        }
        return "";
    }
}


