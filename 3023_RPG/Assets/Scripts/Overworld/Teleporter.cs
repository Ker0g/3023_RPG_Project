using UnityEngine;
using UnityEngine.InputSystem;

public class Teleporter : MonoBehaviour
{

    [SerializeField] InputActionAsset inputActions;
    InputAction interact;
    public string destination;
    bool canInteract;

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            canInteract = true;
        }
        else
        {
            canInteract = false;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        interact = inputActions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if(canInteract)
        {
            if(interact.IsPressed())
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(destination);
            }
        }
    }
}
