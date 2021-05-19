using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

[System.Serializable]
public class LevalLoader : MonoBehaviour
{
	public Animator transition;
	public PlayerScript player;
	public float transitionTime = 1f;

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			LoadNextLeval(1);
		}
	}

	public void LoadNextLeval(int indexScene)
	{
		player.PositionVectorValue();

		StartCoroutine(LoadLevel(indexScene));
	}

	IEnumerator LoadLevel(int indexScene)
	{	
		transition.SetTrigger("Start");

		yield return new WaitForSeconds(transitionTime);

		SceneManager.LoadScene(indexScene);
	}
}
