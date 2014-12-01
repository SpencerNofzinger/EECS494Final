using UnityEngine;
using System.Collections;

public class AddTransparency : MonoBehaviour {
	private Shader originalShader = null;
	private Color originalColor = Color.black;
	private const float targetTransparency = 0.6f;
	private float transparency = 0.0f;
	private const float fallOff = 0.1f;

	// Use this for initialization
	void Start () {

	}

	public void makeTransparent(){
				transparency = targetTransparency;

				if (!originalShader) {
						originalShader = renderer.material.shader;
						originalColor = renderer.material.color;
						renderer.material.shader = Shader.Find ("Transparent/Diffuse");
				}
		}


	// Update is called once per frame
	void Update () {
		if (transparency < 1.0f) {
						Color tempColor = renderer.material.color;
						tempColor.a = transparency;
						renderer.material.color = tempColor;
				}
		else{
			renderer.material.shader = originalShader;
			renderer.material.color = originalColor;
			// And remove this script
			Destroy(this);
		}
		transparency += ((1.0f - targetTransparency) * Time.deltaTime) / fallOff;
	}

}
