using UnityEngine;
using TMPro; // Pour gérer ton texte

public class PlanetSelectionController : MonoBehaviour
{
    [Header("UI Reference")]
    public TextMeshProUGUI infoText; // Glisse ici le texte de ton panneau

    public void DisplayPlanetName(string name)
    {
        if (infoText != null)
        {
            infoText.text = "Cible : " + name;
            Debug.Log("[FOCUS] Planète détectée : " + name);
        }
    }

    public void ClearDisplay()
    {
        if (infoText != null)
        {
            infoText.text = "Cible : ---";
        }
    }
}