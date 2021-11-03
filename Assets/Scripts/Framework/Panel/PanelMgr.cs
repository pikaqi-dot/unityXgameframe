using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelMgr
{
    public void Init()
    {
        GlobalObjs.s_topPanel = GameObject.Find("TopPanel").transform;
        GlobalObjs.s_windowPanel = GameObject.Find("WindowPanel").transform;
        GlobalObjs.s_gamePanel = GameObject.Find("GamePanel").transform;
        GlobalObjs.s_bgPanel = GameObject.Find("BgPanel").transform;
    }

    public BasePanel GetPanelById(int panelId)
    {
        BasePanel panel = null;
        m_panelMap.TryGetValue(panelId, out panel);
        return panel;
    }

    public BasePanel ShowPanel(int panelId, string moduleName, Transform parent)
    {
        var panel = GetPanelById(panelId);
        if (null == panel)
        {
            var go = new GameObject(moduleName);
            panel = go.AddComponent<BasePanel>();
            go.transform.SetParent(parent, false);
            panel.Init(moduleName);
            m_panelMap.Add(panelId, panel);
        }
        panel.Show();
        return panel;
    }

    public T ShowPanel<T>(int panelId, Transform parent) where T : BasePanel
    {
        var panel = GetPanelById(panelId);
        if (null == panel)
        {
            var go = new GameObject(typeof(T).ToString());
            panel = go.AddComponent<T>();
            go.transform.SetParent(parent, false);
            panel.Init(typeof(T).ToString());
            m_panelMap.Add(panelId, panel);
        }
        panel.Show();
        return (T)panel;
    }

    public void HidePanel(int panelId)
    {
        var panel = GetPanelById(panelId);
        if (null != panel)
            panel.Hide();
    }

    public void HideAllPanels()
    {
        foreach (var panel in m_panelMap.Values)
        {
            panel.Hide();
        }
    }

    private Dictionary<int, BasePanel> m_panelMap = new Dictionary<int, BasePanel>();

    private static PanelMgr s_instance;
    public static PanelMgr instance
    {
        get
        {
            if (null == s_instance)
                s_instance = new PanelMgr();
            return s_instance;
        }
    }
}
