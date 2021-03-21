﻿using System;
using System.Windows;

namespace WarechouseInterface.Managers
{
    class RootManager
    {
        public void RootFromTo(Window from, Window to, bool terminate = false)
        {
            if (terminate)
            {
                from.Close();
            }
            else
            {
                from.Hide();
            }
         
            to.Show();
        }

        public void RootFromToWindowOnTop(Window to)
        {
            to.Show();
        }

        public void TerminateWindow(Window widnow)
        {
            widnow.Close();
        }

        public void ExitApp()
        {
            Environment.Exit(0);
        }
    }
}

