using UnityEngine;

public class JetpackScript : MonoBehaviour
{
    public void OnTriggerEnter(Collider other)
    {
        other.GetComponent<PlayerController>().SetJetpackActive(true);
        gameObject.SetActive(false);
    }
}
