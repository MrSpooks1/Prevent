using UnityEngine;

public class Book : MonoBehaviour
{
    public GameObject InterrogationRoomEntrance;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerController.Instance.HasBook = true;
            Dialogue.Instance.PrepareDialogueLines(new[] { "You pick up the book", "It speaks with you", "Oh, finally someone picked me up!", "It's been so long since i've felt a human hand", "Please tell me who we're going to kill?!", "You tell the book that you want to prevent a catastrophe that's going to happen here", "Sounds fun! Let's make a deal then. For every spell that you use i will take 1 year of your life" });
            Dialogue.Instance.StartDialogue();
            transform.localScale = new Vector3(0, 1, 1);
            InterrogationRoomEntrance.SetActive(true);
        }
    }
}
