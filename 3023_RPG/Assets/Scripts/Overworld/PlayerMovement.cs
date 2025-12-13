using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] InputActionAsset movement;
    [SerializeField] float speed = 5f;
    Vector2 direction;
    public bool isMoving = false;
    public float stepTimer = 0.25f;

    Animator animator;

    InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = movement.FindAction("Move");
        animator = GetComponent<Animator>();
        transform.position = LocationTracker.Instance.PlaceInScene;
    }

    // Update is called once per frame
    void Update()
    {
        direction = moveAction.ReadValue<Vector2>();

        Vector2 movement = direction * speed * Time.deltaTime;

        if (direction != new Vector2(0, 0)/*direction.x == 1 || direction.y == 1 || direction.x == -1 || direction.y == -1*/)
        { 
            isMoving = true;
        }
        else
        {
            isMoving = false;
        }

            transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, transform.position.z);

        if (isMoving)
        {
            stepTimer -= Time.deltaTime;
            if(stepTimer <= 0)
            {
                LocationTracker.Instance.Step();
                if(LocationTracker.Instance.PlayerLocation == "Hub" || LocationTracker.Instance.PlayerLocation == "Cave")
                {
                    SoundManager.PlaySound("hub step");
                }
                else {SoundManager.PlaySound("grass step"); }
                    
                stepTimer = 0.25f;
                Debug.Log(LocationTracker.Instance.StepsTaken);
            }
        }

        if (direction.x > 0)
        {
            animator.SetInteger("State", 4);
        }
        else if (direction.x < 0)
        {
            animator.SetInteger("State", 3);
        }
        else if (direction.y > 0)
        {
            animator.SetInteger("State", 1);
        }
        else if (direction.y < 0)
        {
            animator.SetInteger("State", 2);
        }
        else { animator.SetInteger("State", 0); }

        if (Input.GetKeyDown(KeyCode.G))
        {
            GoldManager.instance.AddGold(5000);
        }
    }
}
