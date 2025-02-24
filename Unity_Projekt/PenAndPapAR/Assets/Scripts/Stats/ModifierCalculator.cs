using Microsoft.MixedReality.Toolkit;
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
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            DBConnector.OnStatsUpdated += LoadModifier;
            LoadModifier();
        }

        void OnEnable()
        {
            DBConnector.OnStatsUpdated += LoadModifier;
        }

        void OnDisable()
        {
            DBConnector.OnStatsUpdated -= LoadModifier;
        }

        // Update is called once per frame
        void Update()
        {
            
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
    }
}
