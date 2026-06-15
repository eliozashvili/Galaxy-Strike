using TMPro;
using UnityEngine;

public class Dialogues : MonoBehaviour
{
    [SerializeField] private string[] dialogueText;
    [SerializeField] private TMP_Text dialogueTextField;

    private int _currentDialogue;

    public void NextDialogue()
    {
        _currentDialogue++;

        dialogueTextField.text = dialogueText[_currentDialogue];
    }
}
