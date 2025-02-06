using Microsoft.MixedReality.Toolkit.Editor;
using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Stats.OnStartUp
{
    public class LoadStat : MonoBehaviour
    
    {
        public GameObject proficiencyValue;
        public GameObject loadedStatName;
        private TextMeshProUGUI _statNameText;
        
        private TextMeshProUGUI _statValueString;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _statValueString = proficiencyValue.GetComponent<TextMeshProUGUI>();
            DBConnector.OnStatsUpdated += UpdateStatsValue;
            _statNameText = loadedStatName.GetComponent<TextMeshProUGUI>();

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
        void Update()
        {
        
        }

        private void UpdateStatsValue()
        {
            string statValueText = DBConnector.GetStatValue(_statNameText.text).ToString();
            
            _statValueString.text = statValueText;
        }
    }
}
