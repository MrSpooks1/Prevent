using UnityEngine;

public class InterrogationRoomTrigger : MonoBehaviour
{ // when player enters interrogation room show it and hide research center closing the door behind
    public GameObject ResearchCenter;
    public GameObject InterrogationRoom;
    private void Start()
    {
        gameObject.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        ResearchCenter.gameObject.SetActive(false);
        InterrogationRoom.gameObject.SetActive(true);
        PlayerController.Instance.BossFightStarted = true;
    }
}
