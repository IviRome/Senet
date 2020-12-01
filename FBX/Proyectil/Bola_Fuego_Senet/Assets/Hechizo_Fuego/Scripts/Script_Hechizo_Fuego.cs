using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Script_Hechizo_Fuego : MonoBehaviour
{

	public float speed;
	[Tooltip("From 0% to 100%")]
	public GameObject muzzlePrefab;
	public GameObject hitPrefab;
	public AudioClip shotSFX;
	public AudioClip hitSFX;
	private Vector3 offset;
	private bool collided;
	public Button elBoton;
	private Button btn;
	private int dispararBola;
	private Vector3 posicionSpawnBola;
	private GameObject otraBola;

	void Start()
	{

		dispararBola = 0;
		posicionSpawnBola = transform.position;
		btn = elBoton.GetComponent<Button>();
		btn.onClick.AddListener(TaskOnClick);
		inicializarDisparo();
		
	}

	void Update()
	{

		moverBola();

	}

	void moverBola()
    {
		//Debug.Log("Muevo la bola");
		if (speed != 0 && dispararBola == 1)
			transform.position += (transform.forward + offset) * (speed * Time.deltaTime);
	}

	void spawnearBola()
    {
		otraBola = Instantiate(gameObject, posicionSpawnBola, Quaternion.identity);
	}

	void TaskOnClick()
	{
		dispararBola = 1;
		spawnearBola();
	}

	void inicializarDisparo()
    {
		if (muzzlePrefab != null)
		{
			var muzzleVFX = Instantiate(muzzlePrefab, transform.position, Quaternion.identity);
			muzzleVFX.transform.forward = gameObject.transform.forward + offset;
			var ps = muzzleVFX.GetComponent<ParticleSystem>();
			if (ps != null)
				Destroy(muzzleVFX, ps.main.duration);
			else
			{
				var psChild = muzzleVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
				Destroy(muzzleVFX, psChild.main.duration);
			}
		}

		if (shotSFX != null && GetComponent<AudioSource>())
		{
			GetComponent<AudioSource>().PlayOneShot(shotSFX);
		}
	}

	void OnCollisionEnter(Collision co)
	{
		dispararBola = 0;
		if (co.gameObject.tag != "Bullet" && !collided)
		{
			collided = true;

			if (shotSFX != null && GetComponent<AudioSource>())
			{
				GetComponent<AudioSource>().PlayOneShot(hitSFX);
			}

			speed = 0;
			GetComponent<Rigidbody>().isKinematic = true;

			ContactPoint contact = co.contacts[0];
			Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
			Vector3 pos = contact.point;

			if (hitPrefab != null)
			{
				var hitVFX = Instantiate(hitPrefab, pos, rot);
				var ps = hitVFX.GetComponent<ParticleSystem>();
				if (ps == null)
				{
					var psChild = hitVFX.transform.GetChild(0).GetComponent<ParticleSystem>();
					Destroy(hitVFX, psChild.main.duration);
				}
				else
					Destroy(hitVFX, ps.main.duration);
			}		

			StartCoroutine(DestroyParticle(0f));
		}
	}

	public IEnumerator DestroyParticle(float waitTime)
	{

		if (transform.childCount > 0 && waitTime != 0)
		{
			List<Transform> tList = new List<Transform>();

			foreach (Transform t in transform.GetChild(0).transform)
			{
				tList.Add(t);
			}

			while (transform.GetChild(0).localScale.x > 0)
			{
				yield return new WaitForSeconds(0.01f);
				transform.GetChild(0).localScale -= new Vector3(0.1f, 0.1f, 0.1f);
				for (int i = 0; i < tList.Count; i++)
				{
					tList[i].localScale -= new Vector3(0.1f, 0.1f, 0.1f);
				}
			}
		}

		yield return new WaitForSeconds(waitTime);
		Destroy(gameObject);
	}


}
