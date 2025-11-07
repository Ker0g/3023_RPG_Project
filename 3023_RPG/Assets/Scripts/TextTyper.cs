using System.Collections;
using TMPro;
using UnityEngine;

public class TextTyper : MonoBehaviour
{
    private TextMeshProUGUI textComponent;

    private Coroutine currentCoroutine = null;

    private void Start()
    {
        textComponent = GetComponent<TextMeshProUGUI>();
    }

    public void TypeText()
    {
        TypeText("testing testing awawawawawawawa");
    }

    public void TypeText(string message)
    {
        if (currentCoroutine != null)
        {
            StopCoroutine(currentCoroutine);
        }
        currentCoroutine = StartCoroutine(TypeTextCoroutine(message));
    }

    IEnumerator TypeTextCoroutine(string messageToType)
    {
        textComponent.text = "";
        for (int i = 0; i < messageToType.Length; i++)
        {
            textComponent.text += messageToType[i];
            yield return null;
        }
    }
}
