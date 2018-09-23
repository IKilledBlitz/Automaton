﻿using Automaton.Model.Utility;
using Automaton.ViewModel.Controllers;
using System;
using System.ComponentModel;
using System.Threading.Tasks;

namespace Automaton.ViewModel
{
    public class InstallModpack : IInstallModpack, INotifyPropertyChanged
    {
        private IViewController _viewController;

        public event PropertyChangedEventHandler PropertyChanged;

        public string ConsoleOut { get; set; }

        private int ThisViewIndex { get; } = 4;

        public InstallModpack(IViewController viewController)
        {
            _viewController = viewController;

            _viewController.ViewIndexChangedEvent += IncrementViewIndexUpdate;
        }

        private void IncrementViewIndexUpdate(object sender, int currentIndex)
        {
            if (currentIndex == ThisViewIndex)
            {
                StartModpackInstall();
            }
        }

        private void StartModpackInstall()
        {
            Task.Factory.StartNew(() =>
            {
                Modpack.InstallModpack(new Progress<InstallModpackProgress>(installProgress =>
                {
                    ConsoleOut += installProgress.UpdateString + "\n";
                }));
            });
        }
    }
}
