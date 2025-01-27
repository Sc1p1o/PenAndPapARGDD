using UnityEngine;

namespace Utils
{
    public static class VisibilityManager
    { 
        // Start is called once before the first execution of Update after the MonoBehaviour is created

        public static void ChangeVisibility(GameObject target, bool visible) => target.SetActive(visible);

        public static void ChangeVisibility(GameObject[] targets, bool[] visible)
        {
            for (int i = 0; i < targets.Length; i++)
            {
                targets[i].SetActive(visible[i]);
            }
        }
    }
}
