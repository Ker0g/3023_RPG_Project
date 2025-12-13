using System.Threading.Tasks;
using UnityEngine;


public enum Turn
{
    HERO,
    ENEMY,
    BUSY
}
public class CombatSystem : MonoBehaviour
{
    string[] attacks = { "melee", "range", "charge"};
    public GameObject enemy;

    public bool heroTurn = true;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        SoundManager.PlaySound("dyskopia");
        await Task.Delay(10);
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void TestAttack()
    { 
        heroTurn = false;
        await Task.Delay(500);

        int randChoice = Random.Range(0, attacks.Length);
        Debug.Log(randChoice);
        if(enemy != null)
        {
            enemy.GetComponent<FighterAction>().SelectAttack(attacks[1]);
        }
        
        
        
        Debug.Log("I'd be punchin rn");
        heroTurn= true;
    }
}
