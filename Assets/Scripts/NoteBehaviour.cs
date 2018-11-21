using UnityEngine;
using MidiJack;

public class NoteBehaviour : MonoBehaviour {

    public Material errorMaterial;
    public Material warningMaterial;
    public Material defaultMaterial;

    public int noteNumber;

    void Update()
    {
        // TODO: 以下、ちゃんと排他的になってない（漏れがある）気がする
        if (Mathf.Abs(transform.position.y) < 1) 
        {
            transform.GetComponent<Renderer>().material = defaultMaterial;
        } else if (Mathf.Abs(transform.position.y) > 3)
        {
            transform.GetComponent<Renderer>().material = errorMaterial;
        } 
        else
        {
            transform.GetComponent<Renderer>().material = warningMaterial;
        }
    }
}
