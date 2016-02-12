using UnityEngine;
using System.Collections;

public class enemic : MonoBehaviour {
	public GameObject coch;
	private float x,y,z;
	private Collider CarCollider;
	public bool strart;
	private Vector3 ori;
	private float lastblock;
	public GameObject[] block;
	private Vector3 PosBlock;



	// Use this for initialization
	void Start () {
		lastblock = 0;
		ori = new Vector3(transform.position.x,transform.position.y,transform.position.z);
		strart = false;
		coch = GameObject.FindGameObjectWithTag("cotxe");
	}
	
	// Update is called once per frame

	void FixedUpdate () {
		z = coch.transform.position.z;
		if (strart) {
			//gameObject.SetActive (true);
			transform.position = new Vector3 (coch.transform.position.x, coch.transform.position.y,coch.transform.position.z+20);
			if(Time.time - lastblock >= 1){
				PosBlock = new Vector3 (transform.position.x,transform.position.y,transform.position.z-2);
				int i = Random.Range(0, block.Length);
				Instantiate(block[i],PosBlock,Quaternion.identity);
				lastblock = Time.time;
			}

		
		}
		else
		{
			transform.position = ori;
			//gameObject.SetActive (false);
		}
			
	}



	//OnCollisionExit
}
