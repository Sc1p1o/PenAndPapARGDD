using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Stats.Layer3
{
    public class DeathSaveHandler : MonoBehaviour
    {
        public Toggle failedDeathSave1;
        public Toggle failedDeathSave2;
        public Toggle failedDeathSave3;
        public Toggle succeededDeathSave1;
        public Toggle succeededDeathSave2;
        public Toggle succeededDeathSave3;
    
        private Toggle [] _failedDeathSaves;
        private Toggle [] _succeededDeathSaves;
    
        private int _numberOfFailedDeathSaves;
        private int _numberOfSucceededDeathSaves;
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
            _succeededDeathSaves = new Toggle[3]
            {
                succeededDeathSave1,
                succeededDeathSave2,
                succeededDeathSave3
            };
            _failedDeathSaves = new Toggle[3]
            {
                failedDeathSave1,
                failedDeathSave2,
                failedDeathSave3
            };
        
            LoadDeathSaves();
        
        }
    
        void OnEnable()
        {
            DBConnector.OnStatsUpdated += LoadDeathSaves;
        }

        void OnDisable()
        {
            DBConnector.OnStatsUpdated -= LoadDeathSaves;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void LoadDeathSaves()
        {
            _numberOfFailedDeathSaves = DBConnector.GetStatValue("failed death saves");
            _numberOfSucceededDeathSaves = DBConnector.GetStatValue("succeeded death saves");
            
            if((_failedDeathSaves == null) || (_succeededDeathSaves == null)) return;
            for (int i = 0; i < 3; i++)
            {
                _failedDeathSaves[i].isOn = i < _numberOfFailedDeathSaves;
                _succeededDeathSaves[i].isOn = i < _numberOfSucceededDeathSaves;
            }
        
        }
    }
}
