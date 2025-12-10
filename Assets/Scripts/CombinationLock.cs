using UnityEngine;

public class CombinationLock : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (PlayerController.Instance.HasCode)
            {
                Dialogue.Instance.PrepareDialogueLines(new[] { "A book locked in a cell?", "Maybe it's some kind of magic demon book? You don't know much about it and probably never wanted to", "There's a combination lock here", "Out of desperation you've used code written on paper", "The cell is open now" });
                Dialogue.Instance.StartDialogue();
                transform.localScale = new Vector3(0, 1, 1);
            }
            else
            {
                Dialogue.Instance.PrepareDialogueLines(new[] { "A book locked in a cell?", "Maybe it's some kind of magic demon book? You don't know much about it and probably never wanted to", "There's a combination lock here" });
                Dialogue.Instance.StartDialogue();
            }
        }
    }
}
