﻿using GalaSoft.MvvmLight.Messaging;

namespace Automaton.ViewModel
{
    class LoadingDialogHandle
    {
        public static void OpenDialog(string title, string message)
        {
            var payload = new LoadingDialogPayload()
            {
                Title = title,
                Message = message,
                DebugText = "",
                IsOpen = true,
                IsDoneLoading = false
            };

            SendPayload(payload);
        }

        public static void UpdateDialog(string title, string message, string debugText)
        {
            var payload = new LoadingDialogPayload()
            {
                Title = title,
                Message = message,
                DebugText = debugText,
            };

            SendPayload(payload);
        }

        public static void UpdateDebugText(string debugText)
        {
            var payload = new LoadingDialogPayload()
            {
                DebugText = debugText
            };

            SendPayload(payload);
        }

        public static void LoadingComplete()
        {
            var payload = new LoadingDialogPayload()
            {
                IsDoneLoading = true
            };

            SendPayload(payload);
        }

        private static void SendPayload(LoadingDialogPayload payload)
        {
            Messenger.Default.Send(payload);
        }
    }

    class LoadingDialogPayload
    {
        public string Title;
        public string Message;
        public string DebugText;
        public bool? IsOpen;
        public bool? IsDoneLoading;
    }
}
