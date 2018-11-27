using UnityEngine;
using MidiJack;
using DG.Tweening;

public class DRSpringBallNoteGenerator : MonoBehaviour
{
    public GameObject rootNotePrefab;
    public GameObject edgeNotePrefab;
    public GameObject lineNotePrefab;

    [SerializeField] private int startNote;
    [SerializeField] private int endNote;

    void Start()
    {
        // 48鍵盤の場合：48-96
        // 25鍵盤の場合：48-72
        startNote = 48;
        endNote = 96;
    }

    void Update()
    {
        // MIDI NOTE ASSIGN
        for (var i = startNote; i < endNote+1; i++)
        {
            // 鍵盤押されたら
            if(MidiMaster.GetKeyDown(i))
            {
                var velocity = MidiMaster.GetKey(0, i);
                // 初期位置
                float x = map(i, startNote, endNote, -10, 10); // -10, 10 は画面の横幅
                float y = -5.8f;
                var rootNote = Instantiate<GameObject>(rootNotePrefab);
                rootNote.transform.position = new Vector3(x, y, -0.1f);
                rootNote.GetComponent<DRRootNoteManager>().velocity = velocity;
                var lineNote = Instantiate<GameObject>(lineNotePrefab);
                lineNote.transform.position = new Vector3(x, y, -0.1f);
                lineNote.GetComponent<DRLineNoteManager>().rootPoint = new Vector3(x, y, -0.1f);

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
                edgeNote.GetComponent<DREdgeNoteManager>().velocity = velocity;
                lineNote.GetComponent<DRLineNoteManager>().endPoint = endPoint;
                
            }
        }
    }

    float map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
}