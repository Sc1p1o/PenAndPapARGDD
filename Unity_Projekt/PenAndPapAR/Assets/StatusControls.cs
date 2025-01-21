using System;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;
using GlobalConditions;
using JetBrains.Annotations;
using NUnit.Framework.Constraints;
using UnityEngine.Android;

public class DynamicImageAdder : MonoBehaviour
{
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
                
        AddImageToLayout(Condition.Frightened, $"{changedCondition}");
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
}
