
using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class WaweSpawner : MonoBehaviour {

	public static int enemiesAlive;
	public Wawe[] wawes;
	public GameManager gameManager;
	public Transform spawnPoint;
	public Text countDownText;
	public float timeBetweenWawes = 20f;
	private float countDown = 2f;
	private int waweIndex = 0;

	public AudioClip startGame;
	public AudioClip startWave;
	
	private void Start()
	{
		enemiesAlive = 0;
		SoundManager.instance.PlayEventSFX(startGame);
	}


	void Update () {
		/*if(enemiesAlive > 0){
			return;
		}*/
		if(waweIndex < wawes.Length)
		{
			if(countDown <= 0f)
			{
				StartCoroutine(SpawnWawe());
				countDown = timeBetweenWawes;
				return;
			}
			countDown -=Time.deltaTime;
			countDown = Mathf.Clamp(countDown, 0f, Mathf.Infinity);
			countDownText.text = string.Format("{0:00.00}", countDown);
		}
		if(waweIndex >= wawes.Length && enemiesAlive == 0 && !GameManager.gameEnded){

			gameManager.WinLevel();
			this.enabled = false;
		}		
		
	}

	IEnumerator SpawnWawe(){
		SoundManager.instance.PlayEventSFX(startWave);
		PlayerStats.rounds++;	
		Wawe wawe = wawes[waweIndex]; 
		//enemiesAlive = wawe.count;		
			for (int i = 0; i < wawe.count; i++)
			{
				SpawnEnemy(wawe.enemy);
				yield return new WaitForSeconds(1f/wawe.rate);
			}
			waweIndex++;
		
			
	}

	void SpawnEnemy(GameObject enemy){		
		Instantiate(enemy, spawnPoint.position, spawnPoint.rotation);
		//enemiesAlive++;
	}
}
