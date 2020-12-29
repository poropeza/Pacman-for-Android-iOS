using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class play : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	/*void Update () {


			if (Input.GetKeyDown(KeyCode.Escape)) 
				SceneManager.LoadScene ("menu1"); 

		
	
	}*/

	public void comenzarJugar()
	{
		SceneManager.LoadScene ("nivel1");
	}

	public void regresar()
	{
		SceneManager.LoadScene ("menu1");
	}
}
