using UnityEngine;
using UnityEngine.InputSystem; // Indispensable pour le Quest 2

public class XRInputController : MonoBehaviour
{
    public ScaleController scaleController;

    public InputActionReference zoomInAction; 
    
    public InputActionReference zoomOutAction;

    void Update()
    {
        if (scaleController == null) return;

        // On vérifie si le bouton vient d'être pressé ce segment d'image
        if (zoomInAction != null && zoomInAction.action.triggered)
        {
            scaleController.ChangeScale(1.2f); // Zoom in de 20%
        }

        if (zoomOutAction != null && zoomOutAction.action.triggered)
        {
            scaleController.ChangeScale(0.8f); // Zoom out de 20%
        }
    }
}