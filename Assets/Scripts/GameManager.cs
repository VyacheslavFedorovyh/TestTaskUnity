using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
	bool gameHasEnded = false;
	public float restartDelay = 3f;
	[SerializeField] private GameObject gameOverIU;

	public void EndGame()
	{
		if (gameHasEnded == false)
		{
			gameHasEnded = true;
			gameOverIU.SetActive(true);
			Invoke("Restart", restartDelay);
		}
	}

	void Restart()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}
}
