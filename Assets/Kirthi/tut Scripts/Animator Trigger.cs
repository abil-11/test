using UnityEngine;

public class NewEmptyCSharpScript:MonoBehaviour
{
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetKeyDown("1")){
            this.GetComponent<Animator>().Play("AnimX");
        }
       if (Input.GetKeyDown("2"))
        {
            this.GetComponent<Animator>().Play("AnimY");
        }
        if (Input.GetKeyDown("3"))
        {
            this.GetComponent<Animator>().Play("AnimZ");
        }
    }

    private void OnMouseDown()
    {
        this.GetComponent<Animator>().Play("AnimX");
        this.GetComponent<Animator>().Play("AnimY");
        this.GetComponent<Animator>().Play("AnimZ");
    }
}
