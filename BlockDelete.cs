using UnityEngine;
using System.Collections;

public class BlockDelete : MonoBehaviour
{
    private float waitTime = 3.0f;

    void OnTriggerExit2D(Collider2D other)
    {
        StartCoroutine(delete());
        other.GetComponent<Player>().ScorePlus(1);
    }

    IEnumerator delete()
    {
        yield return new WaitForSeconds(waitTime);
        Destroy(gameObject);
    }
}
