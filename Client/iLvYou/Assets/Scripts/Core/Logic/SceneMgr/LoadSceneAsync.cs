using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;  

//异步加载
public class LoadSceneAsync : MonoBehaviour
{
	private AsyncOperation m_Async = null;  

	private int m_NowProcess; 

	void Start ()
	{
		StartCoroutine(LoadingScene());  
	}
	
	IEnumerator LoadingScene()  
	{  
		m_Async = SceneManager.LoadSceneAsync(ScenceInfo.SceneName);  
		m_Async.allowSceneActivation = false;  
		yield return m_Async;  

	}


	void Update()  
	{  
		if(m_Async == null)  
		{  
			return;  
		}  

		int toProcess;  
		// async.progress 你正在读取的场景的进度值  0---0.9    
		// 如果当前的进度小于0.9，说明它还没有加载完成，就说明进度条还需要移动    
		// 如果，场景的数据加载完毕，async.progress 的值就会等于0.9  
		if(m_Async.progress < 0.9f)  
		{  
			toProcess = (int)m_Async.progress * 100;  
		}  
		else  
		{  
			toProcess = 100;  
		}  
		// 如果滑动条的当前进度，小于，当前加载场景的方法返回的进度   
		if(m_NowProcess < toProcess)  
		{  
			m_NowProcess++;  
		}  

		// 设置为true的时候，如果场景数据加载完毕，就可以自动跳转场景   
		if(m_NowProcess == 100)  
		{  
			m_Async.allowSceneActivation = true;  
		}  
	}
}
