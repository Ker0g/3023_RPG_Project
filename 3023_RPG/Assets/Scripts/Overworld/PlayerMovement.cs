using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{

    [SerializeField] InputActionAsset movement;
    [SerializeField] float speed = 5f;
    Vector2 direction;
    public bool isMoving;

    InputAction moveAction;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        moveAction = movement.FindAction("Move");
    }

    // Update is called once per frame
    void Update()
    {
        direction = moveAction.ReadValue<Vector2>();

        Vector2 movement = direction * speed * Time.deltaTime;

        if (direction.x == 1 || direction.y == 1)
        { 
            isMoving = true;
        }

        transform.position = new Vector3(transform.position.x + movement.x, transform.position.y + movement.y, transform.position.z);

        
    }
}
