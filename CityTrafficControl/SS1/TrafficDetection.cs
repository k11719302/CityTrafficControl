using System;
using System.Collections.Generic;
using System.Text;
using CityTrafficControl.Master.StreetMap;


namespace CityTrafficControl.SS1
{
    class TrafficDetection
    {
        private static TrafficDetection instance = null; //using Singleton, because SS1 only needs one traffic detector

        private TrafficDetection()
		{
			Master.DataLinker.SS1.DetectNaturalDisaster += DataLinker_SS1_DetectNaturalDisaster;
            Master.DataLinker.SS1.DetectAccident += DataLinker_SS1_DetectAccident;
		}

        /// <summary>
        /// Creates the first instance or always returns the singleton instance.
        /// </summary>
		public static TrafficDetection GetInstance 
        {
            get
            {
                if (instance == null)
                {
                    instance = new TrafficDetection();
                }
                return instance;
            }
        }

        /// <summary>
        /// This method gets called by the system when a new incident (accident or natural disaster) has been simulated.
        /// </summary>
        /// <param name="type"></param>
        /// <param name="connector"></param>
        /// <param name="involvedObjects"></param>
        /// <param name="roadDamage"></param>
        public static void IncidentHappened(IncidentType type, List<StreetConnector> connectors)
        {
            Incident incident = new Incident(type, connectors);
            TrafficControl.IncidentDetected(incident);
        }


		#region DataLinker
		private void DataLinker_SS1_DetectNaturalDisaster(object sender, List<StreetConnector> e) {
			IncidentHappened(IncidentType.NATDISASTER, e);
		}
        #endregion

        #region DataLinker
        private void DataLinker_SS1_DetectAccident(object sender, List<StreetConnector> e)
        {
            IncidentHappened(IncidentType.ACCIDENT, e);
        }
        #endregion
    }
}
