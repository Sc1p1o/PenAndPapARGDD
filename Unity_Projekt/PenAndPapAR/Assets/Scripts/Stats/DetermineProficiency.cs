using UnityEngine;
using UnityEngine.UI;
using Utils;
using Toggle = UnityEngine.UI.Toggle;

namespace Stats
{
    public class DetermineProficiency : MonoBehaviour
    {
        private string _labelName;
        public Toggle proficiencyToggle; 
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            Text label = proficiencyToggle.GetComponentInChildren<Text>();
            _labelName = label.text;
            

            StatsValuesDB.OnStatsUpdated += SetToggle;
        }

        void OnEnable()
        {
            StatsValuesDB.OnStatsUpdated += SetToggle;
        }

        void OnDisable()
        {
            StatsValuesDB.OnStatsUpdated -= SetToggle;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void SetToggle()
        {
            proficiencyToggle.isOn = StatsValuesDB.GetIsProficiency(_labelName);
        }
    }
}
