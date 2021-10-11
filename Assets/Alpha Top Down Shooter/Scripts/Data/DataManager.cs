using System;
using System.IO;
using Alpha.UI;
using UnityEngine;

namespace Alpha.Data
{
    public class DataManager : MonoBehaviour
    {
        private Data data = new Data();

        #region Property

        public int Score
        {
            get => data.score;
            set
            {
                data.score = value;
                SaveToJson();
            }
        }

        public float SoundVolume
        {
            get => data.soundVolume;
            set
            {
                data.soundVolume = value;
                SaveToJson();
            }
        }

        public float MusicVolume
        {
            get => data.musicVolume;
            set
            {
                data.musicVolume = value;
                SaveToJson();
            }
        }

        public bool FullScreen
        {
            get => data.fullScreen;
            set
            {
                data.fullScreen = value;
                SaveToJson();
            }
        }

        public ScreenResolutions16and9 Resolution
        {
            get => data.resolution;
            set
            {
                data.resolution = value;
                SaveToJson();
            }
        }
        public int ResWidth
        {
            get => data.resWidth;
            set
            {
                data.resWidth = value;
                SaveToJson();
            }
        }
        public int ResHeight
        {
            get => data.resHeight;
            set
            {
                data.resHeight = value;
                SaveToJson();
            }
        }

        public bool TutorialLearned
        {
            get => data.tutorialLearned;
            set
            {
                data.tutorialLearned = value;
                SaveToJson();
            }
        }
        #endregion


        private void Awake()
        {
            LoadDataFromJson();
        }

        private void SaveToJson()
        {
            // путь к файлу
            string filePath = Path.Combine(Application.dataPath, "GameData.json"); // это то же самое, что Application.dataPath+"\SaveData.json"

            // переносим все переменные класса в формат json
            string jsonData = JsonUtility.ToJson(data);
            // записываем данные в файл
            File.WriteAllText(filePath, jsonData);
            //Debug.Log("Game saved to: " + filePath);
        }

        /// <summary>
        /// Загружает данные из JSON
        /// </summary>
        private void LoadDataFromJson()
        {
            //string filePath = Path.Combine(Application.dataPath, "SaveData.json");
            string filePath = Path.Combine(Application.dataPath, "GameData.json");
            // если файл существует
            if (File.Exists(filePath))
            {
                // вытаскиваем их файла все данные в формате json
                string jsonData = File.ReadAllText(filePath);
                // переносим данные в класс
                JsonUtility.FromJsonOverwrite(jsonData, data);
                //Debug.Log("Game loaded from: " + filePath);
            }
            else
            {
                SaveToJson();
            }
        }
    }
}