using UnityEngine;

[CreateAssetMenu(fileName = "Speaker_", menuName = "Dialogue/Speaker")]
public class SpeakerData : ScriptableObject
{
    [SerializeField] private string speakerName;
    [SerializeField] private Sprite speakerSprite;

    public string GetName()
    { return speakerName; }

    public Sprite GetSprite()
    { return speakerSprite; }
}
