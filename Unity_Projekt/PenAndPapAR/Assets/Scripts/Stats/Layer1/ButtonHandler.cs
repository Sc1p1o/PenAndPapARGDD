using UnityEngine;
using UnityEngine.EventSystems;

namespace Stats
{
    public class ButtonHoldHandler : MonoBehaviour, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
    {
        public LayerManager layerManager; // Drag & Drop den LayerManager hier rein
        public int layerToActivate = 1;   // Leg den Layer fest, der aktiviert werden soll
        private bool _isPressing = false; // Ob der Button aktuell gedrückt wird
        private float _pressStartTime = 0f; // Zeitpunkt des Beginns des Druckens
        private readonly float _holdThreshold = 0.5f; // Schwellenwert zwischen Klick und Hold (in Sekunden)
    
        public void OnPointerDown(PointerEventData eventData)
        {
            _isPressing = true;
            _pressStartTime = Time.time; // Zeitpunkt des Drückens speichern
            Debug.Log("MouseDown recognized!");
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            if (!_isPressing) return;

            _isPressing = false;
            float pressDuration = Time.time - _pressStartTime;

            if (pressDuration >= _holdThreshold)
            {
                OnHold(); // Gedrückt halten erkannt
            }
            else
            {
                OnClick(); // Klick erkannt
            }
        }

        public void OnPointerExit(PointerEventData eventData)
        {
            _isPressing = false; // Falls der Finger/Mauszeiger den Button verlässt
        }

        private void OnClick()
        {
            Debug.Log($"Klick erkannt! Wechsel auf Layer {layerToActivate}");
            layerManager.ChangeLayer(layerToActivate);
        }

        private void OnHold()
        {
            Debug.Log($"Halten erkannt! Wechsel auf weiteren Layer {layerToActivate}");
            layerManager.ChangeLayer(0); // Beispiel: Wechsle zu einem anderen Layer
        }
    }
}

