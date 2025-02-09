using TMPro;
using UnityEngine;
using Utils;

namespace Stats.OnStartUp
{
    public class LoadStatString : MonoBehaviour
    {
        public GameObject statNameObject;
        public string statNameString = "";
        private TextMeshProUGUI _statNameText;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        { 
            if (statNameObject != null)
            {
                _statNameText = statNameObject.GetComponent<TextMeshProUGUI>();
                statNameString = statNameObject.name;
            }
        }

        // Update is called once per frame
        void Update()
        {
        
        }
        
        void OnEnable()
        {
            DBConnector.OnStatsUpdated += LoadString;
        }

        void OnDisable()
        {
            DBConnector.OnStatsUpdated -= LoadString;
        }

        public void LoadString()
        {
            _statNameText.text = DBConnector.GetStatString(statNameString);
        }
    }
}
