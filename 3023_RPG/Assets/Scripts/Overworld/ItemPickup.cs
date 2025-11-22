using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
    [SerializeField] InputActionAsset inputActions;

    public ScriptableItem item = null;

    public Image itemImage;

    InputAction grab;
    bool canPickUp;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Hero"))
        {
            canPickUp = true;
        }
        else
        {
            canPickUp = false;
        }
    }

    private void Start()
    {
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.sprite = item.icon;

        grab = inputActions.FindAction("Interact");
    }

    // Update is called once per frame
    void Update()
    {
        if (canPickUp) 
        {
            if (grab.IsPressed())
            {
                Debug.Log(item.description);
                Destroy(gameObject);
            }
        
        }
    }
}
