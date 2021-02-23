using Ali.Helper.Idle;
using System;
using UnityEngine;

namespace Ali.Helper
{
    public class SaveLoadManager
    {
        const string SAVED_DATA = "SAVED_DATA";
        const string LAST_QUIT_TIME = "LAST_QUIT_TIME";
        const string COLLECTED_OFFLINE_GOLD = "COLLECTED_OFFLINE_GOLD";
        const string TUTORIAL = "TUTORIAL";
        const string SFX = "SFX";
        const string MUSIC = "MUSIC";
        const string LANGUAGE = "LANGUAGE";

        private static SaveLoadManager instance = null;
        public static SaveLoadManager Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new SaveLoadManager();
                }
                return instance;
            }
        }

        public void Init()
        {

        }

        public void DeleteSavedGame()
        {
            if (PlayerPrefs.HasKey(SAVED_DATA))
            {
                PlayerPrefs.DeleteKey(SAVED_DATA);
            }
        }

        public void SaveGame<T>(T obj)
        {
            string result = SerializationManager.SerializeObject(obj);
            PlayerPrefs.SetString(SAVED_DATA, result);
            PlayerPrefs.SetString(LAST_QUIT_TIME, DateTime.Now.Ticks.ToString());
        }

        public bool IsTutorialFinished()
        {
            return PlayerPrefs.GetInt(TUTORIAL) == 1;
        }

        public void FinishTutorial()
        {
            PlayerPrefs.SetInt(TUTORIAL, 1);
            PlayerPrefs.Save();
        }

        public void ResetTutorial()
        {
            PlayerPrefs.SetInt(TUTORIAL, 0);
            PlayerPrefs.Save();
        }

        public void SetLanguage(int value)
        {
            PlayerPrefs.SetInt(LANGUAGE, value);
            PlayerPrefs.Save();
        }

        public int GetLanguage()
        {
            CheckForLanguage();
            return PlayerPrefs.GetInt(LANGUAGE);
        }

        public void SetMusicMute(bool value)
        {
            PlayerPrefs.SetInt(MUSIC, value ? 1 : 0);
            PlayerPrefs.Save();
        }

        public bool GetMusicMute()
        {
            return PlayerPrefs.GetInt(MUSIC) == 1;
        }

        public void SetSFXMute(bool value)
        {
            PlayerPrefs.SetInt(SFX, value ? 1 : 0);
            PlayerPrefs.Save();
        }

        public bool GetSFXMute()
        {
            return PlayerPrefs.GetInt(SFX) == 1;
        }

        public double GetOfflineSeconds()
        {
            if (PlayerPrefs.HasKey(LAST_QUIT_TIME))
            {
                long oldTicks = long.Parse(PlayerPrefs.GetString(LAST_QUIT_TIME));
                long newTicks = DateTime.Now.Ticks;
                return TimeSpan.FromTicks(newTicks - oldTicks).TotalSeconds;
            }
            return 0;
        }

        public HugeNumber GetCollectedOfflineGold()
        {
            if (PlayerPrefs.HasKey(COLLECTED_OFFLINE_GOLD))
            {
                return HugeNumber.Parse(PlayerPrefs.GetString(COLLECTED_OFFLINE_GOLD));
            }
            else
            {
                ResetCollectedOfflineGold();
            }
            return new HugeNumber(0);
        }

        public void ResetCollectedOfflineGold()
        {
            PlayerPrefs.SetString(COLLECTED_OFFLINE_GOLD, "0");
        }

        public void SetCollectedOfflineGold(HugeNumber hugeNumber)
        {
            PlayerPrefs.SetString(COLLECTED_OFFLINE_GOLD, hugeNumber.ToFloatString(3));
            PlayerPrefs.Save();
        }


        void CheckForLanguage()
        {
            if (PlayerPrefs.HasKey(LANGUAGE))
            {
                return;
            }
            if (Application.systemLanguage == SystemLanguage.English)
            {
                PlayerPrefs.SetInt(LANGUAGE, 0);
            }
            else if (Application.systemLanguage == SystemLanguage.Turkish)
            {
                PlayerPrefs.SetInt(LANGUAGE, 1);
            }
            else
            {
                PlayerPrefs.SetInt(LANGUAGE, 0);
            }
            PlayerPrefs.Save();
        }

    }
}