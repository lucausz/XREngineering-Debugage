using UnityEngine;

[CreateAssetMenu(menuName = "XR/Solar System Config")]
public class SolarSystemConfig : ScriptableObject
{
    public float distanceScale = 0.5f;
    public float planetSizeScale = 0.005f;
    public bool showOrbits = true;
}
