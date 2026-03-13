using UnityEngine;

[CreateAssetMenu(menuName = "Spirit Cards/Spirit Card")]
public class SpiritCardData : ScriptableObject {

    public DiceTriggerType triggerType;
    public int pointsModifier;
    public float multiplierOverride;
}