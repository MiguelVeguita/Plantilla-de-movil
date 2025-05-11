#if UNITY_ANDROID
using Unity.Notifications.Android;
using UnityEngine;
using System;

public class NotificationSystem : PersistentSingleton<NotificationSystem>
{
    private const string CHANNEL_ID = "default_channel";

    protected override void Awake()
    {
        base.Awake();
        if (Instance == this)
            RegisterChannel();
    }

    private void RegisterChannel()
    {
        var channel = new AndroidNotificationChannel()
        {
            Id = CHANNEL_ID,
            Name = "Default Channel",
            Description = "Generic notifications",
            Importance = Importance.Default
        };
        AndroidNotificationCenter.RegisterNotificationChannel(channel);
    }

    public void RequestPermission()
    {
        Debug.Log("Android notifications are enabled by default.");
    }

    public void ScheduleNotification(string title, string text, DateTime fireTime)
    {
        var notification = new AndroidNotification
        {
            Title = title,
            Text = text,
            FireTime = fireTime
        };
        AndroidNotificationCenter.SendNotification(notification, CHANNEL_ID);
    }
}
#endif
