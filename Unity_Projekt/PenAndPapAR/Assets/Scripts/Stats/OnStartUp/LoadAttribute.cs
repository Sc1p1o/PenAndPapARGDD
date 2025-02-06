using System;
using UnityEngine;
using TMPro;
using Utils;

public class LoadAttribute : MonoBehaviour
{
    public GameObject StrengthValue;
    public GameObject DexterityValue;
    public GameObject ConstitutionValue;
    public GameObject IntelligenceValue;
    public GameObject WisdomValue;
    public GameObject CharismaValue;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void OnEnable()
    {
        StatsValuesDB.OnStatsUpdated += LoadAttributes;
    }

    private void OnDisable()
    {
        StatsValuesDB.OnStatsUpdated -= LoadAttributes;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void LoadAttributes()
    {
        //StatsValuesDB.Initialize();
        int[] attributeValues = StatsValuesDB.GetAttributes();
        StrengthValue.GetComponent<TextMeshProUGUI>().text = attributeValues[0].ToString();
        DexterityValue.GetComponent<TextMeshProUGUI>().text = attributeValues[1].ToString();
        ConstitutionValue.GetComponent<TextMeshProUGUI>().text = attributeValues[2].ToString();
        IntelligenceValue.GetComponent<TextMeshProUGUI>().text = attributeValues[3].ToString();
        WisdomValue.GetComponent<TextMeshProUGUI>().text = attributeValues[4].ToString();
        CharismaValue.GetComponent<TextMeshProUGUI>().text = attributeValues[5].ToString();
    }
    
    
}
