using GlobalEnums;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Stats
{
    public class DisplayConditions : MonoBehaviour
    {
        private int _conditionCount = 0;
    
        public GameObject parentGameObject;
        public GameObject conditionPrefab;

        public void Start()
        {
            
        }
        
        // Update is called once per frame
        public void Update()
        {
            if (Input.GetKeyDown(KeyCode.U)) // Taste "U" wird gedrückt
            {
                AddCondition(Condition.Frightened);
            }
        
            if (Input.GetKeyDown(KeyCode.I)) // Taste "I" wird gedrückt
            {
                RemoveCondition(Condition.Frightened);
            }
        }
        
        private void OnEnable()
        {
            DBConnector.OnStatsUpdated += LoadConditions;
        }

        private void OnDisable()
        {
            DBConnector.OnStatsUpdated -= LoadConditions;
        }
    
        public void AddCondition(Condition condition)
        {
            _conditionCount++;
            GameObject newCondition = Instantiate(conditionPrefab.transform.gameObject, parentGameObject.transform);
            newCondition.name = condition.ToString();
            newCondition.transform.localScale = Vector3.one;
        
            Image conditionIcon = newCondition.transform.Find("ConditionIcon").GetComponent<Image>();
        
            TextMeshProUGUI conditionName = newCondition.transform.Find("ConditionName").GetComponent<TextMeshProUGUI>();

            string filePath = $"Conditions/{condition}";
            Sprite conditionSprite = Resources.Load<Sprite>(filePath);
        
            conditionIcon.sprite = conditionSprite;
            conditionName.text = condition.ToString();
        }

        public void RemoveCondition(Condition condition)
        {
            try
            {
                _conditionCount--;
                GameObject conditionObject = parentGameObject.transform.Find($"{condition}").gameObject;
                if (conditionObject) Destroy(conditionObject);
            }
            catch
            {
                //TODO LOG AND EXCEPTION HANDLING
            }
        }

        public void LoadConditions()
        {
            
        }
    
    
    }
}
