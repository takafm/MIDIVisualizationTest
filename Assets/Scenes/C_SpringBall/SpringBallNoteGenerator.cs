using UnityEngine;
using MidiJack;
using DG.Tweening;

public class SpringBallNoteGenerator : MonoBehaviour
{
    public GameObject rootNotePrefab;
    public GameObject edgeNotePrefab;
    public GameObject lineNotePrefab;

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
                var velocity = MidiMaster.GetKey(0, i);
                // 初期位置
                float x = map(i, 48, 72, -8, 8);
                float y = -5.8f;
                var rootNote = Instantiate<GameObject>(rootNotePrefab);
                rootNote.transform.position = new Vector3(x, y, -0.1f);
                rootNote.GetComponent<RootNoteManager>().velocity = velocity;
                var lineNote = Instantiate<GameObject>(lineNotePrefab);
                lineNote.transform.position = new Vector3(x, y, -0.1f);
                lineNote.GetComponent<LineNoteManager>().rootPoint = new Vector3(x, y, -0.1f);

                // 到達位置
                Vector3 forceDirection = Vector3.zero;
                if ((int)Random.Range(0.0f, 10.0f)%3 == 0) {
                    // True Note 
                    forceDirection = new Vector3(0.0f, 1.0f, 0f);
                    print("true");
                } else {
                    // Miss Note (dummy)
                    float forceX = Random.Range(-0.3f, 0.3f);
                    float forceY = Random.Range(0.0f, 1.0f);
                    forceDirection = new Vector3(forceX, forceY, 0.0f);
                }

                float forceMagnitude = velocity * 15.0f;
                Vector3 endPoint = new Vector3(x, y, -0.1f) + forceMagnitude * forceDirection;
                var edgeNote = Instantiate<GameObject>(edgeNotePrefab);
                edgeNote.transform.position = endPoint;
                edgeNote.GetComponent<EdgeNoteManager>().velocity = velocity;
                lineNote.GetComponent<LineNoteManager>().endPoint = endPoint;
                
            }
        }
    }

    float map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
}