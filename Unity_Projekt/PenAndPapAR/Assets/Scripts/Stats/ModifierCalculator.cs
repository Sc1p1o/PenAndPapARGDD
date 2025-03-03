using Microsoft.MixedReality.Toolkit;
using Stats.DataLoader;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Utils;

namespace Stats
{
    public class ModifierCalculator : MonoBehaviour
    {
        public GameObject modifierValueObject;
        public GameObject attributeValueObject;
        public Toggle proficiencyIndicatorObject;
        public GameObject proficiencyValueObject;
        
        private Text _label;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (proficiencyIndicatorObject != null)
            {
                _label = proficiencyIndicatorObject.GetComponentInChildren<Text>();
            }
            DBConnector.OnStatsUpdated += LoadModifier;
            if (proficiencyIndicatorObject != null)
            {
                LoadProficiencies(); 
            }
            LoadModifier();
        }

        void OnEnable()
        {
            DBConnector.OnStatsUpdated += UpdateModifiers;
        }

        void OnDisable()
        {
            DBConnector.OnStatsUpdated -= UpdateModifiers;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void UpdateModifiers()
        {
            if (proficiencyIndicatorObject != null && _label != null)
            {
                proficiencyIndicatorObject.isOn = DBConnector.GetIsProficiency(_label.text);
            }
            
        }

        public void LoadProficiencies()
        {
            
            if (proficiencyIndicatorObject != null)
            {
                proficiencyIndicatorObject.isOn = DBConnector.GetIsProficiency(_label.text);
                LoadModifier();
            }
        }

        public void LoadModifier()
        {
            Debug.Log("LoadModifier");
            int modifierInt;
            bool appliesProficiency;
            int attributeValue;
            int proficiencyValue;
            
            string attributeValueText = attributeValueObject.GetComponent<TextMeshProUGUI>().text;
            
            
            int.TryParse(attributeValueText, out attributeValue);
            //int.TryParse(proficiencyValueText, out proficiencyValue);
            
            TextMeshProUGUI modifierValue = modifierValueObject.GetComponent<TextMeshProUGUI>();

            if (proficiencyIndicatorObject)
            {
                appliesProficiency = true;
            }
            else
            {
                appliesProficiency = false;
            }
            
            if (appliesProficiency && proficiencyIndicatorObject.isOn)
            {
                string proficiencyValueText = proficiencyValueObject.GetComponent<TextMeshProUGUI>().text;
                
                int.TryParse(proficiencyValueText, out proficiencyValue);
                
                modifierInt = (attributeValue - 10) / 2 + proficiencyValue;
            }
            else
            {
                modifierInt = (attributeValue - 10) / 2;
            }

            if (attributeValue < 10)
            {
                modifierInt--;
            }

            modifierValueObject.GetComponent<TextMeshProUGUI>().text = modifierInt.ToString();
        }

        public void UpdateProficiency()
        {
            DBConnector.SetBoolValue(_label.text, proficiencyIndicatorObject.isOn);
            DBConnector.UpdateValues();

        }
    }
}
