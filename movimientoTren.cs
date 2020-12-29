using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Text;
using UnityEngine.SceneManagement;
using System.Collections.Generic;

#if UNITY_EDITOR
using UnityEditor;
using UnityEditor.Events;
#endif


public class movimientoTren : MonoBehaviour {

	public float speed=5.0f;
	private Vector2 direction  = Vector2.zero;
	//private bool control=true;
	public int di=0;

	public static int vidas= 3;
	public static int puntos=0;
	public static int poder=0;
	public static int cont_juego1=0;//112 pelotas
	public static int cont_juego2=0;//113 pelotas
	public static int cont_juego3=0;//125 pelotas
	public static int cont_juego4=0;//126 pelotas
	public static int cont_juego5=0;//115 pelotas
	public static int cont_juego6=0;//141 pelotas


	private Vector3 pos_ini;

	public List<int> xx = new List<int>();
	public int indexx=0;


	public Sprite[] imagenes_tren = new Sprite[4];

    

	public AudioClip[] lista = new AudioClip[7];


	public fantasmaMovimiento[] fantasmitas= new fantasmaMovimiento[4];




	// Use this for initialization
	void Start ()
	{
		pos_ini = this.transform.localPosition;
		GameObject label = GameObject.Find ("puntosText");
		Text l = label.GetComponent<Text> ();
		l.text = puntos.ToString ();//se actualiza el puntaje en el texto al iniciar la escena

		GameObject labell = GameObject.Find ("vidasText");
		Text ll = labell.GetComponent<Text> ();
		ll.text = vidas.ToString ();//se actualiza las vidas en el texto al iniciar la escena


	}
	
	// Update is called once per frame
	void Update ()
	{


		//revisa si se terminó la partida
		if (vidas == 0)
		{
			vidas = 3;
			puntos = 0;
			cont_juego1 = 0;
			cont_juego2 = 0;
			cont_juego3 = 0;
			cont_juego4 = 0;
			cont_juego5 = 0;
			cont_juego6 = 0;
			SceneManager.LoadScene ("menu1");
		}

		//checkInput ();
		move();

		switch(SceneManager.GetActiveScene ().name)
		{
		case "nivel1":
			if (cont_juego1 == 111)
				SceneManager.LoadScene ("nivel2");
			//revisa las coordenadas para ver si aplica el teleport
			if (this.transform.localPosition.x > 306 && this.transform.localPosition.y > -48 && this.transform.localPosition.y < -18.5) {
				this.transform.localPosition = new Vector3 (-300, -35, 0);
			} 
			else if (this.transform.localPosition.x < -305 && this.transform.localPosition.y > -48 && this.transform.localPosition.y < -18.5) 
			{
				this.transform.localPosition = new Vector3 (302, -35, 0);
			}
				return;
			case "nivel2":
			if (cont_juego2 == 112)
				SceneManager.LoadScene ("nivel3");
			//revisa las coordenadas para ver si aplica el teleport
			if (this.transform.localPosition.x > 306 && this.transform.localPosition.y > -50 && this.transform.localPosition.y < -19) {
				this.transform.localPosition = new Vector3 (-300, -39, 0);
			} 
			else if (this.transform.localPosition.x < -305 && this.transform.localPosition.y > -50 && this.transform.localPosition.y < -19) 
			{
				this.transform.localPosition = new Vector3 (302, -39, 0);
			}
				return;
			case "nivel3":
			if (cont_juego3 == 124)
				SceneManager.LoadScene ("nivel4");
			//revisa las coordenadas para ver si aplica el teleport
			if (this.transform.localPosition.x > 306 && this.transform.localPosition.y > -6 && this.transform.localPosition.y < 19) {
				this.transform.localPosition = new Vector3 (-300, 6, 0);
			} 
			else if (this.transform.localPosition.x < -305 && this.transform.localPosition.y > -6 && this.transform.localPosition.y < 19) 
			{
				this.transform.localPosition = new Vector3 (302, 6, 0);
			}

				return;
			case "nivel4":
			if (cont_juego4 == 125)
				SceneManager.LoadScene ("nivel5");

			if (this.transform.localPosition.x > 305 && this.transform.localPosition.y > 80 && this.transform.localPosition.y < 115) {
				this.transform.localPosition = new Vector3 (-300, 95, 0);
			} 
			else if (this.transform.localPosition.x < -300 && this.transform.localPosition.y > 80 && this.transform.localPosition.y < 115) 
			{
				this.transform.localPosition = new Vector3 (302, 95, 0);
			}

				return;
			case "nivel5":
			if (cont_juego5 == 114)
				SceneManager.LoadScene ("nivel6");
			//revisa las coordenadas para ver si aplica el teleport
			if (this.transform.localPosition.x > 318 && this.transform.localPosition.y > -4 && this.transform.localPosition.y < 28) {
				this.transform.localPosition = new Vector3 (-300, 10, 0);
			} 
			else if (this.transform.localPosition.x < -310 && this.transform.localPosition.y > -4 && this.transform.localPosition.y < 28) 
			{
				this.transform.localPosition = new Vector3 (305, 10, 0);
			}

				return;
			case "nivel6":
			if (cont_juego6 == 140)
				SceneManager.LoadScene ("final");

				//revisa las coordenadas para ver si aplica el teleport
			if (this.transform.localPosition.x > 306 && this.transform.localPosition.y > -6 && this.transform.localPosition.y < 19) {
				this.transform.localPosition = new Vector3 (-300, 6, 0);
			} 
			else if (this.transform.localPosition.x < -305 && this.transform.localPosition.y > -6 && this.transform.localPosition.y < 19) 
			{
				this.transform.localPosition = new Vector3 (302, 6, 0);
			}

				return;
			
		}

	}



	public void up()
	{

		direction = Vector2.up;
		Image foto = this.GetComponent<Image> ();
		foto.sprite = imagenes_tren [0];
		di = 1;

		xx.Add(di);
		indexx=indexx+1;
		
	}

	public void down()
	{

		direction = Vector2.down;
		Image foto = this.GetComponent<Image> ();
		foto.sprite = imagenes_tren [0];
		di = 2;

		xx.Add(di);
		indexx=indexx+1;
	}

	public void right()
	{
		
		direction = Vector2.right;
		Image foto = this.GetComponent<Image> ();
		foto.sprite = imagenes_tren [1];
		di = 3;

		xx.Add(di);
		indexx=indexx+1;
	}

	public void left()
	{

		direction = Vector2.left;
		Image foto = this.GetComponent<Image> ();
		foto.sprite = imagenes_tren [2];
		di = 4;

		xx.Add(di);
		indexx=indexx+1;
	}


	public void move()
	{
		/*if (indexx >= 1) 
		{
			if (xx [indexx - 1] != di) 
			{
				transform.localPosition += (Vector3)(direction * speed )* Time.deltaTime;
			}
		} 
		else*/
			transform.localPosition += (Vector3)(direction * speed )* Time.deltaTime;

		
			

	}



	public void OnTriggerEnter2D(Collider2D other)
	{
		AudioSource audiot = GetComponent<AudioSource> ();


		if (other.gameObject.name == "dot" || other.gameObject.name == "rayo" || other.gameObject.name == "extra") {
			GameObject label = GameObject.Find ("puntosText");
			Text l = label.GetComponent<Text> ();


			if (other.gameObject.name == "dot") {   
				puntos = puntos + 10;

				audiot.clip = lista [0];


				//audiot.Play ();
				//audiot.Play (22050);

				//StartCoroutine (sonido(1,0));
				if (!audiot.isPlaying && audiot.clip == lista [0]) {
					audiot.Play ();
					audiot.loop = true;

				} 
				

			
				/*	GameObject au = new GameObject ();
				au.AddComponent<AudioSource> ();

				StartCoroutine (sonido(5,0,au));*/


			
				l.text = puntos.ToString ();//se actualiza el puntaje en el texto


				Destroy (other.gameObject);

				switch (SceneManager.GetActiveScene ().name) {
				case "nivel1":
					cont_juego1 = cont_juego1 + 1;
					return;
				case "nivel2":
					cont_juego2 = cont_juego2 + 1;
					return;
				case "nivel3":
					cont_juego3 = cont_juego3 + 1;

					return;
				case "nivel4":
					cont_juego4 = cont_juego4 + 1;

					return;
				case "nivel5":
					cont_juego5 = cont_juego5 + 1;
					return;
				case "nivel6":
					cont_juego6 = cont_juego6 + 1;

					return;

				}

			} else if (other.gameObject.name == "rayo") {

				//tiene la capacidad de comerse a los fantasmas durante un tiempo y suena un audio diferente

				/*audiot.clip = lista [1];
				audiot.Play ();*/

				if (audiot.isPlaying && audiot.clip == lista [0]) {
					audiot.loop = false;
					//audiot.Stop ();

				} 



				GameObject audi = new GameObject ();
				audi.name = "sonidorayo";
				audi.AddComponent<AudioSource> ();

				StartCoroutine (sonido (2, 1, audi));

				StartCoroutine (tiempoPoder ());

				l.text = puntos.ToString ();//se actualiza el puntaje en el texto

				Destroy (other.gameObject); //destruye el rayo


				
			} else if (other.gameObject.name == "extra") {
				if (audiot.isPlaying && audiot.clip == lista [0]) {
					audiot.loop = false;
					//audiot.Stop ();
				} 

				puntos = puntos + 200;

				GameObject audix = new GameObject ();
				audix.name = "sonidoextra";
				audix.AddComponent<AudioSource> ();

				StartCoroutine (sonido (1, 5, audix));

				l.text = puntos.ToString ();//se actualiza el puntaje en el texto

				Destroy (other.gameObject); //destruye el extra
			}





			
		} else if (other.gameObject.name == "PARED") {


			if (audiot.isPlaying && audiot.clip == lista [0]) {
				audiot.loop = false;
				//audiot.Stop ();
			} 
			
			direction = Vector2.zero;

			if (di == 1) { //arriba
				transform.localPosition -= (Vector3)(direction) - new Vector3 (0f, -4f, 0f);

			} else if (di == 2) {//abajo
				transform.localPosition -= (Vector3)(direction) - new Vector3 (0f, 4f, 0f);
			} else if (di == 3) {//derecha
				transform.localPosition -= (Vector3)(direction) - new Vector3 (-4f, 0, 0f);

			} else if (di == 4) {//izquierda
				transform.localPosition -= (Vector3)(direction) - new Vector3 (4f, 0f, 0f);
			}

			
		} else if (other.gameObject.name == "fantasma") {
			if (audiot.isPlaying && audiot.clip == lista [0]) {
				audiot.loop = false;
				//audiot.Stop ();
			} 

			if (poder == 0) { //se pierde una vida
				vidas = vidas - 1;

				//audiot.clip = lista [6];
				//audiot.Play ();

				GameObject au = new GameObject ();
				au.AddComponent<AudioSource> ();
		
				StartCoroutine (sonido (2, 6, au));



				//se actualiza el label de vidas
				GameObject label = GameObject.Find ("vidasText");

				Text l = label.GetComponent<Text> ();
				l.text = vidas.ToString ();

				direction = Vector2.zero;


				//reinicia a los fantasmas a su posicion inicial
				for (int i = 0; i < fantasmitas.Length; i++) {
					float xRespawn = Random.Range (-85f, 85f);
					float yRespawn = Random.Range (80f, 160f);

					fantasmitas [i].gameObject.transform.localPosition = new Vector3 (xRespawn, yRespawn, 0);

					fantasmitas [i].comible = 0;
					fantasmitas [i].direction = Vector2.zero;
					fantasmitas [i].di = 0;
				}




				this.transform.localPosition = pos_ini;



			} else {
				//aqui tengo que teletransportar al fantasma comido a su posición inicial
				fantasmaMovimiento killed = other.gameObject.GetComponent<fantasmaMovimiento> ();

				if (killed.comible == 1) {
					float xRespawn = Random.Range (-85f, 85f);
					float yRespawn = Random.Range (80f, 160f);

					other.gameObject.transform.localPosition = new Vector3 (xRespawn, yRespawn, 0);

					killed.comible = 0;
					killed.direction = Vector2.zero;
					killed.di = 0;

					GameObject au = new GameObject ();
					au.AddComponent<AudioSource> ();

					StartCoroutine (sonido (2, 4, au));
				
					
				} else {
					vidas = vidas - 1;

					audiot.clip = lista [6];
					audiot.Play ();



					//se actualiza el label de vidas
					GameObject label = GameObject.Find ("vidasText");

					Text l = label.GetComponent<Text> ();
					l.text = vidas.ToString ();

					direction = Vector2.zero;

					this.transform.localPosition = pos_ini;
					
				}


				//Destroy (other.gameObject);
				
				
			}
		} else if (other.gameObject.name == "vida_extra") {
			if (audiot.isPlaying && audiot.clip == lista [0]) {
				audiot.loop = false;
				//audiot.Stop ();
			} 

			vidas = vidas + 1;
			//se actualiza el label de vidas
			GameObject label = GameObject.Find ("vidasText");

			GameObject au = new GameObject ();
			au.AddComponent<AudioSource> ();

			StartCoroutine (sonido (2, 2, au));

			Text l = label.GetComponent<Text> ();
			l.text = vidas.ToString ();
			Destroy (other.gameObject);
		} 
		else
		{
			if (audiot.isPlaying && audiot.clip == lista [0]) {
				audiot.loop = false;

			} 
			audiot.Stop ();

		}


	}

	IEnumerator sonido(int seg,int index,GameObject obj)
	{
		//AudioSource audio = GetComponent<AudioSource> ();
		AudioSource audio = obj.GetComponent<AudioSource> ();
		audio.clip=lista [index];
		audio.Play ();
		yield return new WaitForSecondsRealtime (seg);
		Destroy (obj.gameObject); //destrye el gameObject que realiza el sonido

	}

	IEnumerator tiempoPoder()
	{
		poder = 1;

		//se cambia el sprite por el del poder de comerse a los fantasmas
		Image foto = this.GetComponent<Image> ();
		foto.sprite = imagenes_tren [3];

		for (int i = 0; i < 4; i++) 
		{
			fantasmitas [i].comible = 1; //el fantasma puede ser comido por el tren
		}

		yield return new WaitForSecondsRealtime (5);
		poder = 0;

		for (int i = 0; i < 4; i++) 
		{
			if (fantasmitas [i].comible == 1) 
			{
				fantasmitas [i].comible = 0; //el fantasma regresa a su estado natural (matar al tren)
			}


		}
		foto.sprite = imagenes_tren [0];



	}

	public void finalizar_partida()
	{
		vidas = 3;
		puntos = 0;
		cont_juego1 = 0;
		cont_juego2 = 0;
		cont_juego3 = 0;
		cont_juego4 = 0;
		cont_juego5 = 0;
		cont_juego6 = 0;
		SceneManager.LoadScene ("menu1");
	}



}
