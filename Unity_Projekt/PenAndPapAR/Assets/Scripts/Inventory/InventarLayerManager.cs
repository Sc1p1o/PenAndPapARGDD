using UnityEngine;
using Utils;

namespace Inventory
{
    public class InventarLayerManager : MonoBehaviour
    {
        public GameObject layer1;
        public GameObject layerpopup;
        public GameObject layer3;
        // Start is called once before the first execution of Update after the MonoBehaviour is created
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {

        }

        public void ChangeLayer(int layer)
        {
            VisibilityManager.ChangeVisibility(gameObject, false);
            switch (layer)
            {
                case 1:
                    VisibilityManager.ChangeVisibility(layer1, true);
                    DBConnector.UpdateValues();
                    break;
                case 2:
                    VisibilityManager.ChangeVisibility(layerpopup, true);
                    DBConnector.UpdateValues();
                    break;
                case 3:
                    VisibilityManager.ChangeVisibility(layer3, true);
                    DBConnector.UpdateValues();
                    break;
            }
        }
    }
} 
