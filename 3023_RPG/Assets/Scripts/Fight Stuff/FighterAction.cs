using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using Unity.VisualScripting;
using UnityEditor.Playables;
using UnityEngine;
using UnityEngine.SocialPlatforms;
using UnityEngine.UI;

public class FighterAction : MonoBehaviour
{
    public CombatSystem ai;

    private GameObject hero;
    private GameObject enemy;

    public FighterStats attackerStats;
    public FighterStats defenderStats;

    private GameObject attacker;
    private GameObject victim;

    private TextTyper typer;

    //[SerializeField]
    //private GameObject meleePrefab;

    //[SerializeField]
    //private GameObject rangePrefab;

    public Ability[] abilities = new Ability[4];

    //[SerializeField]
    //private Sprite faceIcon;

    private GameObject currentAttack;

    void Awake()
    {
        //hero = GameObject.FindGameObjectWithTag("Hero");
        //enemy = GameObject.FindGameObjectWithTag("Enemy");

        typer = GameObject.FindGameObjectWithTag("BattleText").GetComponent<TextTyper>();
    }
    private async void Start()
    {
        await Task.Delay(10);
        hero = GameObject.FindGameObjectWithTag("Hero");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        ai = FindObjectOfType<CombatSystem>();
    }
    public void SelectAttack(string btn)
    {
        GameObject victim = hero;
        GameObject attacker = enemy;
        attackerStats = attacker.GetComponent<FighterStats>();
        defenderStats = victim.GetComponent<FighterStats>();

        if (tag == "Hero")
        {
            victim = enemy;
            attacker = hero;
            attackerStats = hero.GetComponent<FighterStats>();
            defenderStats = enemy.GetComponent<FighterStats>();
        }
        else if(tag == "Enemy")
        {
            victim = hero;
            attacker = enemy;
            attackerStats = enemy.GetComponent<FighterStats>();
            defenderStats = hero.GetComponent<FighterStats>();
        }

        if (btn.CompareTo("melee") == 0)
        {
            PerformAbility(abilities[0], attackerStats, defenderStats);
            Debug.Log("Melee Attack");

            if (attacker == hero)
            {
                if (defenderStats != null) 
                {
                    ai.TestAttack();
                }
                
            }



        }
        else if (btn.CompareTo("range") == 0)
        {
            PerformAbility(abilities[1], attackerStats, defenderStats);

            Debug.Log("Range Attack");
        }
        else if(btn.CompareTo("charge") == 0)
        {
            ChargeMana(attackerStats);
            
        }
        else
        {
            Debug.Log("Run");
        }
    }

    public void PerformAbility(Ability ability, FighterStats user, FighterStats target)
    {
        if (user.mana < ability.manaCost)
        {
            Debug.Log($"{user.name} doesn't have enough mana to use {ability.name}!");
            return;
        }

        user.mana -= ability.manaCost;
        ability.Activate(user, target);
        typer.TypeText($"{user.name} uses {ability.name} on {target.name}!");
    }

    public void ChargeMana(FighterStats user)
    {   
        int addMana = (int)(user.mana * 0.25);

        if (user.mana < user.maxMana)
        {

            user.mana += addMana;

            user.updateManaFill(-addMana);

            typer.TypeText($"{user.name} recharges {addMana} mana!");
        }
        else { typer.TypeText($"{user.name} charged mana, but was already full!");  }
            Mathf.Clamp(user.mana, 0, user.maxMana);

        
        
    }
}