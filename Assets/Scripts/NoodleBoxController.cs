using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoodleBoxController : MonoBehaviour {

    public List<NoodleBox> noodleBoxes = new List<NoodleBox>();

	// Use this for initialization
	public void StartNoodleBoxes() {
        foreach (NoodleBox nb in noodleBoxes)
        {
            nb.StartNoodleBox();
        }
    }

    public void Clear()
    {
        foreach(NoodleBox nb in noodleBoxes)
        {
            nb.Clear();
        }
    }

    public void Stop()
    {
        foreach(NoodleBox nb in noodleBoxes)
        {
            nb.Stop();
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
