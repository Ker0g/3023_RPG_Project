using NUnit.Framework;
using UnityEngine;
using UnityEngine.TextCore.Text;
using System.Collections.Generic;

public enum TargetType
{
    Self,
    Enemy,
    All
}

[CreateAssetMenu(fileName = "New Ability", menuName = "Ability/Abilityyyyy")]
public class Ability : ScriptableObject
{
    public TargetType target;
    public List<Effect> effects;
    public int manaCost;
    public virtual void Activate(FighterStats user, FighterStats target)
    {
        foreach (Effect effect in effects)
        {
            effect.Activate(user, target);
        }

        Debug.Log("Base Class Ability Activated");
    }
}
