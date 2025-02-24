using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Stats
{
    public class HPManager : MonoBehaviour
    {
        public TextMeshProUGUI hpText;     // Referenz für den HP-Text (Anzeige)
        public Button increaseButton;     // Button zum Erhöhen der HP
        public Button decreaseButton;     // Button zum Verringern der HP

        void Start()
        {
            // Listener für Buttons hinzufügen
            increaseButton.onClick.AddListener(OnIncreaseHpValue);
            decreaseButton.onClick.AddListener(OnDecreaseHpValue);
        }

        // Funktion zum Erhöhen der HP
        void OnIncreaseHpValue()
        {
            // Lese aktuelle HP und maximale HP aus dem Text
            string text = hpText.text; // Beispiel: "HP: 42/50"
            string[] parts = text.Replace("HP: ", "").Split('/');

            if (parts.Length == 2 && int.TryParse(parts[0], out int currentHP) && int.TryParse(parts[1], out int maxHP))
            {
                if (currentHP < maxHP)
                {
                    currentHP++;
                    OnUpdateHPText(currentHP, maxHP);
                }
            }
            else
            {
                Debug.LogError("HP-Text ist ungültig. Format: 'HP: <currentHP>/<maxHP>' erforderlich.");
            }
        }

        // Funktion zum Verringern der HP
        void OnDecreaseHpValue()
        {
            // Lese aktuelle HP und maximale HP aus dem Text
            string text = hpText.text; // Beispiel: "HP: 42/50"
            string[] parts = text.Replace("HP: ", "").Split('/');

            if (parts.Length == 2 && int.TryParse(parts[0], out int currentHP) && int.TryParse(parts[1], out int maxHP))
            {
                if (currentHP > 0)
                {
                    currentHP--;
                    OnUpdateHPText(currentHP, maxHP);
                }
            }
            else
            {
                Debug.LogError("HP-Text ist ungültig. Format: 'HP: <currentHP>/<maxHP>' erforderlich.");
            }
        }

        // Aktualisiert den HP-Text
        void OnUpdateHPText(int currentHP, int maxHP)
        {
            hpText.text = $"HP: {currentHP}/{maxHP}";

            // Buttons aktivieren/deaktivieren, wenn Grenzen erreicht sind
            increaseButton.interactable = currentHP < maxHP;
            decreaseButton.interactable = currentHP > 0;

            // Ändere Farbe basierend auf aktuellen HP
            if (currentHP <= maxHP / 4)
                hpText.color = Color.red; // Kritisch
            else
                hpText.color = Color.white; // Normal
        }
    }
}
