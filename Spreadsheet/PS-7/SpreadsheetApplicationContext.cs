﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PS_7
{
    class SpreadsheetApplicationContext : ApplicationContext
    {
        //Number of open Forms
        private int windowCount = 0;

        //Singleton ApplicationContext
        private static SpreadsheetApplicationContext context;

        /// <summary>
        /// Private constructor for singleton pattern
        /// </summary>
        private SpreadsheetApplicationContext()
        {

        }

        /// <summary>
        /// Returns the one DemoApplicationContext.
        /// </summary>
        public static SpreadsheetApplicationContext GetContext()
        {
            if (context == null)
            {
                context = new SpreadsheetApplicationContext();
            }
            return context;
        }

        /// <summary>
        /// Runs a form in this application context
        /// </summary>
        public void RunNew()
        {
            // Create the window and the controller
            SpreadsheetWindow window = new SpreadsheetWindow();
            new Controller(window);

            // One more form is running
            windowCount++;

            // When this form closes, we want to find out
            window.FormClosed += (o, e) => { if (--windowCount <= 0) ExitThread(); };

            // Run the form
            window.Show();
        }

        public void RunNew(ISpreadsheetView _window)
        {
            // Create the window and the controller
            SpreadsheetWindow window = (SpreadsheetWindow)_window;
            new Controller(window);

            // One more form is running
            windowCount++;

            // When this form closes, we want to find out
            window.FormClosed += (o, e) => { if (--windowCount <= 0) ExitThread(); };

            // Run the form
            window.Show();
        }

    }
}
