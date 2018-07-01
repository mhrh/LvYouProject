using UnityEngine;
using System.Collections;
using System;
using Game.Media;
public class App : SingletonUnity<App>
{
	// Use this for initialization
	void Start () {

		//媒体Test
		MediaMgr mgr = MediaMgr.sInstance; //this.gameObject.GetComponent<MediaMgr> ();
		//mgr.PlayBGM ("A");
		//mgr.PlaySE ("A");
		mgr.PlayENV ("Sound/A");
		//mgr.PlayMovie("r",null,Color.red);

		//事件Test
		EventManager.Instance.AddListener<TestEvent>(EventCallBack,5);

		//ResMgr Test
		ResManager.Instance.GetRes("0.png",EResType.TEXTURE,ResCb,null);

		ResManager.Instance.GetRes("0.png",EResType.TEXTURE,ResCb1,5);

	}
	void ResCb(UnityEngine.Object obj, object param)
	{
		Debug.Log ("加载陈宫");
	}
	void ResCb1(UnityEngine.Object obj, object param)
	{
		Debug.Log ("加载陈宫"+param);
	}
	void EventCallBack(EventArgs e)
	{
		TestEvent te = (TestEvent)e;
		Debug.Log (te.Element);
	}
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown (KeyCode.Y)) {

			EventManager.Instance.Trigger<TestEvent> (new TestEvent (6), 5);
		}
	}

	void Action1 ()
	{
		Debug.Log("123");
	}
    void FixedUpdate()
    {
        ResManager.Instance.FixedUpdate();
    }
    
}