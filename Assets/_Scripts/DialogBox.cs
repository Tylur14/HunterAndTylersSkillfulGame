using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DialogBox : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI textName;
    [SerializeField] private TextMeshProUGUI textBody;
    [SerializeField] private string currentString;
    [SerializeField] private bool requireKeyPressToFinish = true;

    [SerializeField] private GameObject[] objs;

    // todo - add support for stopping dialog at any point
    // todo - add support for speeding / instant text
    
    // Get info for the current interaction
    public void InitDialogBox(DialogTrigger dialogItem)
    {
        foreach (var t in objs)
            t.SetActive(true);
        
        textName.text = dialogItem.GetDialog().Item1;
        currentString = dialogItem.GetDialog().Item2;
        DisplayText();
    }
    
    void DisplayText()
    {
        StartCoroutine(ProcessText());
        IEnumerator ProcessText()
        {
            print("Processing!");
            textBody.text = "";
            foreach (char c in currentString.ToCharArray())
            {
                textBody.text += c;
                while (Input.GetKeyDown(KeyCode.Space))
                    yield break;
                yield return new WaitForSeconds(0.045f);
            }
            if(requireKeyPressToFinish)
                yield return StartCoroutine(WaitForKeyDown(KeyCode.Space));
            foreach (var t in objs)
                t.SetActive(false);
            yield break;
        }
    }
    
    IEnumerator WaitForKeyDown(KeyCode keyCode)
    {
        print("Waiting..");
        while (!Input.GetKeyDown(keyCode))
            yield return null;
    }
}
