using UnityEngine;

/// <summary>
/// 平台管理
/// </summary>
public class CPlatform : MonoBehaviour
{
	private static CPlatform s_cInstance;
	public static CPlatform sInstance
	{
		get
		{
			if(s_cInstance == null )
			{
				GameObject obj = new GameObject("Platform");
				s_cInstance = obj.AddComponent<CPlatform>();
			}
			return s_cInstance;
		}
	}
	
	private PlatformBase m_cPlatform = null;
    public PlatformBase Platform
    {
        get { return m_cPlatform; }
    }

	public CPlatform()
    {
#if UNITY_ANDROID
        platform = new PlatformForIOS();
#endif
    }

	void OnDestory()
	{
		s_cInstance = null;
	}

	void FixedUpdate()
	{
		if( this.m_cPlatform != null )
		   this.m_cPlatform.Update();
	}

    /// <summary>
    /// 获取设备号
    /// </summary>
    /// <returns></returns>
    public string GetDeviceID()
    {
        if (m_cPlatform == null) return "";

        return m_cPlatform.GetDeviceID();
    }

    /// <summary>
    /// 获取渠道号
    /// </summary>
    /// <returns></returns>
    public string GetChannelName()
    {
        if (m_cPlatform == null) return "";

        return m_cPlatform.GetChannelName();
    }

    /// <summary>
    /// 暂停事件
    /// </summary>
    /// <param name="pause"></param>
    public void OnApplicationPause(bool pause)
    {
        if (m_cPlatform == null) return;
        m_cPlatform.OnApplicationPause(pause);
    }

    /// <summary>
    /// 初始化
    /// </summary>
    public void Init()
    {
        if (m_cPlatform == null) return;
        m_cPlatform.Init();
    }

    /// <summary>
    /// 逻辑更新
    /// </summary>
    /// <returns></returns>
    public bool Update()
    {
        if (m_cPlatform == null) return false;
        return m_cPlatform.Update();
    }

    /// <summary>
    /// 更新版本
    /// </summary>
    /// <param name="path"></param>
    public void UpdateVersion(string path)
    {
        if (m_cPlatform == null) return;
        m_cPlatform.UpdateVersion(path);
    }

    /// <summary>
    /// 登录
    /// </summary>
    public void Login()
    {
        if (m_cPlatform == null)
            return;
        m_cPlatform.Login();
    }

    /// <summary>
    /// 展示登录
    /// </summary>
    public void ShowPlatformLogin()
    {
        if (m_cPlatform == null) return;
        m_cPlatform.ShowLogin();
    }

    /// <summary>
    /// 展示登出
    /// </summary>
    public void ShowPlatformLoginOut()
    {
        if (m_cPlatform == null) return;
        m_cPlatform.ShowLogout();
    }
   

    /// <summary>
    /// 显示平台社区
    /// </summary>
    public void ShowPlatformCommunity()
    {
        if (m_cPlatform == null) return;

        m_cPlatform.ShowCommunity();
    }
	
	    /// <summary>
    /// 隐藏平台社区
    /// </summary>
    public void HidenPlatformCommunity()
    {
        if (m_cPlatform == null) return;

        m_cPlatform.HidenCommunity();
    }


    /// <summary>
    /// 显示游戏论坛
    /// </summary>
    public void ShowPlatformForum()
    {

        if (m_cPlatform == null) return;

        m_cPlatform.ShowForum();

    }


    /// <summary>
    /// 显示平台反馈
    /// </summary>
    public void ShowPlatformFeedback()
    {
        if (m_cPlatform == null) return;
        m_cPlatform.ShowFeedBack();
    }

    /// <summary>
    /// 充值界面
    /// </summary>
    public void ShowPayment(params object[] arg)
    {
        if (m_cPlatform == null) return;
        m_cPlatform.ShowPayment(arg);
    }

    /// <summary>
    /// 退出平台
    /// </summary>
    public void AppExit()
    {
        if (m_cPlatform == null) 
            return;

        m_cPlatform.AppExit();
    }

    /// <summary>
    /// 暂停
    /// </summary>
    public void AppPause()
    {
        if (m_cPlatform == null) return;
        m_cPlatform.AppPause();
    }


    /// <summary>
    /// 平台登录的回调
    /// </summary>
    public void PlatformLoginCallBack(string arg)//(uid,sessionid,name)
    {
        if (m_cPlatform == null) return;
        m_cPlatform.OnLoginCallBack(arg);
    }

    /// <summary>
    /// 玩家取消了登录回调接口
    /// </summary>
    /// <param name="arg"></param>
    public void PlatformLoginCancelCallBack(string arg)
    {
        if (m_cPlatform == null) return;
        m_cPlatform.OnLoginCancelCallBack(arg);
    }

    /// <summary>
    /// 登出成功回调
    /// </summary>
    public void PlatformLogoutSuccess()
    {
        if (m_cPlatform == null) return;
        m_cPlatform.OnLogoutSuccessCallBack();
    }

    /// <summary>
    /// 登出失败回调
    /// </summary>
    public void PlatformLoginOutFail()
    {
        if (m_cPlatform == null) return;
        m_cPlatform.OnLogoutFailCallBack();

    }

    /// <summary>
    /// 付款成功回调
    /// </summary>
    /// <param name="arg"></param>
    public void OnPaymentSuccessCallBack(string arg)
    {
        if (m_cPlatform == null) return;
        m_cPlatform.OnPaymentSuccessCallBack(arg);
    }

    /// <summary>
    /// 付款失败
    /// </summary>
    /// <param name="arg"></param>
    public void OnPaymentFailCallBack(string arg)
    {
        if (m_cPlatform == null) return;
        m_cPlatform.OnPaymentFailCallBack(arg);
    }

    /// <summary>
    /// 切换帐号回调
    /// </summary>
    /// <param name="arg"></param>
    public void PlatformSwitchAccountCallBack(string arg)
    {
        if (m_cPlatform == null) return;
        m_cPlatform.SwitchAccountCallBack(arg);
    }
}
