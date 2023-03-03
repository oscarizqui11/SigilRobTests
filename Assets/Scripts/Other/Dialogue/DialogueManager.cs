using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager _dialogueManager { get; private set; }
    public static bool speaking { get; private set; }

    #region PrivateVar
    private int currentIndex;
    private Conversation currentConver;
    private Animator _anim;
    private Coroutine typing;

    [SerializeField] private TextMeshProUGUI speakerName, dialogue, navButtonText;
    [SerializeField] private Image speakerSprite;
    #endregion

    private void Awake()
    {
        if(_dialogueManager == null)
        {
            _dialogueManager = this;
            _anim = GetComponent<Animator>();
        }
        else
            Destroy(this);
    }

    public void StartConversation(Conversation conver)
    {
        _dialogueManager._anim.SetBool("isOpen", true);
        _dialogueManager.currentIndex = 0;
        _dialogueManager.currentConver = conver;
        _dialogueManager.speakerName.text = "";
        _dialogueManager.dialogue.text = "";
        _dialogueManager.navButtonText.text = ">";
        speaking = true;

        _dialogueManager.ReadText();
    }

    private void ReadText()
    {
        if(currentIndex > currentConver.GetLength())
        {
            _dialogueManager._anim.SetBool("isOpen", false);
            speaking = false;

            return;
        }

        speakerName.text = currentConver.GetLineByIndex(currentIndex).speaker.GetName();

        if(typing == null)
            typing = _dialogueManager.StartCoroutine(TypeText(currentConver.GetLineByIndex(currentIndex).sentences));
        else
        {
            _dialogueManager.StopCoroutine(typing);
            typing = null;
            typing = _dialogueManager.StartCoroutine(TypeText(currentConver.GetLineByIndex(currentIndex).sentences));
        }

        speakerSprite.sprite = currentConver.GetLineByIndex(currentIndex).speaker.GetSprite();
        currentIndex++;

        if (currentIndex > currentConver.GetLength())
            navButtonText.text = "X";
    }

    private IEnumerator TypeText(string text)
    {
        dialogue.text = "";
        bool complete = false;
        int index = 0;

        while(!complete)
        {
            dialogue.text += text[index];
            index++;
            yield return new WaitForSeconds(0.02f);

            if (index == text.Length)
                complete = true;
        }

        typing = null;
    }
}
