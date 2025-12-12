using System.Security.Cryptography;
using UnityEngine;

public class FighterStats : MonoBehaviour
{
    [SerializeField] Animator animatorController;

    [SerializeField] GameObject healthFill;
    [SerializeField] GameObject magicFill;

    

    [Header("Fighter Stats")]
    public int health;
    public int magic;
    public int attack;
    public int defense;
    public float speed;
    public float mana;

    public float maxHealth;
    public float maxMagic;
    public float maxMana;

    private float startHealth;
    private float startMagic;

    public int nextActTurn;

    private Transform healthTransform;
    private Transform magicTransform;

    private Vector2 healthScale;
    private Vector2 magicScale;

    private float xNewHealthScale;
    private float xNewMagicScale;

    public void recieveDamage(int damage)
    {
        health -= damage;
        xNewHealthScale = (health / startHealth) * healthScale.x;
        healthFill.transform.localScale = new Vector2(xNewHealthScale, healthScale.y);

        //if (health <= 0)
        //{
        //    animatorController.Play("Fighter_Death");
        //}
        //else
        //{
        animatorController.Play("Hurt");
        //}
    }

    public void updateManaFill(float manaCost)
    {
        xNewMagicScale = ((magic - manaCost) / startMagic) * magicScale.x;
        magicFill.transform.localScale = new Vector2(xNewMagicScale, magicScale.y);
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animatorController = gameObject.GetComponent<Animator>();


        healthTransform = healthFill.GetComponent<RectTransform>();
        healthScale = healthFill.transform.localScale;

        magicTransform = magicFill.GetComponent<RectTransform>();
        magicScale = magicFill.transform.localScale;
        startHealth = health;
        startMagic = magic;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
