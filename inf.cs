using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class inf : MonoBehaviour {

	void Start()
	{
		AudioSource audiot = GetComponent<AudioSource> ();
		audiot.Play ();
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Escape)) 
			Application.Quit(); 
		
	}

	public void info_btn()
	{
		SceneManager.LoadScene("info_c");
	}

	public void comenzarJugar()
	{
		SceneManager.LoadScene ("nivel1");
	}


	public void salir()
	{
		Application.Quit();
		//SceneManager.UnloadScene (SceneManager.GetActiveScene);
	}
}
