using UnityEngine;

public abstract class Effect : ScriptableObject
{
    abstract public void Activate(FighterStats user, FighterStats target);
}


[CreateAssetMenu(fileName = "New Poison Effect", menuName = "Ability/Effect")]
public class EffectPoison : Effect
{   
    public int severity;
    public override void Activate(FighterStats user, FighterStats target)
    {
       
        //target.AddStatus("Poison", severity);

    }
}

[CreateAssetMenu(fileName = "New Damage Effect", menuName = "Ability/Damage")]
public class EffectDamage : Effect
{
    public int minDamage;
    public int maxDamageExclusive;
    public int damageAmount;
    public override void Activate(FighterStats user, FighterStats target)
    {
        damageAmount = Random.Range(minDamage, maxDamageExclusive);
        damageAmount += Mathf.RoundToInt(user.attack * 0.1f);

        damageAmount -= target.defense;
        target.recieveDamage(damageAmount);
        //target.TakeDamage(damageAmount);
    }
}
