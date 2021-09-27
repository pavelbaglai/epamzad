using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace homework_9.Task2
{

    #region NewMsgEventArgs
    public sealed class NewMsgEventArgs : EventArgs
    {

        private readonly string _msgText;
        private readonly int _sleeptime;

        public NewMsgEventArgs(int time, string subject)
        {
            _sleeptime = time;
            _msgText = subject;
        }

        public int SleepTime { get { return _sleeptime; } }
        public string Subject { get { return _msgText; } }
    }
    #endregion

    #region Countdown
    public class Countdown
    {
        public delegate void NewMsgEventHandler(object sender, NewMsgEventArgs e);

        public event NewMsgEventHandler NewMsg;
        protected virtual void OnNewMsg(object sender, NewMsgEventArgs e)
        {
            NewMsg?.Invoke(sender, e);
        }

        public void SendNewMsg(string subject, int time=0)
        {
            if (string.IsNullOrEmpty(subject)) throw new ArgumentNullException(nameof(subject));
            Thread.Sleep(time);
            OnNewMsg(this, new NewMsgEventArgs(time, subject));
        }
    }
    #endregion

    #region Listeners
    public class Listener
    {
        public void Register(Countdown msg)
        {
            msg.NewMsg += ListenerMsg;
        }

        private void ListenerMsg(Object sender, NewMsgEventArgs eventArgs)
        {
            Console.WriteLine("Received new message = {0}", eventArgs.Subject);
        }

        public void Unregister(Countdown msg)
        {
            msg.NewMsg -= ListenerMsg;
        }
    }

    public class Listener2
    {
        private void Listener2Msg(Object sender, NewMsgEventArgs eventArgs)
        {
            Console.WriteLine("Received new message = {0}", eventArgs.Subject);
        }

        public void Unregister(Countdown msg)
        {
            msg.NewMsg -= Listener2Msg;
        }

        public void Register(Countdown msg)
        {
            msg.NewMsg += Listener2Msg;
        }
    }
    #endregion

}

    