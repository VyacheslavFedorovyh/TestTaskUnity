using System;
using System.IO;
using System.Collections;
using UnityEngine;
using System.Collections.Generic;
using static StructuraJson;

public class InteractiveObjEmitterScript : MonoBehaviour
{
	[SerializeField] private List<GameObject> prefabInteractiveObj = new List<GameObject>();
	public float launchDelayInteractiveObj = 10f;
	private float nextLaunchTime;

	[Header("Loading From File")]
	public bool loadingFromFile = false;
	[SerializeField] private string loadPath;
	[SerializeField] private string loadFileName = "data.jsom";
	private int index = 0;

	void Update()
	{
		if (Time.time > nextLaunchTime)
		{
			int prefabIndex = UnityEngine.Random.Range(0, prefabInteractiveObj.Count - 1);
			var position = Vector3.zero;

			if (loadingFromFile)
			{
				if (!File.Exists(loadPath))
				{
					Debug.Log(message: "{GameLog} => [InteractiveObjEmitterScript] - Update - LoadingFromFile -> File Not Found");
					return;
				}

				try
				{
					string json = File.ReadAllText(loadPath);
					PositionPrefabInteractiveObj positionPrefab = JsonUtility.FromJson<PositionPrefabInteractiveObj>(json);
					position = (Vector3)positionPrefab.position.GetValue(index);
					++index;
				}
				catch (Exception e)
				{
					Debug.Log(message: "{GameLog} => [InteractiveObjEmitterScript] - Update -> (<color=red>Error</color>) - LoadingFromFile ->" + e.Message);
				}
			}
			else
			{
				var shiftX = UnityEngine.Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
				var shiftY = transform.rotation.y + 1.5f;
				var shiftZ = UnityEngine.Random.Range(-transform.localScale.x / 2, transform.localScale.x / 2);
				position = transform.position + new Vector3(shiftX, shiftY, shiftZ);
			}

			Instantiate(prefabInteractiveObj[prefabIndex], position, Quaternion.identity);

			nextLaunchTime = Time.time + launchDelayInteractiveObj;
		}
	}

	private void Awake()
	{
		loadPath = Path.Combine(Application.dataPath, loadFileName);
	}
}
