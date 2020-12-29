using UnityEngine;
using System.Collections;
using System.Text;
using UnityEngine.UI;

public class generarPausa : MonoBehaviour {
	public GameObject x;
	public Text l;
	public Sprite[] v = new Sprite[2];
	// Use this for initialization
	private Image foto;
	void Start ()
	{
		//x=  new GameObject();
		x= GameObject.Find("pausa");
		l = x.GetComponent<Text> ();
		//x.SetActive(false);

		foto = this.GetComponent<Image> ();
	}

	void Update(){
	}

	public void genPausa()
	{
		if (l.text=="") 
		{
			Time.timeScale = 0;


			//movimientoTren.GetComponent<AudioSource> ().Stop();
			AudioSource f = GameObject.Find ("tren").GetComponent<AudioSource>();
			f.Stop ();


			foto.sprite = v[1];

			l.text="Click To Play";
		} 
		else 
		{
			Time.timeScale = 1;
			l.text = "";
			foto.sprite = v[0];
		}
		
	}
}
