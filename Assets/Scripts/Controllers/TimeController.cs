using UnityEngine;
using System;

public class TimeController : MonoBehaviour
{
    [Header("Réglages")]
    [Tooltip("Vitesse : 1 seconde réelle = X jours dans la simulation")]
    public float secondsPerDay = 10f; // On met 10 pour que ça bouge visiblement

    private TimeModel _model;
    private DateTime _currentDateTime;

    // Cette méthode est appelée par le Bootstrapper
    public void Init(TimeModel model)
    {
        _model = model;
        _currentDateTime = DateTime.Now;
        _model.SetTime(_currentDateTime);
        Debug.Log("[TIME] Contrôleur de temps initialisé.");
    }

    void Update()
    {
        // Si le bootstrapper n'a pas encore fait l'Init, on ne fait rien
        if (_model == null || !_model.IsPlaying) return;

        // On fait avancer la date
        _currentDateTime = _currentDateTime.AddDays(Time.deltaTime * secondsPerDay);
        
        // On met à jour le modèle, ce qui va prévenir les planètes via l'événement
        _model.SetTime(_currentDateTime);

        
    }
}