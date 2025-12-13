using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class ItemPickup : MonoBehaviour
{
   public ItemPopupScript itemPopup;

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
        //itemPopup = FindObjectOfType<ItemPopupScript>();
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
                itemPopup.gameObject.SetActive(true);
                itemPopup.itemToPop = item;
                itemPopup.PopUp();

                GoldManager.instance.AddGold(item.worth);
                Debug.Log(item.description);
                Destroy(gameObject);
            }
        
        }
    }
}
