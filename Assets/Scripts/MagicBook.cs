using UnityEngine;

public class MagicBook : MonoBehaviour
{
    public GameObject bulletPrefab;
    public PlayerController player;
    
    void Update()
    {
        if (player.HasBook && player.BossFightStarted) transform.localScale = Vector3.one;
        if (Input.GetKeyDown(KeyCode.Space) && player.HasBook && player.BossFightStarted)
        {
            Shoot();
        }
    }
    private void Shoot()
    {
        Instantiate(bulletPrefab, transform.position, transform.rotation);
    }
}
