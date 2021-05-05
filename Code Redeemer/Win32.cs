using System;
using System.Runtime.InteropServices;

namespace CodeRedeemer
{
	/// <summary>
	/// Summary description for Win32.
	/// </summary>
	public class Win32
	{
		// The WM_COMMAND message is sent when the user selects a command item from a menu, 
		// when a control sends a notification message to its parent window, or when an 
		// accelerator keystroke is translated.
        public const int WM_COMMAND = 0x111;
        public const int WM_LBUTTONDOWN = 0x201;
        public const int WM_LBUTTONUP = 0x202;
        public const int WM_LBUTTONDBLCLK = 0x203;
        public const int WM_RBUTTONDOWN = 0x204;
        public const int WM_RBUTTONUP = 0x205;
        public const int WM_RBUTTONDBLCLK = 0x206;
        public const int WM_KEYDOWN = 0x100;
        public const int WM_KEYUP = 0x101;

		// The FindWindow function retrieves a handle to the top-level window whose class name
		// and window name match the specified strings. This function does not search child windows.
		// This function does not perform a case-sensitive search.
		[DllImport("User32.dll")]
		public static extern int FindWindow(string strClassName, string strWindowName);

        // The FindWindowEx function retrieves a handle to a window whose class name 
        // and window name match the specified strings. The function searches child windows, beginning
        // with the one following the specified child window. This function does not perform a case-sensitive search.
        [DllImport("User32.dll")]
        public static extern int FindWindowEx(int hwndParent, int hwndChildAfter, string strClassName, string strWindowName);

        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        [DllImport("user32.dll", SetLastError = true)]
        [return: MarshalAs(UnmanagedType.Bool)]
        public static extern bool GetWindowRect(System.Int32 hWnd, ref RECT lpRect);


        // The SendMessage function sends the specified message to a 
        // window or windows. It calls the window procedure for the specified 
        // window and does not return until the window procedure has processed the message. 
        [DllImport("User32.dll")]
		public static extern Int32 SendMessage(
			int hWnd,               // handle to destination window
			int Msg,                // message
			int wParam,             // first message parameter
			int lParam);			// second message parameter

		public Win32()
		{
			
		}

		~Win32()
		{
		}

	}
}
