using System.Threading.Tasks;
using UnityEngine;

public class CombatSystem : MonoBehaviour
{
    string[] attacks = { "melee", "charge"};
    public GameObject enemy;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    async void Start()
    {
        await Task.Delay(10);
        enemy = GameObject.FindGameObjectWithTag("Enemy");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public async void TestAttack()
    { 
        await Task.Delay(500);

        int randChoice = Random.Range(0, attacks.Length);
        Debug.Log(randChoice);
        if(enemy != null)
        {
            enemy.GetComponent<FighterAction>().SelectAttack(attacks[randChoice]);
        }
        
        
        
        Debug.Log("I'd be punchin rn");
    }
}
