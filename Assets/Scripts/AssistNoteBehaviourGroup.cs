using UnityEngine;
using MidiJack;
public class AssistNoteBehaviourGroup : MonoBehaviour
{
    public GameObject prefab;
    public Material errorMaterial;
    public Material warningMaterial;
    public Material defaultMaterial;

    [SerializeField] float threshError = 3.0f;
    [SerializeField] float threshWarning = 1.5f;

    void Start()
    {
    }

    void Update()
    {
        for (var i = 48; i < 73; i++)
        {
            // 鍵盤押されたら
            if (MidiMaster.GetKeyDown(i))
            {
                var note = Instantiate<GameObject>(prefab);
                float x = map(i, 48, 72, -8, 8);
                float y = Random.Range(-5.0f, 5.0f);
                if (Mathf.Abs(y) > threshError)
                {
                    note.GetComponent<Renderer>().material = errorMaterial;
                    note.GetComponent<SpringSimulator>().enabled = false;
                } else if (Mathf.Abs(y) > threshWarning)
                {
                    note.GetComponent<Renderer>().material = warningMaterial;
                } else 
                {
                    note.GetComponent<Renderer>().material = defaultMaterial;
                }
                note.transform.position = new Vector3(x, y, -0.1f);
            }
        }
    }

    float map(float value, float start1, float stop1, float start2, float stop2)
    {
        return start2 + (stop2 - start2) * ((value - start1) / (stop1 - start1));
    }
}