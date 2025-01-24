using UnityEngine;
using TMPro;

namespace Stats
{
    public class ModifierCalculator : MonoBehaviour
    {
        public GameObject modifierValueObject;
        public GameObject attributeValueObject;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            if (attributeValueObject)
            {
                string attributeValueString = attributeValueObject.GetComponent<TextMeshProUGUI>().text;
                if(int.TryParse(attributeValueString, out int resultValue))
                {
                    
                }

            }
        }

        // Update is called once per frame
        void Update()
        {
            
        }
    }
}
