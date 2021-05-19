using UnityEngine;

public class TeleportLevelLoader : MonoBehaviour
{
	[SerializeField] private LevalLoader levalLoader;	

	public int indexScene = 0;
	private bool onTrigger = false;

	private void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player")
			onTrigger = true;
	}

	private void OnTriggerExit(Collider other)
	{
		if (other.tag == "Player")
			onTrigger = false;
	}

	private void OnMouseDown()
	{
		if (onTrigger)
			levalLoader.LoadNextLeval(indexScene);		
	}
}
