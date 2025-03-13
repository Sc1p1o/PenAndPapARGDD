using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Utils;

namespace Stats
{
    public class PassivePerceptionCalculator : MonoBehaviour
    {
        public GameObject modifierValueObject;
    
        public GameObject attributeValueObject;
        public GameObject proficiencyValueObject;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            DBConnector.OnStatsUpdated += LoadPassivePerception;
        }
        
        void OnEnable()
        {
            DBConnector.OnStatsUpdated += LoadPassivePerception;
        }

        void OnDisable()
        {
            DBConnector.OnStatsUpdated -= LoadPassivePerception;
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    
        public void LoadPassivePerception()
        {
            int attributeModifier;
            int proficiencyModifier;
            
            TextMeshProUGUI modifierValue = modifierValueObject.GetComponent<TextMeshProUGUI>();
            
            string attributeValueText = attributeValueObject.GetComponent<TextMeshProUGUI>().text;
            string proficiencyValueText = proficiencyValueObject.GetComponent<TextMeshProUGUI>().text;
            
            int.TryParse(attributeValueText, out attributeModifier);
            int.TryParse(proficiencyValueText, out proficiencyModifier);
            
            modifierValue.text = (attributeModifier + proficiencyModifier + 10).ToString();
        }
    }
}
