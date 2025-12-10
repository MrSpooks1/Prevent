using UnityEngine;

public class EyeDemon : MonoBehaviour
{
    private bool alreadyTalked = false;
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (alreadyTalked) 
            { 
                if (PlayerController.Instance.HasBurger)
                {
                    Dialogue.Instance.PrepareDialogueLines(new[] { "You give burger to big floating eye", "Ah, a so called \"burger\"", "In the next cell lies a tome of destruction. It's the only thing that can help you. Believe me, you will need it" });
                }
                else
                {
                    Dialogue.Instance.PrepareDialogueLines(new[] { "Bring me food, Jim" });
                }
                Dialogue.Instance.StartDialogue();
            }
            else InitialDialogue();
        }
    }
    private void InitialDialogue()
    {
        alreadyTalked = true;
        if (PlayerController.Instance.HasBurger)
            Dialogue.Instance.PrepareDialogueLines(new[] { "What are you running around for, Jim. Are you looking for something?", "You ask big eye how he knows your name", "I know many things Jim. So, are you looking for something?", "You tell him that you're trying to prevent catastrophe that is going to happen here", "Ohoho, that explains why you're running around so much. Sadly it's impossible. Especially for someone as weak as you, Jim", "But i can help you minimize the damage. Let's make a deal", "You see, i'm very hungry. I will ask just a simple meal for a piece of my precious knowledge.", "You give burger to big floating eye", "Ah, a so called \"burger\"", "In the next cell lies a tome of destruction. It's the only thing that can help you. Believe me, you will need it"});
        else
            Dialogue.Instance.PrepareDialogueLines(new[] { "What are you running around for, Jim. Are you looking for something?", "You ask big eye how he knows your name", "I know many things Jim. So, are you looking for something?", "You tell him that you're trying to prevent catastrophe that is going to happen here", "Ohoho, that explains why you're running around so much. Sadly it's impossible. Especially for someone as weak as you, Jim", "But i can help you minimize the damage. Let's make a deal", "You see, i'm very hungry. I will ask just a simple meal for a piece of my precious knowledge.", "Bring me food, Jim" });
        Dialogue.Instance.StartDialogue();
    }
}
