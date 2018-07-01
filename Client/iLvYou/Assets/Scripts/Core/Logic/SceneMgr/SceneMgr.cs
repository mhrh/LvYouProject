using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; 
/// <summary>
/// 关卡管理类
/// </summary>
public class SceneMgr:Singleton<SceneMgr>
{
	public void LoadScene()
	{
		SceneManager.LoadScene ("LoadScene");
	}

}
