using UnityEngine;
using Utils;

namespace Inventory
{
    public class LayerManager : MonoBehaviour
    {
        public GameObject layer1;
        public GameObject layer2;
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
                case 0:
                    //TODO: Call 3D Object Visibility
                    Debug.Log("3D Object Visibility");
                    VisibilityManager.ChangeVisibility(layer1, true);
                    DBConnector.UpdateValues();
                    break;
                case 1:
                    VisibilityManager.ChangeVisibility(layer1, true);
                    DBConnector.UpdateValues();
                    break;
                case 2:
                    VisibilityManager.ChangeVisibility(layer2, true);
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
