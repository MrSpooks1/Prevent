using UnityEngine;

public class Paper : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerController.Instance.HasCode = true;
            transform.localScale = new Vector3(0, 1, 1);
            Dialogue.Instance.PrepareDialogueLines(new[] { "You picked up a piece of paper", "There is some kind of code written on it" });
            Dialogue.Instance.StartDialogue();
        }
    }
}
