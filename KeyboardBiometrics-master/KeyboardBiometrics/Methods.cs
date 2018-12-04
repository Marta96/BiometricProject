using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace KeyboardBiometrics
{
    class Methods
    {
        bool isPasswordWritingStarted;
        DateTime startTime;
        DateTime pressStartTime;
        DateTime seekStartTime;
        int errorsCount;
        List<int> totalTimeList = new List<int>();
        List<int> pressTimeList = new List<int>();
        List<int> seekTimeList = new List<int>();
        List<int> errorsCountList = new List<int>();

        public Methods(List<int> totalTimeList, List<int> pressTimeList, List<int> seekTimeList, List<int> errorsCountList,
            bool isPasswordWritingStarted)
        {
            this.isPasswordWritingStarted = isPasswordWritingStarted;          
            this.totalTimeList = totalTimeList;
            this.pressTimeList = pressTimeList;
            this.seekTimeList = seekTimeList;
            this.errorsCountList = errorsCountList;
        }

        public void ClearData()
        {
            totalTimeList.Clear();
            pressTimeList.Clear();
            seekTimeList.Clear();
            errorsCountList.Clear();
        }

        public void KeyDown(KeyEventArgs e)
        {
            pressStartTime = DateTime.Now;

            if (isPasswordWritingStarted && e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.Menu && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Tab && e.KeyCode != Keys.Back)
            {
                var totalSeekTime = DateTime.Now - seekStartTime;

                var totalMilisecondsTime = (int)totalSeekTime.TotalMilliseconds;
                if (totalMilisecondsTime < 0) totalMilisecondsTime = 0;
                seekTimeList.Add(totalMilisecondsTime);
            }
            else
            {
                startTime = pressStartTime;

                if (e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.Menu && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Tab && e.KeyCode != Keys.Back)
                {
                    isPasswordWritingStarted = true;
                }
            }

            if (e.KeyCode == Keys.Back)
            {
                errorsCount++;
            }
        }

        public void Leave()
        {
            isPasswordWritingStarted = false;
            var totalTime = DateTime.Now - startTime;
            var totalMilisecondsTime = (int)totalTime.TotalMilliseconds;
            totalTimeList.Add(totalMilisecondsTime);
            errorsCountList.Add(errorsCount);
        }

        public void KeyUp(KeyEventArgs e)
        {
            if (e.KeyCode != Keys.ShiftKey && e.KeyCode != Keys.Menu && e.KeyCode != Keys.ControlKey && e.KeyCode != Keys.Tab && e.KeyCode != Keys.Back)
            {
                seekStartTime = DateTime.Now;
                var totalPressTime = DateTime.Now - pressStartTime;
                var totalMilisecondsTime = (int)totalPressTime.TotalMilliseconds;
                pressTimeList.Add(totalMilisecondsTime);
            }
            
        }
    }

}
