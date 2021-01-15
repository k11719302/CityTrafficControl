using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.DataStructures {
	public interface IIDSupport {
		/// <summary>
		/// Gets the ID of this object.
		/// </summary>
		int ID { get; }
	}
}
