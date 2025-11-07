using UnityEngine;

public class BattleSystem : MonoBehaviour
{
    public Character player;
    public Character enemy;
    [SerializeField] TextTyper textTyper;
    public int a = 5;
    private BattleSystem() { }


    private static BattleSystem instance = null;
    public static BattleSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<BattleSystem>();

            }
            return instance;
        }
        private set
        {
            instance = value;
        }
    }

    void Awake()
    {
        GameObject playerObj = GameObject.FindGameObjectWithTag("Hero");
        GameObject enemyObj = GameObject.FindGameObjectWithTag("Enemy");

        // Get Character components from those GameObjects
        if (playerObj != null)
            player = playerObj.GetComponent<Character>();

        if (enemyObj != null)
            enemy = enemyObj.GetComponent<Character>();
    }

    public void PerformAbility(Ability ability, FighterStats user, FighterStats target)
    {
        Debug.Log($"{user.name} uses {ability.name} on {target.name}");
        ability.Activate(user, target);
    }


}
