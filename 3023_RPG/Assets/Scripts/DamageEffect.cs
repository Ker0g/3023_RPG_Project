using UnityEngine;

[CreateAssetMenu(fileName = "New Damage Effect", menuName = "Ability/Damage")]
public class EffectDamage : Effect
{
    public int minDamage;
    public int maxDamage;
    public int damageAmount;
    public override void Activate(FighterStats user, FighterStats target)
    {
        damageAmount = Random.Range(minDamage, maxDamage + 1);
        damageAmount += Mathf.RoundToInt(user.attack * 0.1f);

        damageAmount -= target.defense;
        if(damageAmount < 0) damageAmount = 1;
        target.recieveDamage(damageAmount);
        //target.TakeDamage(damageAmount);
    }
}
