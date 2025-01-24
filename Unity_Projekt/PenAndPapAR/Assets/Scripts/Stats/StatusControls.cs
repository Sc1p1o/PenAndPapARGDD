using System.Linq;
using GlobalEnums;
using UnityEngine;
using UnityEngine.UI;
using Microsoft.MixedReality.Toolkit;
using Utils;


namespace Stats
{
    public class DynamicImageAdder : MonoBehaviour
    {
        private Condition[] _currentConditions;
    
        private bool _isActive;
    
        public GameObject layoutGroup;
        public Vector2 imageSize;

        void Start()
        {
            _isActive = true;
            imageSize = new Vector2(40, 40);
        }
    
        void Update()
        {
            if (Input.GetKeyDown(KeyCode.A) && _isActive) // Taste "A" wird gedrückt
            {
                ChangeActiveState(false, layoutGroup.transform.parent.Find("StatsLayer2").gameObject);
            }
        
            if (Input.GetKeyDown(KeyCode.I) && _isActive) // Taste "I" wird gedrückt
            {
                ChangeActiveState(true, layoutGroup.transform.parent.Find("StatsLayer2").gameObject);
            }
            
            if (Input.GetKeyDown(KeyCode.F) && _isActive) // Taste "I" wird gedrückt
            {
                AddConditionObject(Condition.Frightened);
            }
            
            if (Input.GetKeyDown(KeyCode.G) && _isActive) // Taste "I" wird gedrückt
            {
                AddConditionObject(Condition.Grappled);
            }
            
            if (Input.GetKeyDown(KeyCode.R) && _isActive) // Taste "I" wird gedrückt
            {
                RemoveConditionObject(Condition.Frightened);
            }
            
            if (Input.GetKeyDown(KeyCode.E) && _isActive) // Taste "I" wird gedrückt
            {
                RemoveConditionObject(Condition.Grappled);
            }
        }
    
        public Sprite LoadConditionImage(Condition condition)
        {
            string filePath = $"Conditions/{condition}";

            Sprite loadedSprite = Resources.Load<Sprite>(filePath);
            return loadedSprite;
        }

        void AddConditionObject(Condition changedCondition)
        {
            if (layoutGroup.transform.childCount >= 9) return;
            if (layoutGroup.transform.Find($"{changedCondition}")) return;
        
            AddImageToLayout(changedCondition, $"{changedCondition}");
        }
        void AddImageToLayout(Condition condition ,string statusCondition)
        {
            GameObject newConditionObject = new GameObject(statusCondition, typeof(RectTransform));
            RectTransform rectTransform = newConditionObject.GetComponent<RectTransform>();
            rectTransform.sizeDelta = imageSize;
        
            Image image = newConditionObject.AddComponent<Image>();
            image.sprite = LoadConditionImage(condition);
            image.color = Color.white;

            newConditionObject.transform.SetParent(layoutGroup.transform, false);
        }

        void RemoveConditionObject(Condition changedCondition)
        {
            try
            {
                GameObject conditionObject = layoutGroup.transform.Find($"{changedCondition}").gameObject;
                if (conditionObject) Destroy(conditionObject);
            }
            catch
            {
                //TODO LOG AND EXCEPTION HANDLING
            }
        }

        public void ChangeActiveState(bool activitiyState, GameObject newLayoutLayer)
        {
            GameObject[] gameObjectsArray = new GameObject[2];
            bool[] activitiyChangeArray = new bool[2];
            
            activitiyChangeArray[0] = activitiyState;
            activitiyChangeArray[1] = !activitiyState;
            
            gameObjectsArray[0] = layoutGroup;
            gameObjectsArray[1] = newLayoutLayer;

            VisibilityManager.ChangeVisibility(gameObjectsArray, activitiyChangeArray);
        }
    }
}
