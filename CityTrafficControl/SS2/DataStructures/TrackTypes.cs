using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CityTrafficControl.SS2.DataStructures {
	[Flags]
	enum TrackTypes {
		Street = 1,
		Highway = 2,
		Sidewalk = 4,
		TramRails = 8
	}
}
