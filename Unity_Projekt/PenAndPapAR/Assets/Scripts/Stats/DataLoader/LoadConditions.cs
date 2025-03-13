using System.Collections.Generic;
using GlobalEnums;
using TMPro;
using UnityEngine;
using Utils;

namespace Stats.DataLoader
{
    public class LoadConditions : MonoBehaviour
    {
        public GameObject conditionLayout;
        public GameObject conditionPrefab;
        private Condition[] _conditions = new Condition[12];
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            DBConnector.OnStatsUpdated += LoadConditionsFromDB;
        }
        
        void OnEnable()
        {
            DBConnector.OnStatsUpdated += LoadConditionsFromDB;
        }

        void OnDisable()
        {
            DBConnector.OnStatsUpdated -= LoadConditionsFromDB;
        }

        // Update is called once per frame
        void Update()
        {
            
        }

        public void LoadConditionsFromDB()
        {
            if ((conditionLayout != null) && (conditionPrefab != null))
            {
                List<Condition> conditions = DBConnector.GetConditions();
                if( conditions == null) return;
                
                foreach (Condition condition in conditions)
                {
                    if (conditionLayout.transform.Find(condition.ToString()) == null) AddConditionIcon(condition);
                }
            }
        }

        public void AddConditionIcon(Condition condition)
        {
            GameObject newCondition = Instantiate(conditionPrefab, conditionLayout.transform);
            newCondition.name = condition.ToString();
                
            Transform iconTransform = newCondition.transform.Find("ConditionIcon");
            if (iconTransform != null)
            {
                var iconImage = iconTransform.GetComponent<UnityEngine.UI.Image>();
                if (iconImage != null)
                {
                    string filePath = $"Conditions/{condition}";
                    iconImage.sprite = Resources.Load<Sprite>(filePath);
                }
            }
            Transform titleTransform = newCondition.transform.Find("ConditionTitle");
            if (titleTransform != null)
            {
                var titleText = titleTransform.GetComponent<TextMeshProUGUI>();

                if (titleText != null)
                {
                    titleText.text = condition.ToString();
                }
            }
            
        }

        public void RemoveClicked()
        {
            Debug.Log("Remove clicked");
        }
    }
}
