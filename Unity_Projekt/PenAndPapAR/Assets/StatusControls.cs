using System;
using UnityEditor.Experimental;
using UnityEngine;
using UnityEngine.UI;
using GlobalConditions;

public class DynamicImageAdder : MonoBehaviour
{
    
    public GameObject layoutGroup;
    public Vector2 imageSize = new Vector2(40, 40);
    public Image targetImage;

    private void Start()
    {
        
    }
    
    // ReSharper disable Unity.PerformanceAnalysis
    public Sprite LoadConditionImage(Condition condition)
    {
        string filePath = $"Conditions/{condition}"; // Pfad basierend auf Enum-Wert

        Sprite loadedSprite = Resources.Load<Sprite>(filePath);
        return loadedSprite;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.U)) // Taste "U" wird gedrückt
        {
            AddConditionObject(Condition.Frightened);
        }
    }

    void AddConditionObject(Condition changedCondition)
    {
        if (layoutGroup.transform.childCount >= 9) return;
                
        AddImageToLayout(Condition.Frightened, "{changedCondition}");
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
}
