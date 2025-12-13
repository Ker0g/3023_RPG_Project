using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Encounterer : MonoBehaviour
{
    float grace;
    [SerializeField] float encounterClock = 200;

    [SerializeField] PlayerMovement movement;    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        grace = Random.Range(1, 3);
    }

    // Update is called once per frame
    void Update()
    {
        grace -= Time.deltaTime;
      
       

    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            if (grace <= 0)
            {
                if (movement.isMoving == true)
                {
                    encounterClock -= Time.deltaTime;
                }

                if (encounterClock <= 0)
                {
                    Debug.Log("freak.");
                    LocationTracker.Instance.SavePlaceInScene(collision.transform.position);
                    SceneManager.LoadScene("BattleScene");

                }
            }
        }
    }
}
