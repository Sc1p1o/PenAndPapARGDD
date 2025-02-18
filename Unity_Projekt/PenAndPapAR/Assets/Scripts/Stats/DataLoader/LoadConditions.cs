using UnityEngine;
using Utils;

namespace Stats.DataLoader
{
    public class LoadConditions : MonoBehaviour
    {
        public GameObject conditionLayout;
        public GameObject conditionPrefab;
        
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            
            LoadConditionsFromDB();
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
            
        }
    }
}
