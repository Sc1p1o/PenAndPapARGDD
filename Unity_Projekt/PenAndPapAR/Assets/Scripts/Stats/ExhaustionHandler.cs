using UnityEngine;
using Utils;
using Toggle = UnityEngine.UI.Toggle;

namespace Stats
{
    public class ExhaustionHandler : MonoBehaviour
    {
        public Toggle exhaustionLevel1Toggle;
        public Toggle exhaustionLevel2Toggle;
        public Toggle exhaustionLevel3Toggle;
        public Toggle exhaustionLevel4Toggle;
        public Toggle exhaustionLevel5Toggle;
        public Toggle exhaustionLevel6Toggle;
        private Toggle[] _exhaustionToggles;
        private int _exhaustionLevel;
    
        public 
    
            // Start is called once before the first execution of Update after the MonoBehaviour is created
            void Start()
        {
            _exhaustionToggles = new Toggle[6]
            {
                exhaustionLevel1Toggle,
                exhaustionLevel2Toggle,
                exhaustionLevel3Toggle,
                exhaustionLevel4Toggle,
                exhaustionLevel5Toggle,
                exhaustionLevel6Toggle
            };
            LoadExhaustionLevels();
        }
    
        void OnEnable()
        {
            DBConnector.OnStatsUpdated += LoadExhaustionLevels;
        }

        void OnDisable()
        {
            DBConnector.OnStatsUpdated -= LoadExhaustionLevels;
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        public void LoadExhaustionLevels()
        {   
            if(_exhaustionToggles == null) return;
            _exhaustionLevel = DBConnector.GetStatValue("exhaustion");
            for (int i = 0; i < _exhaustionToggles.Length; i++)
            {
                _exhaustionToggles[i].isOn = i < _exhaustionLevel;
            }
        
            // TODO: Apply Exhaustion Consequences
        }
    }
}
