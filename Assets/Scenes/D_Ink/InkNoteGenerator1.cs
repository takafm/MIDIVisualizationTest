using UnityEngine;
using MidiJack;
public class InkNoteGenerator : MonoBehaviour
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
                print("ok");
                var note = Instantiate<GameObject>(prefab);
                var velocity = MidiMaster.GetKey(0, i);
                print("velocity: "+velocity);
                // 初期位置
                float x = map(i, 48, 72, -8, 8);
                float y = -5.8f;
                note.transform.position = new Vector3(x, y, -0.1f);

                Vector3 forceDirection = Vector3.zero;
                if ((int)Random.Range(0.0f, 10.0f)%3 == 0) {
                    // True Note 
                    forceDirection = new Vector3(0.0f, 1.0f, 0f);
                } else {
                    // Miss Note (dummy)
                    forceDirection = new Vector3(Random.Range(-0.3f, 0.3f), // x
                                                 Random.Range(0.0f, 1.0f),  // y
                                                 0.0f);                       // z
                }

                float forceMagnitude = velocity * 20.0f;
                Vector3 force = forceMagnitude * forceDirection;

                Rigidbody rb = note.GetComponent<Rigidbody>();
                rb.AddForce(force, ForceMode.Impulse);
            }
        }
    }

    float map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
}