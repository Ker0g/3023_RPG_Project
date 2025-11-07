using UnityEngine;

public class AttackScript : MonoBehaviour
{
    [SerializeField] int manaCost;
    [SerializeField] bool isMagic;

    [SerializeField] string animationName;

    public GameObject owner;
    public GameObject victim;

    private FighterStats attackerStats;
    private FighterStats defenderStats;

    private int damage = 0;

    private Vector2 magicScale;

    public void Attack(GameObject victim)
    {
        attackerStats = owner.GetComponent<FighterStats>();
        defenderStats = victim.GetComponent<FighterStats>();

        if(attackerStats.magic >= manaCost)
        {
            attackerStats.updateManaFill(manaCost);

            damage = attackerStats.attack;

            if (isMagic)
            {
                damage = attackerStats.magic;
                attackerStats.mana -= manaCost;
            }

            damage = Mathf.Max(1, damage - defenderStats.defense);
            owner.GetComponent<Animator>().Play(animationName);
            defenderStats.recieveDamage(damage);
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        magicScale = GameObject.Find("HeroMagicFill").GetComponent<RectTransform>().localScale;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
