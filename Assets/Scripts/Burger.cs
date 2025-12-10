using UnityEngine;

public class Burger : MonoBehaviour
{
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            PlayerController.Instance.HasBurger = true;
            transform.localScale = new Vector3(0, 1, 1);
            Dialogue.Instance.PrepareDialogueLines(new[] { "You picked up a burger" });
            Dialogue.Instance.StartDialogue();
        }
    }
}
