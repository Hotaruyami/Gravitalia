using UnityEngine;
using System.Collections;

public class enemic : MonoBehaviour {
	public GameObject coch,ene;
	public bool strart,end;
	private Vector3 ori;
	private float lastblock;
	public GameObject[] block,cubene;
	private Vector3 PosBlock,posEne;



	// Use this for initialization
	void Start () {
		lastblock = 0;
		strart = end = false;
	}
	
	// Update is called once per frame

	void FixedUpdate () {
		if (strart) {
			if (!end) {
				ene = Resources.Load("Enemic", typeof(GameObject)) as GameObject;	
				posEne = new Vector3 (coch.transform.position.x, coch.transform.position.y+2, coch.transform.position.z + 30);
				Instantiate (ene, posEne, Quaternion.identity);
				ene = GameObject.FindGameObjectWithTag("Enemic");
				end = true;

			}
			ene.transform.position = new Vector3 (coch.transform.position.x, ene.transform.position.y, coch.transform.position.z + 27);
			if (Time.time - lastblock >= 1) {
				PosBlock = new Vector3 (ene.transform.position.x, coch.transform.position.y, ene.transform.position.z - 4);
				int i = Random.Range (0, block.Length);
				Instantiate (block [i], PosBlock, Quaternion.identity);
				lastblock = Time.time;

			}
		} 
		else {
			if (end) {
				Destroy (ene);
				cubene = GameObject.FindGameObjectsWithTag ("cubenemic");
				for(var y = 0; y < cubene.Length; y++){
					Destroy (cubene[y]);
				}
				end = false;
				
			}
		}
	}
}
