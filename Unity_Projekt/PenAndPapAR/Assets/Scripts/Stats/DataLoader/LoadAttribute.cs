using TMPro;
using UnityEngine;
using UnityEngine.Serialization;
using Utils;

namespace Stats.DataLoader
{
    public class LoadAttribute : MonoBehaviour
    {
        [FormerlySerializedAs("StrengthValue")] public GameObject strengthValue;
        [FormerlySerializedAs("DexterityValue")] public GameObject dexterityValue;
        [FormerlySerializedAs("ConstitutionValue")] public GameObject constitutionValue;
        [FormerlySerializedAs("IntelligenceValue")] public GameObject intelligenceValue;
        [FormerlySerializedAs("WisdomValue")] public GameObject wisdomValue;
        [FormerlySerializedAs("CharismaValue")] public GameObject charismaValue;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            LoadAttributes();
        }

        private void OnEnable()
        {
            DBConnector.OnStatsUpdated += LoadAttributes;
        }

        private void OnDisable()
        {
            DBConnector.OnStatsUpdated -= LoadAttributes;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void LoadAttributes()
        {
            //StatsValuesDB.Initialize();
            int[] attributeValues = DBConnector.GetAttributes();
            strengthValue.GetComponent<TextMeshProUGUI>().text = attributeValues[0].ToString();
            dexterityValue.GetComponent<TextMeshProUGUI>().text = attributeValues[1].ToString();
            constitutionValue.GetComponent<TextMeshProUGUI>().text = attributeValues[2].ToString();
            intelligenceValue.GetComponent<TextMeshProUGUI>().text = attributeValues[3].ToString();
            wisdomValue.GetComponent<TextMeshProUGUI>().text = attributeValues[4].ToString();
            charismaValue.GetComponent<TextMeshProUGUI>().text = attributeValues[5].ToString();
        }
    
    
    }
}
