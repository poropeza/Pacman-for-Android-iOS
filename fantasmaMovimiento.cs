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

public class fantasmaMovimiento : MonoBehaviour 
{

	private float speed=120.0f;
	public Vector2 direction  = Vector2.zero;
	//private bool control=true;
	public int di=0,index=0;
	public List<int> x = new List<int>();
	//public int[] x;
	float f;


	public int comible = 0;


	public Sprite[] fotos= new Sprite[2];

	private Image foto;

	// Use this for initialization
	void Start ()
	{
		Random.InitState (4500);

		//Debug.Log ("di: " + di);

		//x= new int[1000000000];

		foto = this.GetComponent<Image> ();

		di= Random.Range (1,4);
		//x = di;

		x.Add(di);
		//x = new int[aux.Count];
		//x = (int[])aux.ToArray();

	    //x[index] = di; //se sabe su valor anterior para verificarlo en el futuro, el index inicial es 0

		index=index+1;

		//Debug.Log ("di: " + di);

		if (di == 1)
		{
			direction = Vector2.up;
		}
		else if(di==2)
		{
			direction = Vector2.down;
		}
		else if(di==3)
		{
			direction = Vector2.right;
		}
		else if(di==4)
		{
			direction = Vector2.left;
		}

		transform.localPosition += (Vector3)(direction * speed )* Time.deltaTime;

	}
	
	// Update is called once per frame
	void Update () 
	{
		if (this.comible == 1) 
		{
			
			foto.sprite = fotos [1];
		}
		else
			foto.sprite = fotos [0];
			
		//Debug.Log (di);
		move ();

	}

	void move()
	{
		
		//x = new int[aux.Count];
	    //x = (int[])aux.ToArray();

		if (di == 0) 
		{ //se tiene que buscar dirección para el fantasma

			if (index == 1) {
				//hago cosas


				if (x [index - 1] == 1) {
					di = Random.Range (3, 4);
				} else if (x [index - 1] == 2) {
					di = Random.Range (3, 4);
				} else if (x [index - 1] == 3) {
					di = Random.Range (1, 2);
				} else if (x [index - 1] == 4)
					di = Random.Range (1, 2);

				//x [index] = di;

				/*if (x == 1) {
					di = Random.Range (3, 4);
				} else if (x == 2) {
					di = Random.Range (3, 4);
				} else if (x == 3) {
					di = Random.Range (1, 2);
				} else if (x == 4)
					di = Random.Range (1, 2);
				x [index] = di;*/




			} 
			else
			{
				//hago cosas
				/*do {
					
					di = Random.Range (1,4);

				}while(di == x [index - 1] || di == x [index - 2]);
					
				
					x [index] = di;
					index=index+1;
		*/
				f = Random.value;//obtiene un valor aleatorio entre 0 y 1


				//se verifica el movimiento actual y el anterior(espacio euclideano) VECTORES
				if (x [index - 1] == 1 && x [index - 2] == 3) {



					if (f > 0.5)
						di = 4;
					else
						di = 2;


				} else if (x [index - 1] == 4 && x [index - 2] == 1) {
					if (f > 0.5)
						di = 3;
					else
						di = 2;
				} else if (x [index - 1] == 3 && x [index - 2] == 2) {
					if (f > 0.5)
						di = 4;
					else
						di = 1;

				} else if (x [index - 1] == 4 && x [index - 2] == 2) {
					if (f > 0.5)
						di = 3;
					else
						di = 1;
				}
				else if (x [index - 1] == 3 && x [index - 2] == 1) {



					if (f > 0.5)
						di = 4;
					else
						di = 2;


				}
				else if (x [index - 1] == 1 && x [index - 2] == 4) {
					if (f > 0.5)
						di = 3;
					else
						di = 2;
				}
				else if (x [index - 1] == 2 && x [index - 2] == 3) {
					if (f > 0.5)
						di = 4;
					else
						di = 1;

				}
				else if (x [index - 1] == 2 && x [index - 2] == 4) {
					if (f > 0.5)
						di = 3;
					else
						di = 1;
				}
				else if (x [index - 1] == 4 && x [index - 2] == 3) {
					if (f > 0.5)
						di = 2;
					else
						di = 1;
				}
				else if (x [index - 1] == 3 && x [index - 2] == 4) {
					if (f > 0.5)
						di = 2;
					else
						di = 1;
				}
				else if (x [index - 1] == 2 && x [index - 2] == 1) {
					if (f > 0.5)
						di = 4;
					else
						di = 3;
				}
				else  {
					if (f > 0.5)
						di = 4;
					else
						di = 3;
				}

					
				


			} 
			x.Add (di);
			//x [index] = di;
			index = index + 1;
			//x = null;

			//x = di;		



			if (di == 1) {
				direction = Vector2.up;
			} else if (di == 2) {
				direction = Vector2.down;
			} else if (di == 3) {
				direction = Vector2.right;
			} else if (di == 4) {
				direction = Vector2.left;
			}

		}


		transform.localPosition += (Vector3)(direction * speed )* Time.deltaTime;
		
	}




	public void OnTriggerEnter2D(Collider2D other)
	{
		
		if (other.gameObject.name == "PARED") 
		{

			direction = Vector2.zero;

			if (di == 1) //arriba
			{
				transform.localPosition -= (Vector3)(direction)- new Vector3(0f,-4f,0f);
				di = 0;

			}
			else if(di==2)//abajo
			{
				transform.localPosition -= (Vector3)(direction)- new Vector3(0f,4f,0f);
				di = 0;
			}
			else if(di==3)//derecha
			{
				transform.localPosition -= (Vector3)(direction)- new Vector3(-4f,0f,0f);
				di = 0;

			}
			else if(di==4)//izquierda
			{
				transform.localPosition -= (Vector3)(direction)- new Vector3(4f,0f,0f);
				di = 0;
			}




		}

	}



}
