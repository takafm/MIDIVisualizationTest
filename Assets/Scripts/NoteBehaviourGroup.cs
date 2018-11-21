using UnityEngine;
using MidiJack;
public class NoteBehaviourGroup : MonoBehaviour
{
    public GameObject prefab;

    void Start()
    {
    }

    void Update()
    {
        // MIDI NOTE: 48-73
        for (var i = 48; i < 73; i++)
        {
            // 鍵盤押されたら
            if(MidiMaster.GetKeyDown(i))
            {
                var note = Instantiate<GameObject>(prefab);
                float x = map(i, 48, 72, -8, 8);
                float y = Random.Range(-5.0f, 5.0f);
                note.transform.position = new Vector3(x, y, -0.1f);
            }
        }
    }

    float map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
}