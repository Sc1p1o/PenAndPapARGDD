using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Stats.OnStartUp
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
            _statValueString = statValue.GetComponent<TextMeshProUGUI>();
            
            DBConnector.OnStatsUpdated += UpdateStatsValue;
            UpdateStatsValue();

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
            if ((_statNameText == null) && statNameString == "") return;
            string statValueText = DBConnector.GetStatValue(statNameString).ToString();
            
            _statValueString.text = statValueText;
        }
    }
}
