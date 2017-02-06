using UnityEngine;
using System.Collections;

public class BlockSpawn : MonoBehaviour
{

    public GameObject[] Blocks; //array of blocks
    public Transform blockSpawnerPos; //tracks position of the block spawner
    public int blockCount = 0;
    public float newPos = 5.0f; //space between blocks

    private float waitTime = 1.2f; //wait time before new block is spawned
	private GameObject block;

	
	void Start ()
    {
        Block();  //calls block method
	}
	
	
	void Update ()
    {
	
	}

    public void Block()
    {
        block = Instantiate (Blocks [Random.Range(0,5)], blockSpawnerPos.position, Quaternion.identity) as GameObject;
        Vector3 temp = blockSpawnerPos.position;
        temp.y = 0;
        temp.x += newPos;
        temp.z = 0;
        blockSpawnerPos.position = temp;
		StartCoroutine (wait ());
    }
	IEnumerator wait()
	{
		yield return new WaitForSeconds (waitTime);
		blockCount += 1;
		Block ();
	}
}
