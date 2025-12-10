using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private float currentHp;
    public float MaxHp;
    void Start()
    {
        currentHp = MaxHp;
    }
    public void ReduceHP(float damage)
    {
        currentHp -= damage;
        if (currentHp <= 0)
        {
            currentHp = 0;
            Die();
        }
    }
    private void Die()
    {
        Dialogue.Instance.PrepareDialogueLines(new[] { "Good job, Jim. You did it" });
        Dialogue.Instance.StartDialogue();
        Destroy(gameObject);
    }
}
