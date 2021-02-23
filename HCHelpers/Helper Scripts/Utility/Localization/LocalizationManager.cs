using Ali.Helper;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LocalizationManager : GenericSingleton<LocalizationManager>
{
    GameLanguage currentLanguage;
    Dictionary<GameLanguage, LocalizationData> localizationDatas;
    UnityEvent onLanguageChanged;
    int languageIndex = 0;

    protected override void Awake()
    {
        base.Awake();
        localizationDatas = new Dictionary<GameLanguage, LocalizationData>();
        localizationDatas.Add(GameLanguage.EN, new LocalizationData(GameLanguage.EN));
        localizationDatas.Add(GameLanguage.TR, new LocalizationData(GameLanguage.TR));
        //localizationDatas.Add(GameLanguage.AR, new LocalizationData(GameLanguage.AR));
        onLanguageChanged = new UnityEvent();
        currentLanguage = (GameLanguage)SaveLoadManager.Instance.GetLanguage();
    }

    public void AddFunctionToChangeEvent(UnityAction action)
    {
        onLanguageChanged.AddListener(action);
    }

    public void RemoveFunctionFromChangeEvent(UnityAction action)
    {
        onLanguageChanged.RemoveListener(action);
    }

    public LocalizationData GetCurrentLocalizationData()
    {
        return localizationDatas[currentLanguage];
    }

    public void SwitchCurrentLocalizationData()
    {
        languageIndex = (languageIndex + 1) % localizationDatas.Count;
        currentLanguage = (GameLanguage)languageIndex;
        SaveLoadManager.Instance.SetLanguage(languageIndex);
        onLanguageChanged.Invoke();
    }

    public void SetLocalization(GameLanguage language)
    {
        languageIndex = (int)language;
        currentLanguage = language;
        SaveLoadManager.Instance.SetLanguage(languageIndex);
        onLanguageChanged.Invoke();
    }

    public string GetUIStringFromCode(string code, string defaultString = "")
    {
        return GetTextFromCodeAndColumnName(LocalizedType.UI, code, defaultString, "CONTENT");
    }

    public string GetTutorialFromCode(string code, string defaultString = "")
    {
        return GetTextFromCodeAndColumnName(LocalizedType.Tutorial, code, defaultString, "CONTENT");
    }

    public string GetTextFromCodeAndColumnName(LocalizedType type, string code, string defaultString = "", string columnName = "CONTENT")
    {
        return GetCurrentLocalizationData().GetValueByCode(type, code, defaultString, columnName);
    }


}


