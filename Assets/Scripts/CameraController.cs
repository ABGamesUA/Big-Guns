
using UnityEngine;

public class CameraController : MonoBehaviour {
	public float panSpeed = 30f;
	public float screenBuffer = 10f;
	public float scroolSpeed = 5f;
	public float minY = 10f;
	public float maxY = 80f;
	public float maxX = 80f;
	public float minX = -15f;
	public float maxZ = -20f;
	public float minZ = -80f;	
	// Update is called once per frame
	void Update () {
		if(GameManager.gameEnded){
			this.enabled = false;
			return;
		}

		if(transform.position.y <= 30f){
			maxZ = 0f;
		}
		else maxZ = -20f;		

		if(Input.GetKey("w")||Input.mousePosition.y >= Screen.height - screenBuffer ){
			if(transform.position.z <= maxZ){
			transform.Translate(Vector3.forward * panSpeed * Time.deltaTime, Space.World);}
		}
		if(Input.GetKey("s")||Input.mousePosition.y < screenBuffer ){
			if(transform.position.z >= minZ){
			transform.Translate(Vector3.back * panSpeed * Time.deltaTime, Space.World);}
		}
		if(Input.GetKey("d")||Input.mousePosition.x >= Screen.width - screenBuffer ){
			if(transform.position.x <= maxX){
			transform.Translate(Vector3.right * panSpeed * Time.deltaTime, Space.World);}
		}
		if(Input.GetKey("a")||Input.mousePosition.x <= screenBuffer ){
			if(transform.position.x >= minX){
			transform.Translate(Vector3.left * panSpeed * Time.deltaTime, Space.World);}
		}

		float scrool = Input.GetAxis("Mouse ScrollWheel");
		Vector3 pos = transform.position;
		pos.y -= scrool * 1000 * scroolSpeed * Time.deltaTime; 
		pos.y = Mathf.Clamp(pos.y, minY, maxY);
		transform.position = pos;
	}
}
