using UnityEngine;
using UnityEngine.UI;
using Utils;
using Toggle = UnityEngine.UI.Toggle;

namespace Stats.Layer3
{
    public class DetermineProficiency : MonoBehaviour
    {
        private Text _label;
        
        public Toggle proficiencyToggle; 
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _label = proficiencyToggle.GetComponentInChildren<Text>();
            
            DBConnector.OnStatsUpdated += SetToggle;
            DBConnector.UpdateValues();
        }

        void OnEnable()
        {
            DBConnector.OnStatsUpdated += SetToggle;
        }

        void OnDisable()
        {
            DBConnector.OnStatsUpdated -= SetToggle;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        private void SetToggle()
        {
            if (_label)
            {
                proficiencyToggle.isOn = DBConnector.GetIsProficiency(_label.text);
            }
        }
    }
}
