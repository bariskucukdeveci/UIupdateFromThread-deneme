using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;


public class myTimer
{
    //private int _threadID;
    private AutoResetEvent timerEvent;
    private System.Threading.Timer timerObj;
    private int _interval;
    private int _start;
    private bool _enabled = false;
    public myTimer()
    {
        timerEvent = new AutoResetEvent(false);
        _enabled = false;
        _interval = 0;
        _start = 0;
    }
    public myTimer(TimerCallback tm, int interval)
    {
        //_start = 0 milliseconds.
        _interval = interval;
        timerEvent = new AutoResetEvent(false);
        timerObj = new System.Threading.Timer(tm, timerEvent, 0, _interval);
        //_threadID = Thread.CurrentThread.ManagedThreadId;
    }
    public myTimer(TimerCallback tm, int start, int interval)
    {
        _start = start;
        _interval = interval;
        timerEvent = new AutoResetEvent(false);
        timerObj = new System.Threading.Timer(tm, timerEvent, _start, _interval);
        //_threadID = Thread.CurrentThread.ManagedThreadId;
    }
    public myTimer(TimerCallback tm, AutoResetEvent resetEvent, int start, int interval)
    {
        _start = start;
        _interval = interval;
        timerEvent = resetEvent;
        timerObj = new System.Threading.Timer(tm, timerEvent, _start, _interval);
        //_threadID = Thread.CurrentThread.ManagedThreadId;

    }
    public void Start()
    {
        _enabled = true;
        timerEvent.WaitOne();
    }
    public void Stop()
    {
        _enabled = false;
        timerEvent.Set();
    }
    public int Interval
    {
        get
        {
            return _interval;
        }
        set
        {
            _interval = value;
        }
    }
    //todo: Eklenenler
    //Timer'ın çalıştığını gösteren Enabled property, IsEnabled yapıldı,
    //Bu property dışardan değiştirilmesin diye 'set'i kaldırıldı.
    public bool IsEnabled
    {
        get
        {
            return _enabled;
        }
    }
    //todo: myTimer'a bir de Dispose() methodu eklendi
    public void Dispose()
    {
        timerObj.Dispose();
        //_threadID = new int();
    }
    //*****************************
    //public int ThreadId
    //{
    //    get
    //    {
    //        return _threadID;
    //    }
    //}
}

