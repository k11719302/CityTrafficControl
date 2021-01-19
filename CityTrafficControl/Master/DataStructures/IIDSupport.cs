using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.Master.DataStructures {
	/// <summary>
	/// Every class which implements this interface, has an individual ID.
	/// </summary>
	public interface IIDSupport {
		/// <summary>
		/// Gets the ID of this object.
		/// </summary>
		int ID { get; }
	}
}
