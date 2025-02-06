using TMPro;
using UnityEngine;
using Utils;

namespace Stats.OnStartUp
{
    public class LoadStat : MonoBehaviour
    
    {
        public GameObject proficiencyValue;
        
        TextMeshProUGUI proficiencyValueString;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            proficiencyValueString = proficiencyValue.GetComponent<TextMeshProUGUI>();
            StatsValuesDB.OnStatsUpdated += UpdateProficiency;
        }
    
        void OnEnable()
        {
            StatsValuesDB.OnStatsUpdated += UpdateProficiency;
        }

        void OnDisable()
        {
            StatsValuesDB.OnStatsUpdated -= UpdateProficiency;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void UpdateProficiency()
        {
            string proficiencyBonusText = StatsValuesDB.GetProficiencyBonus().ToString();
            
            proficiencyValueString.text = proficiencyBonusText;
        }
    }
}
