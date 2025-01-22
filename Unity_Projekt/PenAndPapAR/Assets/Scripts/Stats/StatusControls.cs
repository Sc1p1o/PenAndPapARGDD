using UnityEngine;
using UnityEngine.UI;
using GlobalConditions;

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
        if (Input.GetKeyDown(KeyCode.U) && _isActive) // Taste "U" wird gedrückt
        {
            AddConditionObject(Condition.Frightened);
        }
        
        if (Input.GetKeyDown(KeyCode.I) && _isActive) // Taste "I" wird gedrückt
        {
            RemoveConditionObject(Condition.Frightened);
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

    public void changeActiveState(bool activitiyState)
    {
        if (activitiyState)
        {
            _isActive = true;
            
        }
    }
}
