using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl {
	public class VirtualConsole {
		private int bufferSize;
		private LinkedList<string> buffer;
		private StringBuilder sb;


		public VirtualConsole(int bufferSize) {
			this.bufferSize = bufferSize;
			buffer = new LinkedList<string>();
			sb = new StringBuilder();
		}


		public void Print(string str) {
			buffer.AddLast(str);
			if(buffer.Count > bufferSize) {
				buffer.RemoveFirst();
			}
		}

		public override string ToString() {
			sb.Clear();
			foreach (string str in buffer) {
				sb.AppendLine(str);
			}
			return sb.ToString();
		}
	}
}
