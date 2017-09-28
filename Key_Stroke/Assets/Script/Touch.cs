using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Touch : MonoBehaviour {

	private bool flag;
	private string gameobject_name;
	// Use this for initialization
	void Start () {
		flag = false;
	}
	
	void Update()
	{
		
		OnTouchDown();
		if(flag == true){
		ChangeScale ();
		}
	}

	//スマホ向け そのオブジェクトがタッチされていたらtrue（マルチタップ対応）
	void OnTouchDown() {
		// タッチされているとき
		if (0 < Input.touchCount) {
			// タッチされている指の数だけ処理
			for (int i = 0; i < Input.touchCount; i++) {
				UnityEngine.Touch t = Input.GetTouch (i); // タッチ情報をコピー
				if (t.phase == TouchPhase.Began) { // タッチしたときかどうか
					flag = true;
					//タッチした位置からRayを飛ばす
					Ray ray = Camera.main.ScreenPointToRay (t.position);
					RaycastHit hit = new RaycastHit ();
					if (Physics.Raycast (ray, out hit)) {
						//Rayを飛ばしてあたったオブジェクトが自分自身だったら
						if (hit.collider.gameObject != null) {
							Debug.Log (hit.collider.gameObject.name);
							gameobject_name = hit.collider.gameObject.name;
						}
					}

				}
			}
		} else {
			flag = false;
		}
	}

	void ChangeScale(){
		if(gameobject_name.Equals("Cube_0")){
		GameObject magic_0= GameObject.Find("magic_0");
		magic_0.transform.localScale += new Vector3(0.001f, 0.001f, 0.0f);
		}
	}
}

///sffsfdfhuhgifdhiguhd