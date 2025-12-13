using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Item")]
public class ScriptableItem : ScriptableObject
{

    public Sprite icon;

    public int worth;

    public string description = "";

}
  