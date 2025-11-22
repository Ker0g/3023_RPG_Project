using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ItemPopupScript : MonoBehaviour
{
    public ScriptableItem itemToPop;

    [SerializeField] TMP_Text itemName;
    [SerializeField] TMP_Text itemDescription;
    [SerializeField] Image itemImage;

    public float activeTime = 3;

    public bool isActive = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    private void Awake()
    {
      gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (isActive)
        {
            
            activeTime -= Time.deltaTime;

            if (Input.GetKeyDown(KeyCode.Mouse0))
            {
                activeTime = 0;
            }
            if(activeTime <= 0)
            {
                isActive = false;
                
                gameObject.SetActive(false);
            }

        }
    }

    public void PopUp()
    {
        Debug.Log("Why");
        
            gameObject.SetActive(true);
            itemName.text = itemToPop.name;
            itemDescription.text = itemToPop.description;
            itemImage.sprite = itemToPop.icon;
            isActive = true;
            activeTime = 3;

    }
}
