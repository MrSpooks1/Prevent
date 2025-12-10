using UnityEngine;
using TMPro;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Dialogue : MonoBehaviour // this dialogue system was made in a rush and needs to be replaced
{
    public class DialogueLine
    {
        public string text;
        public bool hasOptions;
        public DialogueLine(string text)
        {
            this.text = text;
        }
    }
    public TextMeshProUGUI TextComponent;
    public List<DialogueLine> Lines;
    private float textSpeed = 0.05f;
    private int index;
    public bool ChoiceIsMade = false;
    public bool PlayerAgrees = false;
    public Button YesButton;
    public Button NoButton;
    public bool IsDialogueActive;
    public static Dialogue Instance { get; private set; }
    void Start()
    {
        if (Instance == null) Instance = this;
        else Destroy(gameObject);
        YesButton.onClick.AddListener(OnYesClicked);
        NoButton.onClick.AddListener(OnNoClicked);
        gameObject.SetActive(false);
        TextComponent.text = string.Empty;
        HideOptions();
    }
    void Update()
    {
        Debug.Log("Update выполняется: " + Time.time);
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (TextComponent.text == Lines[index].text)
            {
                if (!Lines[index].hasOptions) NextLine();
            }
            else
            {
                StopAllCoroutines();
                TextComponent.text = Lines[index].text;
            }
        }
    }
    public void StartDialogue()
    {
        IsDialogueActive = true;
        if (Lines == null) Lines.Add(new DialogueLine("Unknown error occurred"));
        index = 0;
        gameObject.SetActive(true);
        StartCoroutine(TypeLine());
    }
    IEnumerator TypeLine()
    {
        if (Lines[index].hasOptions) AskQuestion();
        foreach (char c in Lines[index].text.ToCharArray())
        {
            TextComponent.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }
    void NextLine()
    {
        if (index < Lines.Count - 1)
        {
            index++;
            TextComponent.text = string.Empty;
            if (Lines[index].text[0] != '!') StartCoroutine(TypeLine());
            else NextLine();
        }
        else
        {
            StopAllCoroutines();
            IsDialogueActive = false;
            gameObject.SetActive(false);
        }
    }
    public void AskQuestion()
    {
        ChoiceIsMade = false;
        ShowOptions();
    }
    private void OnYesClicked()
    {
        ChoiceIsMade = true;
        PlayerAgrees = true;
        Lines[index + 2].text = "!"+Lines[index+2].text;
        HideOptions();
        StopAllCoroutines();
        NextLine();
    }
    private void OnNoClicked()
    {
        ChoiceIsMade = true;
        PlayerAgrees = false;
        Lines[index + 1].text = "!" + Lines[index + 1].text;
        HideOptions();
        StopAllCoroutines();
        NextLine();
    }
    private void ShowOptions()
    {
        YesButton.gameObject.SetActive(true);
        NoButton.gameObject.SetActive(true);
    }
    private void HideOptions()
    {
        YesButton.gameObject.SetActive(false);
        NoButton.gameObject.SetActive(false);
    }
    public void PrepareDialogueLines(string[] lines)
    {
        Lines = new List<DialogueLine>();
        for (int i = 0; i < lines.Length; i++)
        {
            Lines.Add(new DialogueLine(lines[i]));
        }
    }
}
