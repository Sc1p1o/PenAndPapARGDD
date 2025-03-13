using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Stats.DataLoader
{
    public class LoadStat : MonoBehaviour
    
    {
        [FormerlySerializedAs("proficiencyValue")] public GameObject statValue;
        public GameObject loadedStatName;
        public string statNameString = "";
        private TextMeshProUGUI _statNameText;
        
        private TextMeshProUGUI _statValueString;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (loadedStatName != null)
            {
                _statNameText = loadedStatName.GetComponent<TextMeshProUGUI>();
                statNameString = _statNameText.text;
            }

            if (statValue != null)
            {
                _statValueString = statValue.GetComponent<TextMeshProUGUI>();
            }
            DBConnector.OnStatsUpdated += UpdateStatsValue;
        }
    
        void OnEnable()
        {
            DBConnector.OnStatsUpdated += UpdateStatsValue;
        }

        void OnDisable()
        {
            DBConnector.OnStatsUpdated -= UpdateStatsValue;
        }

        // Update is called once per frame

        private void UpdateStatsValue()
        {
            if(_statValueString != null)
            {
                string statValueText = DBConnector.GetStatValue(statNameString).ToString();
                _statValueString.text = statValueText;
            }
        }

        public void ChangeStatByValue(int value)
        {
            int currentStatValue = DBConnector.GetStatValue(statNameString);
            bool isChangeSuccessful = DBConnector.SetIntValue(statNameString, currentStatValue + value);
            if (isChangeSuccessful)
            {
                DBConnector.UpdateValues();
            }
            else Debug.Log("Change failed");
        }
    }
}
