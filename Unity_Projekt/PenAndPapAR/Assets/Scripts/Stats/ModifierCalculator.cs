using Microsoft.MixedReality.Toolkit;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

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
            LoadModifier();
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void LoadModifier()
        {
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

            modifierValueObject.GetComponent<TextMeshProUGUI>().text = modifierInt.ToString();
        }
    }
}
