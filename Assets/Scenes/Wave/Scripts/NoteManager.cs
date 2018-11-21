using UnityEngine;
using MidiJack;

public class NoteManager : MonoBehaviour {

	private Transform[] spheres;

	void Start () {
		spheres = GetChildren("Spheres");
	}
	
	void Update () {
		// MIDI NOTE: 48-69
        for (var i = 48; i < 69; i++)
        {
			// 鍵盤押されたら
            if(MidiMaster.GetKeyDown(i))
            {
                float x = Random.Range(-7.0f, 7.0f);
				if (Mathf.Abs(x) > 5) 
				{
					// 離れたとこに球が出た時に何がしたいかを以下に書く
					// spheres[i-48].GetComponent<WaveSpringSimulator>().enabled = false;
				}
                spheres[i-48].position = new Vector3(x, spheres[i-48].position.y, -0.1f);
				spheres[i-48].GetComponent<WaveSpringSimulator>().pos = new Vector3(x, spheres[i-48].position.y, -0.1f);
            }
        }
	}

	Transform[] GetChildren(string parentName) {
		var parent = GameObject.Find(parentName) as GameObject;
        if(parent == null)
		{
			return null;
		}
        var transforms = parent.GetComponentsInChildren<Transform>();
        return transforms;
	}

	float map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
}
