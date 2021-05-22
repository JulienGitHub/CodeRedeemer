using System;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Text;
using Gma.System.MouseKeyHook;
using System.Collections.Generic;

namespace CodeRedeemer
{
    public partial class Main : Form
    {
        private IKeyboardMouseEvents m_GlobalHook;
        Process PTCGOProcess = null;
        bool m_bStop = false;

        Win32.RECT mWindowRect = new Win32.RECT();

        [DllImport("user32.dll")]
        static extern bool ClientToScreen(IntPtr hWnd, ref Point lpPoint);

        [DllImport("user32.dll")]
        public static extern bool GetWindowRect(IntPtr hwnd, ref Win32.RECT rectangle);

        [DllImport("user32.dll")]
        internal static extern uint SendInput(uint nInputs, [MarshalAs(UnmanagedType.LPArray), In] INPUT[] pInputs, int cbSize);

        [DllImport("user32.dll", EntryPoint = "FindWindowEx")]
        public static extern IntPtr FindWindowEx(IntPtr hwndParent, IntPtr hwndChildAfter, string lpszClass, string lpszWindow);

        internal struct INPUT
        {
            public UInt32 Type;
            public MOUSEKEYBDHARDWAREINPUT Data;
        }

        [StructLayout(LayoutKind.Explicit)]
        internal struct MOUSEKEYBDHARDWAREINPUT
        {
            [FieldOffset(0)]
            public MOUSEINPUT Mouse;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public class MouseHookStruct
        {
            public POINT pt;
            public int hwnd;
            public int wHitTestCode;
            public int dwExtraInfo;
        }

        enum MouseMessages
        {
            WM_LBUTTONDOWN = 0x0201,
            WM_LBUTTONUP = 0x0202,
        }

        internal struct MOUSEINPUT
        {
            public Int32 X;
            public Int32 Y;
            public UInt32 MouseData;
            public UInt32 Flags;
            public UInt32 Time;
            public IntPtr ExtraInfo;
        }
        
        public static void ClickOnPoint(IntPtr wndHandle, Point clientPoint)
        {
            var oldPos = Cursor.Position;

            /// get screen coordinates
            //ClientToScreen(wndHandle, ref clientPoint);

            /// set cursor on coords, and press mouse
            Cursor.Position = new Point(clientPoint.X, clientPoint.Y);

            var inputMouseDown = new INPUT();
            inputMouseDown.Type = 0; /// input type mouse
            inputMouseDown.Data.Mouse.Flags = 0x0002; /// left button down

            var inputMouseUp = new INPUT();
            inputMouseUp.Type = 0; /// input type mouse
            inputMouseUp.Data.Mouse.Flags = 0x0004; /// left button up

            var inputs = new INPUT[] { inputMouseDown };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

            Thread.Sleep(200);

            inputs = new INPUT[] { inputMouseUp };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

            Thread.Sleep(200);

            inputs = new INPUT[] { inputMouseDown };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

            Thread.Sleep(200);

            inputs = new INPUT[] { inputMouseUp };
            SendInput((uint)inputs.Length, inputs, Marshal.SizeOf(typeof(INPUT)));

            /// return mouse 
            Cursor.Position = oldPos;
        }

        public Main()
        {
            InitializeComponent();

            m_GlobalHook = Hook.GlobalEvents();


            m_GlobalHook.MouseDownExt += MouseClickAll;
            m_GlobalHook.KeyPress += KeyPressAll;

            textSleepMS.Text = "1000";

            buttonAddClick.Enabled = false;
            buttonCode.Enabled = false;
            textSleepMS.Enabled = false;
            buttonSleep.Enabled = false;
            buttonTest.Enabled = false;

            listViewScript.Columns.Add("Action");
            listViewScript.Columns.Add("Parameters");
            listViewScript.Columns[0].Width = 100;
            listViewScript.Columns[1].Width = 100;
        }

        private static int CreateLParam(int LoWord, int HiWord)
        {
            return (int)((HiWord << 16) | (LoWord & 0xffff));
        }

        private void OnLoad(object sender, EventArgs e)
        {
            
        }     

        private void buttonFindPTCGO_Click(object sender, EventArgs e)
        {
            CheckWindow();
            LocateWindow();
        }

        private void LocateWindow()
        {
            GetWindowRect(PTCGOProcess.MainWindowHandle, ref mWindowRect);
            labelPTCGOPos.Text = "left: " + mWindowRect.Left.ToString() + " top:" + mWindowRect.Top.ToString() + " right:" + mWindowRect.Right.ToString() + " bottom:" + mWindowRect.Bottom.ToString() + " w:" + (mWindowRect.Right - mWindowRect.Left).ToString() + " h:" + (mWindowRect.Bottom - mWindowRect.Top).ToString();
        }
        private void CheckWindow()
        {
            
            //string sProcess = "notepad";

            Process[] localAll = Process.GetProcesses();
            for (int i = 0; i < localAll.Length; i++)
            {
                if (localAll[i].ProcessName.ToUpper().Contains("POKEMON TRADING"))
                {
                    PTCGOProcess = localAll[i];
                }
            }

            if (PTCGOProcess == null)
            {
                string message = "Could not find PTCGO!";
                string caption = "Redeemer";
                MessageBoxButtons buttons = MessageBoxButtons.OK;
                DialogResult result;

                result = MessageBox.Show(message, caption, buttons);
                return;
            } 
             
            buttonAddClick.Enabled = true;
            buttonCode.Enabled = true;
            textSleepMS.Enabled = true;
            buttonSleep.Enabled = true;
            buttonTest.Enabled = true;
        }

        delegate void SetTextCallback(string[] text);
        public void SetText(string[] text)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.textBoxCodes.InvokeRequired)
            {
                SetTextCallback d = new SetTextCallback(SetText);
                this.Invoke(d, new object[] { text });
            }
            else
            {
                this.textBoxCodes.Lines = text;
            }
        }

        delegate string GetDataCallback(int iLine, int iParam);
        public string GetData(int iLine, int iParam)
        {
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.listViewScript.InvokeRequired)
            {
                GetDataCallback d = new GetDataCallback(GetData);
                return (string)this.Invoke(d, new object[] { iLine, iParam });
            }
            else
            {
                return listViewScript.Items[iLine].SubItems[iParam].Text;
            }
        }

        delegate void PasteaCallback();
        public void Paste()
        {        
            // InvokeRequired required compares the thread ID of the 
            // calling thread to the thread ID of the creating thread. 
            // If these threads are different, it returns true. 
            if (this.textBoxCodes.InvokeRequired)
            {
                PasteaCallback d = new PasteaCallback(Paste);
                this.Invoke(d, new object[] { });
            }
            else
            {
                if (textBoxCodes.Lines[0].Length > 0)
                {
                    Clipboard.SetText(textBoxCodes.Lines[0]);
                    SendKeys.Send("^{v}");
                }
            }
        }
        public void ScriptThreadFunction()
        {
            Random r = new Random();
            int iReadingLine = 0;
            while (!m_bStop)
            {
                string sAction = GetData(iReadingLine, 0);
                string sParameter = GetData(iReadingLine, 1);

                if (sAction.Contains("MouseClick"))
                {
                    string[] coordinates = sParameter.Split(';');
                    SimulateClick(Int32.Parse(coordinates[0]), Int32.Parse(coordinates[1]), true);
                }

                if (sAction.Contains("Sleep"))
                {
                    int iMilliseconds = Int32.Parse(sParameter) + r.Next(100, 500);
                    Thread.Sleep(iMilliseconds);
                }

                if (sAction.Contains("CopyPaste"))
                {
                    if (textBoxCodes.Lines.Length > 0)
                    {
                        Paste();
                        
                        string[] lines = textBoxCodes.Lines;
                        IEnumerable<string> newLines = lines.Skip(1);
                        SetText(newLines.ToArray());
                    }
                    else 
                    {
                        m_bStop = true;
                    }
                }

                iReadingLine++;
                if (iReadingLine == listViewScript.Items.Count)
                    iReadingLine = 0;
                
            }
        }


        private void start_Click(object sender, EventArgs e)
        {
            m_bStop = false;
            Thread thread = new Thread(new ThreadStart(ScriptThreadFunction));
            thread.Start();            
        }

        [DllImport("user32.dll", CharSet = CharSet.Auto, ExactSpelling = true)]
        public static extern IntPtr GetDesktopWindow();
        [DllImport("user32.dll", EntryPoint = "GetDCEx", CharSet = CharSet.Auto, ExactSpelling = true)]
        private static extern IntPtr GetDCEx(IntPtr hWnd, IntPtr hrgnClip, int flags);


        private void SimulateClick(int X, int Y, bool bReal)
        {
            LocateWindow();
            if (bReal)
                ClickOnPoint(PTCGOProcess.MainWindowHandle, new Point(mWindowRect.Left + (int)(X * (mWindowRect.Right - mWindowRect.Left) / 100.0f), mWindowRect.Top + (int)(Y * (mWindowRect.Bottom - mWindowRect.Top) / 100.0f)));
            else
            {
                IntPtr desk = GetDesktopWindow();
                IntPtr deskDC = GetDCEx(desk, IntPtr.Zero, 0x403);
                Graphics g = Graphics.FromHdc(deskDC);
                SolidBrush redBrush = new SolidBrush(Color.Red);

                g.FillEllipse(redBrush, mWindowRect.Left + (int)(X * (mWindowRect.Right - mWindowRect.Left) / 100.0f), mWindowRect.Top + (int)(Y * (mWindowRect.Bottom - mWindowRect.Top) / 100.0f), 20, 20);
            }
        }

        private void buttonCode_Click(object sender, EventArgs e)
        {
            string[] saLvwItem = new string[2];
            saLvwItem[0] = "CopyPaste";
            saLvwItem[1] = "None";
            ListViewItem lvi = new ListViewItem(saLvwItem);
            listViewScript.Items.Add(lvi);
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        static extern bool GetCursorPos(out POINT lpPoint);

        static bool bListeningToMouse = false;

        private void MouseClickAll(object sender, MouseEventArgs e)
        {
            if (bListeningToMouse)
            {
                bListeningToMouse = false;

                string[] saLvwItem = new string[2];
                saLvwItem[0] = "MouseClick";

                int iWidth = mWindowRect.Right - mWindowRect.Left;
                int iHeight = mWindowRect.Bottom - mWindowRect.Top;

                int iX = e.X - mWindowRect.Left;
                int iY = e.Y - mWindowRect.Top;

                saLvwItem[1] = Convert.ToString((int)(iX * 100.0f / (float)iWidth)) + ";" + Convert.ToString((int)(iY * 100.0f / (float)iHeight));
                ListViewItem lvi = new ListViewItem(saLvwItem);
                listViewScript.Items.Add(lvi);
            }
        }

        private void KeyPressAll(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 'q')
            {
                m_bStop = true;
            }
        }     

        private void buttonAddClick_Click(object sender, EventArgs e)
        {
            LocateWindow();
            bListeningToMouse = true;
        }

        private void buttonRemove_Click(object sender, EventArgs e)
        {
            if (listViewScript.SelectedItems.Count == 1)
            {
                listViewScript.SelectedItems[0].Remove();
            }
        }

        private void buttonSleep_Click(object sender, EventArgs e)
        {
            string[] saLvwItem = new string[2];
            saLvwItem[0] = "Sleep";
            saLvwItem[1] = textSleepMS.Text;
            ListViewItem lvi = new ListViewItem(saLvwItem);
            listViewScript.Items.Add(lvi);
            
        }

        private void buttonUp_Click(object sender, EventArgs e)
        {
            if (listViewScript.SelectedItems.Count == 1)
            {
                ListViewItem selected = listViewScript.SelectedItems[0];
                int indx = selected.Index;
                int totl = listViewScript.Items.Count;

                if (indx == 0)
                {
                    listViewScript.Items.Remove(selected);
                    listViewScript.Items.Insert(totl - 1, selected);
                    listViewScript.Items[totl - 1].Selected = true;
                }
                else
                {
                    listViewScript.Items.Remove(selected);
                    listViewScript.Items.Insert(indx - 1, selected);
                    listViewScript.Items[indx - 1].Selected = true;
                }
            }
        }

        private void buttonDown_Click(object sender, EventArgs e)
        {
            if (listViewScript.SelectedItems.Count == 1)
            {
                ListViewItem selected = listViewScript.SelectedItems[0];
                int indx = selected.Index;
                int totl = listViewScript.Items.Count;

                if (indx == totl - 1)
                {
                    listViewScript.Items.Remove(selected);
                    listViewScript.Items.Insert(0, selected);
                    listViewScript.Items[0].Selected = true;
                }
                else
                {
                    listViewScript.Items.Remove(selected);
                    listViewScript.Items.Insert(indx + 1, selected);
                    listViewScript.Items[indx + 1].Selected = true;
                }
            }
        }

        private void buttonSave_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Title = "Save Script";
            saveFileDialog.DefaultExt = "script";
            saveFileDialog.Filter = "Script files (*.script)|*.script";
            saveFileDialog.RestoreDirectory = true;
            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < listViewScript.Items.Count; i++)
                {
                    sb.Append(listViewScript.Items[i].SubItems[0].Text + "|" + listViewScript.Items[i].SubItems[1].Text + "\n");
                }
                System.IO.File.WriteAllText(saveFileDialog.FileName, sb.ToString());
            }
        }

        private void buttonLoad_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Title = "Save Script";
            openFileDialog.DefaultExt = "script";
            openFileDialog.Filter = "Script files (*.script)|*.script";
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                listViewScript.Items.Clear();
                string[] lines = System.IO.File.ReadAllLines(openFileDialog.FileName);
                for (int i = 0; i < lines.Length; i++)
                {
                    if (!lines[i].Contains('#'))
                    {
                        string[] data = lines[i].Split('|');
                        if (data.Length == 2)
                        {
                            string[] saLvwItem = new string[2];
                            saLvwItem[0] = data[0];
                            saLvwItem[1] = data[1];
                            ListViewItem lvi = new ListViewItem(saLvwItem);
                            listViewScript.Items.Add(lvi);
                        }
                    }
                }
            }
        }

        private void Main_FormClosing(object sender, FormClosingEventArgs e)
        {
            m_GlobalHook.MouseDownExt -= MouseClickAll;
            m_GlobalHook.KeyPress -= KeyPressAll;

            //It is recommended to dispose it
            m_GlobalHook.Dispose();
        }

        private void buttonTest_Click(object sender, EventArgs e)
        {
            if (listViewScript.SelectedItems.Count == 1)
            {
                if (listViewScript.SelectedItems[0].SubItems[0].Text.Contains("MouseClick"))
                {
                    string[] coordinates = listViewScript.SelectedItems[0].SubItems[1].Text.Split(';');
                    SimulateClick(Int32.Parse(coordinates[0]), Int32.Parse(coordinates[1]), false);
                }
            }
        }
    }

}