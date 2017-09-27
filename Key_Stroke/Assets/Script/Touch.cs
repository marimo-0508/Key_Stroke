using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Touch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	void Update()
	{
		
		OnTouchDown();
	}

	//スマホ向け そのオブジェクトがタッチされていたらtrue（マルチタップ対応）
	void OnTouchDown() {
		// タッチされているとき
		if( 0 < Input.touchCount){
			// タッチされている指の数だけ処理
			for(int i = 0; i < Input.touchCount; i++){
				UnityEngine.Touch t = Input.GetTouch(i); // タッチ情報をコピー
				if(t.phase == TouchPhase.Began ){ // タッチしたときかどうか
					//タッチした位置からRayを飛ばす
					Ray ray = Camera.main.ScreenPointToRay(t.position);
					RaycastHit hit = new RaycastHit();
					if (Physics.Raycast(ray, out hit)){
						//Rayを飛ばしてあたったオブジェクトが自分自身だったら
						if (hit.collider.gameObject != null){
							Debug.Log( hit.collider.gameObject.name);
						}
					}

					ChangeScale ();
				}
			}
		}
	}

	void ChangeScale(){
		GameObject a = GameObject.Find("a");
		a.transform.localScale = new Vector3(0.1f + 0.1f*Time.deltaTime, 0.1f, 0.1f);
	}
}