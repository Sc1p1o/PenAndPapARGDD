using UnityEngine;
using Utils;

namespace Stats
{
    public class ConditionHandler : MonoBehaviour
    {
    
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {
        
        }

        // Update is called once per frame
        void Update()
        {
        
        }

        void OnDestroy()
        {
            DBConnector.UpdateValues();
        }
    
        public void OnClick()
        {
            Debug.Log("Clicked");
 
            bool successfullRemove = DBConnector.RemoveCondition(gameObject.name);
            if (successfullRemove)
            {
                Destroy(gameObject);
            }
            else Debug.Log("Could not remove condition");
            


        }
    }
}
