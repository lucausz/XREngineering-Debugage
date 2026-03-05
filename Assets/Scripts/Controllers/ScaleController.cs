using UnityEngine;

public class ScaleController : MonoBehaviour
{
    public Transform targetRoot; // Ton SolarSystemRoot
    public float minScale = 0.1f;
    public float maxScale = 5.0f;

    public void ChangeScale(float multiplier)
    {
        Vector3 newScale = targetRoot.localScale * multiplier;
        
        // On limite l'échelle pour ne pas que le système disparaisse ou devienne géant
        newScale.x = Mathf.Clamp(newScale.x, minScale, maxScale);
        newScale.y = Mathf.Clamp(newScale.y, minScale, maxScale);
        newScale.z = Mathf.Clamp(newScale.z, minScale, maxScale);

        targetRoot.localScale = newScale;
        Debug.Log($"[XR] Scale adjusted to: {newScale.x}");
    }
    public void AdjustScale(float multiplier)
    {
    // On multiplie l'échelle locale actuelle par le multiplicateur
    targetRoot.localScale *= multiplier;

    // Sécurité pour ne pas que ça devienne trop petit ou trop grand
    float clampedX = Mathf.Clamp(targetRoot.localScale.x, minScale, maxScale);
    targetRoot.localScale = new Vector3(clampedX, clampedX, clampedX);
    
    Debug.Log($"[ZOOM] Échelle actuelle : {targetRoot.localScale.x}");
    }

    public void ZoomIn()
    {
        Debug.Log("[ZOOM] Zooming in...");
        ChangeScale(1.2f); // Zoom in de 20%
    }

    // Fonction pour dézoomer (rétrécir)
    public void ZoomOut()
    {
        Debug.Log("[ZOOM] Zooming out...");
        ChangeScale(1f / 1.2f); // Zoom out de 20%
    }
}