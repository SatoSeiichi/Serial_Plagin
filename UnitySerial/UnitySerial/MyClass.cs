using System;
using System.Collections;
using System.Collections.Generic;
using System.IO.Ports;
using System.Threading;
using System.Runtime.CompilerServices;

namespace UnitySerial
{
	public class UnitySerial
	{
		private SerialPort serialPort_;
		private bool isRunning_ = false;
		private Thread thread_;

		string message_;

		private bool isNewMessageReceived_ = false;

		public UnitySerial(string portName, int baudRate, int bufSize)
		{
			serialPort_ = new SerialPort (portName, baudRate, Parity.None, 8, StopBits.One);
			serialPort_.Open ();

			isRunning_ = true;

			thread_ = new Thread (Read);
			thread_.Start();
		}

		public void Close()
		{
			isRunning_ = false;

			if (thread_ != null && thread_.IsAlive) {
				thread_.Join();
			}

			if (serialPort_ != null && serialPort_.IsOpen) {
				serialPort_.Close();
				serialPort_.Dispose();
			}
		}

		public string GetData()
		{
			return message_;
		}

		private void Read()
		{
			while (isRunning_ && serialPort_ != null && serialPort_.IsOpen) {
				try {
					//if (serialPort_.BytesToRead > 0) {
					message_ = serialPort_.ReadLine();
					isNewMessageReceived_ = true;

					//}
				} catch (System.Exception e) {
				}
			}
		}

		public void Write(string message)
		{
			try {
				serialPort_.Write(message);

			} catch (System.Exception e) {
			}
		}
	}
}

